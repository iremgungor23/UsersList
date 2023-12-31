﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Asn1.X509;
using NLog;

namespace UsersList
{
    public partial class Form2 : Form
    {
        private object _userList;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public Form2()
        {
            InitializeComponent();

        }


        public DataGridView DataGridViewFromForm2
        {
            get { return dataGridView1; }
        }


        private void btnExport_Click(object sender, EventArgs e)
        {

            Logger.Info("Veriler dışarı aktarılıyor");

            try
            {
                PdfPTable pdfTablosu = new PdfPTable(dataGridView1.ColumnCount);
                pdfTablosu.DefaultCell.Padding = 3;
                pdfTablosu.WidthPercentage = 100;
                pdfTablosu.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfTablosu.DefaultCell.BorderWidth = 1;
                foreach (DataGridViewColumn sutun in dataGridView1.Columns)
                {
                    PdfPCell pdfHucresi = new PdfPCell(new Phrase(sutun.HeaderText));
                    pdfTablosu.AddCell(pdfHucresi);
                }
                foreach (DataGridViewRow satir in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell cell in satir.Cells)
                    {
                        pdfTablosu.AddCell(cell.Value.ToString());
                    }
                }

                SaveFileDialog dosyakaydet = new SaveFileDialog();
                dosyakaydet.FileName = "projePDfDosyaAdı";
                dosyakaydet.InitialDirectory = Environment.SpecialFolder.Desktop.ToString();
                dosyakaydet.Filter = "PDF Dosyası|*.pdf";
                if (dosyakaydet.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream stream = new FileStream(dosyakaydet.FileName, FileMode.Create))
                    {
                        iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(PageSize.A4, 10f, 10f, 10f, 0f);
                        PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();
                        pdfDoc.Add(pdfTablosu);
                        pdfDoc.Close();
                        stream.Close();
                        MessageBox.Show("PDF dosyası başarıyla oluşturuldu!\n" + "Dosya Konumu: " + dosyakaydet.FileName, "İşlem Tamam");

                        Logger.Info("Veriler dışarı aktarıldı");

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);


                Logger.Info("Veriler dışarı aktarılamadı");
            }
        }

        private void Form_Load(object sender, EventArgs e)
        {
            LoadUserFromJson();

        }


        private void LoadUserFromJson()
        {


            string userListFilePath = Path.Combine(Application.StartupPath, "UsersList", "users.json");
            dataGridView1.Rows.Clear();
            if (File.Exists(userListFilePath))
            {
                string userListJson = File.ReadAllText(userListFilePath);
                JArray userListArray = JArray.Parse(userListJson);

                foreach (var user in userListArray)
                {
                    string id = user["Id"].ToString();
                    string name = user["Name"].ToString();
                    string surname = user["Surname"].ToString();
                    string gender = user["Gender"].ToString();
                    string education = user["Education"].ToString();
                    string birthDate = user["BirthDate"].ToString();
                    string imageid = user["UserPicture"].ToString();

                    if (!string.IsNullOrEmpty(id))
                    {
                        User newProduct = new User
                        {
                            Id = id,
                            Name = Name,
                            Surname = surname,
                            Gender = gender,
                            BirthDate = birthDate,
                            Education = education,
                            UserPicture = imageid
                        };
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(dataGridView1, id, name, surname, gender, education, birthDate, imageid);
                        dataGridView1.Rows.Add(row);
                        Logger.Info("Kullanıcı verileri bulundu.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı verileri bulunamadı veya dosya boş.");
                Logger.Error("Kullanıcı verileri bulunamadı veya dosya boş.");
            }
        }


        public class User
        {

            public string Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Gender { get; set; }
            public string Education { get; set; }
            public string SvgFilename { get; set; }
            public string BirthDate { get; set; }
            public string UserPicture { get; set; }

        }
    }
}
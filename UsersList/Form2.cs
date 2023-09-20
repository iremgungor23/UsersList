using System;
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

namespace UsersList
{
    public partial class Form2 : Form
    {
        private object _userList;

        public Form2()
        {
            InitializeComponent();
            
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
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
                    //pdfHucresi.BackgroundColor = Color.AliceBlue;
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
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //bu kısımda user.json oku ve dgv'w yazdır
            string jsonFilePath = Application.StartupPath + "\\UsersList\\users.json";


            List<User> users = new List<User>();
            if (!File.Exists(jsonFilePath))
            {
                string jsonContent = File.ReadAllText(jsonFilePath);

                users = JsonConvert.DeserializeObject<List<User>>(jsonContent);
            }

            dataGridView1.DataSource = users;
        }


        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Gender { get; set; }
            public string Education { get; set; }
            public string BirthDate { get; set; }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}




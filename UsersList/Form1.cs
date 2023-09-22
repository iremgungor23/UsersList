using System.Security.Cryptography;
using Microsoft.VisualBasic.ApplicationServices;
using Newtonsoft.Json;
using System.Reflection.Metadata.Ecma335;
using System.Security.Policy;
using System.Xml.Linq;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text.pdf.parser;
using Path = System.IO.Path;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Net.Http;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using iTextSharp.xmp.impl;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

namespace UsersList
{
    public partial class Form1 : Form
    {
        private int _id = 0;
        private string _selectedImageFileName;


        public Form1()
        {
            InitializeComponent();
        }





        private string GetSelectedGender()
        {
            if (rdBtnFemale.Checked)
            {
                return "Erkek";
            }
            else if (rdBtnMale.Checked)
            {
                return "Kad?n";
            }
            else
            {
                return "Belirtilmemi?";
            }
        }






        private void DrawImageToSvg(string imagePath, string svgPath)
        {
            Bitmap bitmap = new Bitmap(imagePath);

            XmlDocument svgDocument = new XmlDocument();
            XmlDeclaration xmlDeclaration = svgDocument.CreateXmlDeclaration("1.0", "UTF-8", null);
            svgDocument.AppendChild(xmlDeclaration);

            XmlElement svgElement = svgDocument.CreateElement("svg");
            svgElement.SetAttribute("xmlns", "http://www.w3.org/2000/svg");
            svgElement.SetAttribute("width", bitmap.Width.ToString());
            svgElement.SetAttribute("height", bitmap.Height.ToString());
            svgDocument.AppendChild(svgElement);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                byte[] imageBytes = memoryStream.ToArray();

                string base64Image = Convert.ToBase64String(imageBytes);
                XmlElement imageElement = svgDocument.CreateElement("image");
                imageElement.SetAttribute("width", bitmap.Width.ToString());
                imageElement.SetAttribute("height", bitmap.Height.ToString());
                imageElement.SetAttribute("xlink:href", "data:image/png;base64," + base64Image);
                svgElement.AppendChild(imageElement);
            }

            svgDocument.Save(svgPath);
        }




        private void btnUserList_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();

        }


        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Gender { get; set; }
            public string Education { get; set; }
            public string BirthDate { get; set; }
            public string UserPicture { get; set; }
        }

        private List<User> LoadUsersFromJson(string filePath)
        {
            List<User> users = new List<User>();

            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);

                users = JsonConvert.DeserializeObject<List<User>>(jsonData);
            }

            return users;
        }

        private void SaveUsersToJson(string filePath, List<User> users)
        {
            string jsonData = JsonConvert.SerializeObject(users);
            File.WriteAllText(filePath, jsonData);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var _jsonFilePath = Path.Combine(Application.StartupPath, "UsersList", "users.json");

            string name = txtBoxName.Text;
            string surname = txtBoxSurname.Text;
            string gender = GetSelectedGender();
            string education = cmbBoxEducation.SelectedItem.ToString();
            DateTime birthDate = dateTimePicker1.Value;

            if (!Directory.Exists(Path.GetDirectoryName(_jsonFilePath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(_jsonFilePath));
            }

            List<User> users = LoadUsersFromJson(_jsonFilePath);

            int maxId = users.Count > 0 ? users.Max(u => u.Id) : 0;

            User newUser = new User
            {
                Id = maxId + 1,
                Name = name,
                Surname = surname,
                Gender = gender,
                Education = education,
                BirthDate = birthDate.ToShortDateString(),
                UserPicture = _selectedImageFileName
            };

            users.Add(newUser);
            SaveUsersToJson(_jsonFilePath, users);

            string message = $"{name} {surname} kişisi eklendi.\nCinsiyet: {gender}\nEğitim: {education}\nDoğum Tarihi: {birthDate.ToShortDateString()}";
            MessageBox.Show(message, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnImages_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string fileName = Path.GetFileNameWithoutExtension(filePath);

                string startPath = Application.StartupPath;
                string imagesFolder = Path.Combine(Application.StartupPath, "Images");

                // SVG dosyasını kaydet
                string svgFolderPath = Path.Combine(imagesFolder, "SVG");
                Directory.CreateDirectory(svgFolderPath);
                string svgTargetPath = Path.Combine(svgFolderPath, fileName + ".svg");
                DrawImageToSvg(filePath, svgTargetPath);

                string pngFolderPath = Path.Combine(imagesFolder, "PNG");
                Directory.CreateDirectory(pngFolderPath);
                string pngTargetPath = Path.Combine(pngFolderPath, fileName + ".png");
                File.Copy(filePath, pngTargetPath, true);

                MessageBox.Show("SVG dosyası oluşturuldu ve PNG formatında resim başarıyla kaydedildi!");
                _selectedImageFileName = fileName + ".svg"; // Seçilen resmin adını kaydet
                File.WriteAllText("users.json", _selectedImageFileName);

                pctrBoxImages.Image = Image.FromFile(filePath);
            }
        }

    }
}

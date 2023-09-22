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

namespace UsersList
{
    public partial class Form1 : Form
    {
        private int _id = 0;
 

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

                // PNG dosyasını kaydet
                string pngFolderPath = Path.Combine(imagesFolder, "PNG");
                Directory.CreateDirectory(pngFolderPath);
                string pngTargetPath = Path.Combine(pngFolderPath, fileName + ".png");
                File.Copy(filePath, pngTargetPath, true); // Resmi kopyala

                MessageBox.Show("SVG dosyası oluşturuldu ve PNG formatında resim başarıyla kaydedildi!");
                string userPicture = fileName + ".svg"; // SVG dosyasının adını kaydet
                File.WriteAllText("users.json", userPicture);

                pctrBoxImages.Image = Image.FromFile(filePath);
            }

        }



        private void DrawImageToSvg(string imagePath, string svgPath)
        {
            // Kullanıcıdan seçilen resmi yükle
            Bitmap bitmap = new Bitmap(imagePath);

            // SVG belgesi oluştur
            XmlDocument svgDocument = new XmlDocument();
            XmlDeclaration xmlDeclaration = svgDocument.CreateXmlDeclaration("1.0", "UTF-8", null);
            svgDocument.AppendChild(xmlDeclaration);

            // <svg> elementini oluştur
            XmlElement svgElement = svgDocument.CreateElement("svg");
            svgElement.SetAttribute("xmlns", "http://www.w3.org/2000/svg");
            svgElement.SetAttribute("width", bitmap.Width.ToString());
            svgElement.SetAttribute("height", bitmap.Height.ToString());
            svgDocument.AppendChild(svgElement);

            // Resmi SVG'ye dönüştür
            using (MemoryStream memoryStream = new MemoryStream())
            {
                bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                byte[] imageBytes = memoryStream.ToArray();

                // Resmi SVG belgesine ekleyin
                string base64Image = Convert.ToBase64String(imageBytes);
                XmlElement imageElement = svgDocument.CreateElement("image");
                imageElement.SetAttribute("width", bitmap.Width.ToString());
                imageElement.SetAttribute("height", bitmap.Height.ToString());
                imageElement.SetAttribute("xlink:href", "data:image/png;base64," + base64Image);
                svgElement.AppendChild(imageElement);
            }

            // SVG belgesini kaydet
            svgDocument.Save(svgPath);
        }



        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Gender { get; set; }
            public string Education { get; set; }
            public string BirthDate { get; set; }
            public string Image { get; set; }
        }

        private void btnUserList_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var _jsonFilePath = Path.Combine(Application.StartupPath + "UsersList" , "user.json");
             // Kullanıcıdan verileri al
            string name = txtBoxName.Text;
            string surname = txtBoxSurname.Text;
            string gender = GetSelectedGender();
            string education = cmbBoxEducation.SelectedItem.ToString();
            DateTime birthDate = dateTimePicker1.Value;

            // Mevcut JSON dosyasını oku (varsa)
 
            // Yeni veriyi oluştur
            User newUser = new User
            {
                Id = ++_id,
                Name = name,
                Surname = surname,
                Gender = gender,
                Education = education,
                BirthDate = birthDate.ToShortDateString(),
                //Image =
            };

 
            // Listeyi JSON formatına çevir
            string jsonData = JsonConvert.SerializeObject(newUser);

            // JSON dosyasını güncelle
            File.WriteAllText(_jsonFilePath, jsonData);

            // Kullanıcıya bilgi göster
            string message = $" {_jsonFilePath},{name} {surname} kişisi eklendi.\nCinsiyet: {gender}\nEğitim: {education}\nDoğum Tarihi: {birthDate.ToShortDateString()}";
            MessageBox.Show(message, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}

namespace UsersList
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtBoxName = new TextBox();
            txtBoxSurname = new TextBox();
            lblName = new Label();
            lblSurname = new Label();
            rdBtnFemale = new RadioButton();
            rdBtnMale = new RadioButton();
            cmbBoxEducation = new ComboBox();
            dateTimePicker1 = new DateTimePicker();
            btnAdd = new Button();
            btnUserList = new Button();
            btnImages = new Button();
            pctrBoxImages = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pctrBoxImages).BeginInit();
            SuspendLayout();
            // 
            // txtBoxName
            // 
            txtBoxName.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtBoxName.Location = new Point(175, 42);
            txtBoxName.Name = "txtBoxName";
            txtBoxName.Size = new Size(148, 31);
            txtBoxName.TabIndex = 0;
            // 
            // txtBoxSurname
            // 
            txtBoxSurname.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtBoxSurname.Location = new Point(175, 100);
            txtBoxSurname.Name = "txtBoxSurname";
            txtBoxSurname.Size = new Size(148, 31);
            txtBoxSurname.TabIndex = 1;
            // 
            // lblName
            // 
            lblName.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblName.AutoSize = true;
            lblName.Location = new Point(42, 48);
            lblName.Name = "lblName";
            lblName.Size = new Size(37, 25);
            lblName.TabIndex = 2;
            lblName.Text = "AD";
            // 
            // lblSurname
            // 
            lblSurname.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblSurname.AutoSize = true;
            lblSurname.Location = new Point(42, 106);
            lblSurname.Name = "lblSurname";
            lblSurname.Size = new Size(70, 25);
            lblSurname.TabIndex = 3;
            lblSurname.Text = "SOYAD";
            // 
            // rdBtnFemale
            // 
            rdBtnFemale.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rdBtnFemale.AutoSize = true;
            rdBtnFemale.Location = new Point(42, 177);
            rdBtnFemale.Name = "rdBtnFemale";
            rdBtnFemale.Size = new Size(81, 29);
            rdBtnFemale.TabIndex = 4;
            rdBtnFemale.TabStop = true;
            rdBtnFemale.Text = "Kadın";
            rdBtnFemale.UseVisualStyleBackColor = true;
            // 
            // rdBtnMale
            // 
            rdBtnMale.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rdBtnMale.AutoSize = true;
            rdBtnMale.Location = new Point(42, 243);
            rdBtnMale.Name = "rdBtnMale";
            rdBtnMale.Size = new Size(79, 29);
            rdBtnMale.TabIndex = 5;
            rdBtnMale.TabStop = true;
            rdBtnMale.Text = "Erkek";
            rdBtnMale.UseVisualStyleBackColor = true;
            // 
            // cmbBoxEducation
            // 
            cmbBoxEducation.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cmbBoxEducation.FormattingEnabled = true;
            cmbBoxEducation.Items.AddRange(new object[] { "İlkokul", "Ortaokul", "Lise", "Üniversite" });
            cmbBoxEducation.Location = new Point(42, 319);
            cmbBoxEducation.Name = "cmbBoxEducation";
            cmbBoxEducation.Size = new Size(339, 33);
            cmbBoxEducation.TabIndex = 6;
            cmbBoxEducation.Text = "Eğitim";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dateTimePicker1.Location = new Point(42, 397);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(339, 31);
            dateTimePicker1.TabIndex = 7;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAdd.Location = new Point(720, 397);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(311, 31);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "Ekle";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUserList
            // 
            btnUserList.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnUserList.Location = new Point(720, 335);
            btnUserList.Name = "btnUserList";
            btnUserList.Size = new Size(311, 33);
            btnUserList.TabIndex = 9;
            btnUserList.Text = "Kullanıcı Listesi";
            btnUserList.UseVisualStyleBackColor = true;
            btnUserList.Click += btnUserList_Click;
            // 
            // btnImages
            // 
            btnImages.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnImages.Location = new Point(720, 268);
            btnImages.Name = "btnImages";
            btnImages.Size = new Size(311, 31);
            btnImages.TabIndex = 10;
            btnImages.Text = "Resim Ekle";
            btnImages.UseVisualStyleBackColor = true;
            btnImages.Click += btnImages_Click;
            // 
            // pctrBoxImages
            // 
            pctrBoxImages.Location = new Point(720, 42);
            pctrBoxImages.Name = "pctrBoxImages";
            pctrBoxImages.Size = new Size(311, 174);
            pctrBoxImages.SizeMode = PictureBoxSizeMode.StretchImage;
            pctrBoxImages.TabIndex = 11;
            pctrBoxImages.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1171, 502);
            Controls.Add(pctrBoxImages);
            Controls.Add(btnImages);
            Controls.Add(btnUserList);
            Controls.Add(btnAdd);
            Controls.Add(dateTimePicker1);
            Controls.Add(cmbBoxEducation);
            Controls.Add(rdBtnMale);
            Controls.Add(rdBtnFemale);
            Controls.Add(lblSurname);
            Controls.Add(lblName);
            Controls.Add(txtBoxSurname);
            Controls.Add(txtBoxName);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pctrBoxImages).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBoxName;
        private TextBox txtBoxSurname;
        private Label lblName;
        private Label lblSurname;
        private RadioButton rdBtnFemale;
        private RadioButton rdBtnMale;
        private ComboBox cmbBoxEducation;
        private DateTimePicker dateTimePicker1;
        private Button btnAdd;
        private Button btnUserList;
        private Button btnImages;
        private PictureBox pctrBoxImages;
    }
}
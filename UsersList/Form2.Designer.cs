namespace UsersList
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            clmnorder = new DataGridViewTextBoxColumn();
            clmnName = new DataGridViewTextBoxColumn();
            clmnSurname = new DataGridViewTextBoxColumn();
            clmnGender = new DataGridViewTextBoxColumn();
            clmnEducation = new DataGridViewTextBoxColumn();
            cmlnBirthDate = new DataGridViewTextBoxColumn();
            clmnImage = new DataGridViewButtonColumn();
            btnExport = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { clmnorder, clmnName, clmnSurname, clmnGender, clmnEducation, cmlnBirthDate, clmnImage });
            dataGridView1.Location = new Point(35, 43);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowTemplate.Height = 33;
            dataGridView1.Size = new Size(1152, 281);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // clmnorder
            // 
            clmnorder.HeaderText = "order";
            clmnorder.MinimumWidth = 8;
            clmnorder.Name = "clmnorder";
            clmnorder.Width = 150;
            // 
            // clmnName
            // 
            clmnName.HeaderText = "name";
            clmnName.MinimumWidth = 8;
            clmnName.Name = "clmnName";
            clmnName.Width = 150;
            // 
            // clmnSurname
            // 
            clmnSurname.HeaderText = "Surname";
            clmnSurname.MinimumWidth = 8;
            clmnSurname.Name = "clmnSurname";
            clmnSurname.Width = 150;
            // 
            // clmnGender
            // 
            clmnGender.HeaderText = "Gender";
            clmnGender.MinimumWidth = 8;
            clmnGender.Name = "clmnGender";
            clmnGender.Width = 150;
            // 
            // clmnEducation
            // 
            clmnEducation.HeaderText = "education";
            clmnEducation.MinimumWidth = 8;
            clmnEducation.Name = "clmnEducation";
            clmnEducation.Width = 150;
            // 
            // cmlnBirthDate
            // 
            cmlnBirthDate.HeaderText = "BirthDate";
            cmlnBirthDate.MinimumWidth = 8;
            cmlnBirthDate.Name = "cmlnBirthDate";
            cmlnBirthDate.Width = 150;
            // 
            // clmnImage
            // 
            clmnImage.HeaderText = "Image";
            clmnImage.MinimumWidth = 8;
            clmnImage.Name = "clmnImage";
            clmnImage.Resizable = DataGridViewTriState.True;
            clmnImage.SortMode = DataGridViewColumnSortMode.Automatic;
            clmnImage.Width = 150;
            // 
            // btnExport
            // 
            btnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExport.Location = new Point(942, 383);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(187, 34);
            btnExport.TabIndex = 1;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1199, 476);
            Controls.Add(btnExport);
            Controls.Add(dataGridView1);
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form2";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btnExport;
        private DataGridViewTextBoxColumn clmnorder;
        private DataGridViewTextBoxColumn clmnName;
        private DataGridViewTextBoxColumn clmnSurname;
        private DataGridViewTextBoxColumn clmnGender;
        private DataGridViewTextBoxColumn clmnEducation;
        private DataGridViewTextBoxColumn cmlnBirthDate;
        private DataGridViewButtonColumn clmnImage;
    }
}
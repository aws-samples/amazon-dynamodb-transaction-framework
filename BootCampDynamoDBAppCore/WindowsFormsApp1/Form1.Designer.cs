namespace BootCampDynamoDB
{
    partial class Form1
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
            productTypeLbl = new System.Windows.Forms.Label();
            bookAuthor = new System.Windows.Forms.TextBox();
            attribute1Lbl = new System.Windows.Forms.Label();
            attribute2Lbl = new System.Windows.Forms.Label();
            title = new System.Windows.Forms.TextBox();
            attribute3Lbl = new System.Windows.Forms.Label();
            movieGenre = new System.Windows.Forms.TextBox();
            attribute4Lbl = new System.Windows.Forms.Label();
            putItemBtn = new System.Windows.Forms.Button();
            getItemBtn = new System.Windows.Forms.Button();
            bookPublishDate = new System.Windows.Forms.DateTimePicker();
            movieDirector = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            albumArtist = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            deleteItemBtn = new System.Windows.Forms.Button();
            productType = new System.Windows.Forms.ComboBox();
            errorMessage = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            createTableBtn = new System.Windows.Forms.Button();
            beginTransactionBtn = new System.Windows.Forms.Button();
            commitTransactionBtn = new System.Windows.Forms.Button();
            cancelTransactionBtn = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // productTypeLbl
            // 
            productTypeLbl.AutoSize = true;
            productTypeLbl.Location = new System.Drawing.Point(31, 25);
            productTypeLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            productTypeLbl.Name = "productTypeLbl";
            productTypeLbl.Size = new System.Drawing.Size(98, 20);
            productTypeLbl.TabIndex = 4;
            productTypeLbl.Text = "Product Type:";
            // 
            // bookAuthor
            // 
            bookAuthor.Location = new System.Drawing.Point(173, 109);
            bookAuthor.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            bookAuthor.Name = "bookAuthor";
            bookAuthor.Size = new System.Drawing.Size(325, 27);
            bookAuthor.TabIndex = 5;
            // 
            // attribute1Lbl
            // 
            attribute1Lbl.AutoSize = true;
            attribute1Lbl.Location = new System.Drawing.Point(31, 111);
            attribute1Lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            attribute1Lbl.Name = "attribute1Lbl";
            attribute1Lbl.Size = new System.Drawing.Size(95, 20);
            attribute1Lbl.TabIndex = 6;
            attribute1Lbl.Text = "Book Author:";
            // 
            // attribute2Lbl
            // 
            attribute2Lbl.AutoSize = true;
            attribute2Lbl.Location = new System.Drawing.Point(31, 237);
            attribute2Lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            attribute2Lbl.Name = "attribute2Lbl";
            attribute2Lbl.Size = new System.Drawing.Size(133, 20);
            attribute2Lbl.TabIndex = 8;
            attribute2Lbl.Text = "Book Publish Date:";
            attribute2Lbl.Click += attribute2Lbl_Click;
            // 
            // title
            // 
            title.Location = new System.Drawing.Point(173, 193);
            title.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            title.Name = "title";
            title.Size = new System.Drawing.Size(325, 27);
            title.TabIndex = 7;
            // 
            // attribute3Lbl
            // 
            attribute3Lbl.AutoSize = true;
            attribute3Lbl.Location = new System.Drawing.Point(31, 195);
            attribute3Lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            attribute3Lbl.Name = "attribute3Lbl";
            attribute3Lbl.Size = new System.Drawing.Size(41, 20);
            attribute3Lbl.TabIndex = 10;
            attribute3Lbl.Text = "Title:";
            // 
            // movieGenre
            // 
            movieGenre.Location = new System.Drawing.Point(173, 281);
            movieGenre.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            movieGenre.Name = "movieGenre";
            movieGenre.Size = new System.Drawing.Size(325, 27);
            movieGenre.TabIndex = 9;
            // 
            // attribute4Lbl
            // 
            attribute4Lbl.AutoSize = true;
            attribute4Lbl.Location = new System.Drawing.Point(31, 281);
            attribute4Lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            attribute4Lbl.Name = "attribute4Lbl";
            attribute4Lbl.Size = new System.Drawing.Size(96, 20);
            attribute4Lbl.TabIndex = 12;
            attribute4Lbl.Text = "Movie Genre:";
            // 
            // putItemBtn
            // 
            putItemBtn.Location = new System.Drawing.Point(70, 519);
            putItemBtn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            putItemBtn.Name = "putItemBtn";
            putItemBtn.Size = new System.Drawing.Size(89, 34);
            putItemBtn.TabIndex = 13;
            putItemBtn.Text = "Add Item";
            putItemBtn.UseVisualStyleBackColor = true;
            putItemBtn.Click += putItemBtn_Click;
            // 
            // getItemBtn
            // 
            getItemBtn.Location = new System.Drawing.Point(170, 519);
            getItemBtn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            getItemBtn.Name = "getItemBtn";
            getItemBtn.Size = new System.Drawing.Size(113, 34);
            getItemBtn.TabIndex = 14;
            getItemBtn.Text = "Retrieve Item";
            getItemBtn.UseVisualStyleBackColor = true;
            getItemBtn.Click += getItemBtn_Click;
            // 
            // bookPublishDate
            // 
            bookPublishDate.Location = new System.Drawing.Point(173, 237);
            bookPublishDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            bookPublishDate.Name = "bookPublishDate";
            bookPublishDate.Size = new System.Drawing.Size(325, 27);
            bookPublishDate.TabIndex = 8;
            bookPublishDate.ValueChanged += bookPublishDate_ValueChanged;
            // 
            // movieDirector
            // 
            movieDirector.Location = new System.Drawing.Point(173, 150);
            movieDirector.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            movieDirector.Name = "movieDirector";
            movieDirector.Size = new System.Drawing.Size(325, 27);
            movieDirector.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(31, 152);
            label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(111, 20);
            label1.TabIndex = 17;
            label1.Text = "Movie Director:";
            // 
            // albumArtist
            // 
            albumArtist.Location = new System.Drawing.Point(173, 67);
            albumArtist.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            albumArtist.Name = "albumArtist";
            albumArtist.Size = new System.Drawing.Size(325, 27);
            albumArtist.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(31, 69);
            label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(95, 20);
            label2.TabIndex = 19;
            label2.Text = "Album Artist:";
            // 
            // deleteItemBtn
            // 
            deleteItemBtn.Location = new System.Drawing.Point(294, 519);
            deleteItemBtn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            deleteItemBtn.Name = "deleteItemBtn";
            deleteItemBtn.Size = new System.Drawing.Size(107, 34);
            deleteItemBtn.TabIndex = 15;
            deleteItemBtn.Text = "Remove Item";
            deleteItemBtn.UseVisualStyleBackColor = true;
            deleteItemBtn.Click += deleteItemBtn_Click;
            // 
            // productType
            // 
            productType.FormattingEnabled = true;
            productType.Items.AddRange(new object[] { "Album", "Book", "Movie" });
            productType.Location = new System.Drawing.Point(173, 26);
            productType.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            productType.Name = "productType";
            productType.Size = new System.Drawing.Size(318, 28);
            productType.TabIndex = 3;
            productType.SelectedIndexChanged += productType_SelectedIndexChanged;
            // 
            // errorMessage
            // 
            errorMessage.Location = new System.Drawing.Point(173, 325);
            errorMessage.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            errorMessage.Multiline = true;
            errorMessage.Name = "errorMessage";
            errorMessage.Size = new System.Drawing.Size(325, 79);
            errorMessage.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(31, 325);
            label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(137, 20);
            label3.TabIndex = 23;
            label3.Text = "Response Message:";
            // 
            // createTableBtn
            // 
            createTableBtn.Location = new System.Drawing.Point(31, 426);
            createTableBtn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            createTableBtn.Name = "createTableBtn";
            createTableBtn.Size = new System.Drawing.Size(318, 34);
            createTableBtn.TabIndex = 11;
            createTableBtn.Text = "Create Product Tables (Book, Album, Movie)";
            createTableBtn.UseVisualStyleBackColor = true;
            createTableBtn.Click += createTableBtn_Click;
            // 
            // beginTransactionBtn
            // 
            beginTransactionBtn.Location = new System.Drawing.Point(31, 472);
            beginTransactionBtn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            beginTransactionBtn.Name = "beginTransactionBtn";
            beginTransactionBtn.Size = new System.Drawing.Size(186, 34);
            beginTransactionBtn.TabIndex = 12;
            beginTransactionBtn.Text = "Begin Transaction (0)";
            beginTransactionBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            beginTransactionBtn.UseVisualStyleBackColor = true;
            beginTransactionBtn.Click += beginTransactionBtn_Click;
            // 
            // commitTransactionBtn
            // 
            commitTransactionBtn.Enabled = false;
            commitTransactionBtn.Location = new System.Drawing.Point(32, 570);
            commitTransactionBtn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            commitTransactionBtn.Name = "commitTransactionBtn";
            commitTransactionBtn.Size = new System.Drawing.Size(185, 34);
            commitTransactionBtn.TabIndex = 16;
            commitTransactionBtn.Text = "Commit Transaction (0)";
            commitTransactionBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            commitTransactionBtn.UseVisualStyleBackColor = true;
            commitTransactionBtn.Click += commitTransactionBtn_Click;
            // 
            // cancelTransactionBtn
            // 
            cancelTransactionBtn.Enabled = false;
            cancelTransactionBtn.Location = new System.Drawing.Point(31, 618);
            cancelTransactionBtn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            cancelTransactionBtn.Name = "cancelTransactionBtn";
            cancelTransactionBtn.Size = new System.Drawing.Size(186, 34);
            cancelTransactionBtn.TabIndex = 17;
            cancelTransactionBtn.Text = "Rollback Transaction (0)";
            cancelTransactionBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            cancelTransactionBtn.UseVisualStyleBackColor = true;
            cancelTransactionBtn.Click += cancelTransactionBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(529, 672);
            Controls.Add(cancelTransactionBtn);
            Controls.Add(commitTransactionBtn);
            Controls.Add(beginTransactionBtn);
            Controls.Add(createTableBtn);
            Controls.Add(errorMessage);
            Controls.Add(label3);
            Controls.Add(productType);
            Controls.Add(deleteItemBtn);
            Controls.Add(albumArtist);
            Controls.Add(label2);
            Controls.Add(movieDirector);
            Controls.Add(label1);
            Controls.Add(bookPublishDate);
            Controls.Add(getItemBtn);
            Controls.Add(putItemBtn);
            Controls.Add(movieGenre);
            Controls.Add(attribute4Lbl);
            Controls.Add(title);
            Controls.Add(attribute3Lbl);
            Controls.Add(attribute2Lbl);
            Controls.Add(bookAuthor);
            Controls.Add(attribute1Lbl);
            Controls.Add(productTypeLbl);
            Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            Name = "Form1";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "DynamoDB Transaction Example";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label productTypeLbl;
        private System.Windows.Forms.TextBox bookAuthor;
        private System.Windows.Forms.Label attribute1Lbl;
        private System.Windows.Forms.Label attribute2Lbl;
        private System.Windows.Forms.TextBox title;
        private System.Windows.Forms.Label attribute3Lbl;
        private System.Windows.Forms.TextBox movieGenre;
        private System.Windows.Forms.Label attribute4Lbl;
        private System.Windows.Forms.Button putItemBtn;
        private System.Windows.Forms.Button getItemBtn;
        private System.Windows.Forms.DateTimePicker bookPublishDate;
        private System.Windows.Forms.TextBox movieDirector;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox albumArtist;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button deleteItemBtn;
        private System.Windows.Forms.ComboBox productType;
        private System.Windows.Forms.TextBox errorMessage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button createTableBtn;
        private System.Windows.Forms.Button beginTransactionBtn;
        private System.Windows.Forms.Button commitTransactionBtn;
        private System.Windows.Forms.Button cancelTransactionBtn;
    }
}


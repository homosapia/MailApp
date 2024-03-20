namespace PostalService
{
    partial class ViewingLetter
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
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            login = new TextBox();
            label2 = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            label3 = new Label();
            password = new TextBox();
            button1 = new Button();
            label4 = new Label();
            tableLayoutPanel4 = new TableLayoutPanel();
            incomingIMAP = new TextBox();
            label5 = new Label();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(label1, 1, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 1, 2);
            tableLayoutPanel1.Controls.Add(button1, 1, 3);
            tableLayoutPanel1.Controls.Add(label4, 2, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel4, 2, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));
            tableLayoutPanel1.Size = new Size(449, 254);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            label1.Location = new Point(23, 0);
            label1.Name = "label1";
            label1.Size = new Size(198, 40);
            label1.TabIndex = 0;
            label1.Text = "Добавление сотрудника";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(login, 0, 2);
            tableLayoutPanel2.Controls.Add(label2, 0, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(23, 43);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 7.47663546F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 39.1304359F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 53.623188F));
            tableLayoutPanel2.Size = new Size(198, 69);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // login
            // 
            login.Dock = DockStyle.Fill;
            login.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            login.Location = new Point(3, 34);
            login.Name = "login";
            login.Size = new Size(192, 33);
            login.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 14F);
            label2.Location = new Point(3, 5);
            label2.Name = "label2";
            label2.Size = new Size(192, 26);
            label2.TabIndex = 1;
            label2.Text = "Введите адрес почты";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(label3, 0, 1);
            tableLayoutPanel3.Controls.Add(password, 0, 2);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(23, 118);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 3;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 7.47663546F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 37.38318F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 55.1401863F));
            tableLayoutPanel3.Size = new Size(198, 69);
            tableLayoutPanel3.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(3, 5);
            label3.Name = "label3";
            label3.Size = new Size(192, 25);
            label3.TabIndex = 0;
            label3.Text = "Введите пароль почты";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // password
            // 
            password.Dock = DockStyle.Fill;
            password.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            password.Location = new Point(3, 33);
            password.Name = "password";
            password.Size = new Size(192, 33);
            password.TabIndex = 1;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Top;
            button1.Font = new Font("Segoe UI", 14F);
            button1.Location = new Point(23, 193);
            button1.Name = "button1";
            button1.Size = new Size(198, 50);
            button1.TabIndex = 3;
            button1.Text = "Добавить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.Location = new Point(227, 0);
            label4.Name = "label4";
            label4.Size = new Size(198, 40);
            label4.TabIndex = 4;
            label4.Text = "Почтовый сервер";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(incomingIMAP, 0, 1);
            tableLayoutPanel4.Controls.Add(label5, 0, 0);
            tableLayoutPanel4.Location = new Point(227, 43);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 43.47826F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 56.52174F));
            tableLayoutPanel4.Size = new Size(198, 69);
            tableLayoutPanel4.TabIndex = 5;
            // 
            // incomingIMAP
            // 
            incomingIMAP.Dock = DockStyle.Fill;
            incomingIMAP.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            incomingIMAP.Location = new Point(3, 33);
            incomingIMAP.Name = "incomingIMAP";
            incomingIMAP.Size = new Size(192, 33);
            incomingIMAP.TabIndex = 0;
            incomingIMAP.Text = "imap.mail.ru";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label5.Location = new Point(3, 0);
            label5.Name = "label5";
            label5.Size = new Size(192, 30);
            label5.TabIndex = 1;
            label5.Text = "Входящий (IMAP)";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ViewingLetter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(449, 254);
            Controls.Add(tableLayoutPanel1);
            Name = "ViewingLetter";
            Text = "ViewingLetter";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel2;
        private TextBox login;
        private Label label2;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label3;
        private TextBox password;
        private Button button1;
        private Label label4;
        private TableLayoutPanel tableLayoutPanel4;
        private TextBox incomingIMAP;
        private Label label5;
    }
}
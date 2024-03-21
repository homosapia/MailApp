namespace PostalService
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
            splitContainer1 = new SplitContainer();
            tableLayoutPanel1 = new TableLayoutPanel();
            AddEmployee = new Button();
            employees = new ListBox();
            splitContainer2 = new SplitContainer();
            tableLayoutPanel4 = new TableLayoutPanel();
            letters = new ListBox();
            button1 = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            letterTitle = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            emailSenderName = new Label();
            emailRecipientName = new Label();
            letterDate = new Label();
            richTextBox1 = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(789, 460);
            splitContainer1.SplitterDistance = 143;
            splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(AddEmployee, 0, 0);
            tableLayoutPanel1.Controls.Add(employees, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(143, 460);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // AddEmployee
            // 
            AddEmployee.Dock = DockStyle.Fill;
            AddEmployee.Location = new Point(3, 3);
            AddEmployee.Name = "AddEmployee";
            AddEmployee.Size = new Size(137, 44);
            AddEmployee.TabIndex = 0;
            AddEmployee.Text = "Добавить сотрудника";
            AddEmployee.UseVisualStyleBackColor = true;
            AddEmployee.Click += AddEmployee_Click;
            // 
            // employees
            // 
            employees.Dock = DockStyle.Fill;
            employees.Font = new Font("Segoe UI", 14F);
            employees.FormattingEnabled = true;
            employees.ItemHeight = 25;
            employees.Location = new Point(3, 53);
            employees.Name = "employees";
            employees.Size = new Size(137, 404);
            employees.TabIndex = 1;
            employees.SelectedIndexChanged += employees_SelectedIndexChanged;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(tableLayoutPanel4);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(tableLayoutPanel2);
            splitContainer2.Size = new Size(642, 460);
            splitContainer2.SplitterDistance = 171;
            splitContainer2.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Controls.Add(letters, 0, 0);
            tableLayoutPanel4.Controls.Add(button1, 0, 1);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(0, 0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.Size = new Size(171, 460);
            tableLayoutPanel4.TabIndex = 0;
            // 
            // letters
            // 
            letters.Dock = DockStyle.Fill;
            letters.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            letters.FormattingEnabled = true;
            letters.ItemHeight = 25;
            letters.Location = new Point(3, 3);
            letters.Name = "letters";
            letters.Size = new Size(165, 414);
            letters.TabIndex = 1;
            letters.SelectedIndexChanged += letters_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Fill;
            button1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button1.Location = new Point(3, 423);
            button1.Name = "button1";
            button1.Size = new Size(165, 34);
            button1.TabIndex = 2;
            button1.Text = "Обновить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += UpdatingLettersList_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(letterTitle, 0, 0);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 1);
            tableLayoutPanel2.Controls.Add(letterDate, 0, 3);
            tableLayoutPanel2.Controls.Add(richTextBox1, 0, 2);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 4;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 69F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(467, 460);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // letterTitle
            // 
            letterTitle.AutoSize = true;
            letterTitle.Dock = DockStyle.Fill;
            letterTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            letterTitle.Location = new Point(3, 0);
            letterTitle.Name = "letterTitle";
            letterTitle.Size = new Size(461, 80);
            letterTitle.TabIndex = 0;
            letterTitle.Text = "Титул письма";
            letterTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(label1, 0, 0);
            tableLayoutPanel3.Controls.Add(label2, 1, 0);
            tableLayoutPanel3.Controls.Add(emailSenderName, 0, 1);
            tableLayoutPanel3.Controls.Add(emailRecipientName, 1, 1);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 83);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 66.6666641F));
            tableLayoutPanel3.Size = new Size(461, 63);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(224, 21);
            label1.TabIndex = 0;
            label1.Text = "от кого";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(233, 0);
            label2.Name = "label2";
            label2.Size = new Size(225, 21);
            label2.TabIndex = 1;
            label2.Text = "кому";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // emailSenderName
            // 
            emailSenderName.AutoSize = true;
            emailSenderName.Dock = DockStyle.Fill;
            emailSenderName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            emailSenderName.Location = new Point(3, 21);
            emailSenderName.Name = "emailSenderName";
            emailSenderName.Size = new Size(224, 42);
            emailSenderName.TabIndex = 2;
            emailSenderName.Text = "Имя отправителя";
            emailSenderName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // emailRecipientName
            // 
            emailRecipientName.AutoSize = true;
            emailRecipientName.Dock = DockStyle.Fill;
            emailRecipientName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            emailRecipientName.Location = new Point(233, 21);
            emailRecipientName.Name = "emailRecipientName";
            emailRecipientName.Size = new Size(225, 42);
            emailRecipientName.TabIndex = 3;
            emailRecipientName.Text = "Имя получателя";
            emailRecipientName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // letterDate
            // 
            letterDate.AutoSize = true;
            letterDate.Dock = DockStyle.Fill;
            letterDate.Location = new Point(3, 440);
            letterDate.Name = "letterDate";
            letterDate.Size = new Size(461, 20);
            letterDate.TabIndex = 2;
            letterDate.Text = "дата время";
            letterDate.TextAlign = ContentAlignment.TopCenter;
            // 
            // richTextBox1
            // 
            richTextBox1.Dock = DockStyle.Fill;
            richTextBox1.Location = new Point(3, 152);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(461, 285);
            richTextBox1.TabIndex = 3;
            richTextBox1.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(789, 460);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private TableLayoutPanel tableLayoutPanel1;
        private Button AddEmployee;
        private ListBox employees;
        private SplitContainer splitContainer2;
        private TableLayoutPanel tableLayoutPanel2;
        private Label letterTitle;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label1;
        private Label label2;
        private Label emailSenderName;
        private Label letterDate;
        private Label emailRecipientName;
        private TableLayoutPanel tableLayoutPanel4;
        private ListBox letters;
        private Button button1;
        private RichTextBox richTextBox1;
    }
}

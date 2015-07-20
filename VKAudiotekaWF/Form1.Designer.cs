namespace VKAudiotekaWF
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.userText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.passText = new System.Windows.Forms.TextBox();
            this.up = new System.Windows.Forms.Button();
            this.albumsListBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.enterBut = new System.Windows.Forms.Button();
            this.groupsListBox = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.prev50 = new System.Windows.Forms.Button();
            this.enterLabel = new System.Windows.Forms.Label();
            this.next50 = new System.Windows.Forms.Button();
            this.urlidCheckBox = new System.Windows.Forms.CheckBox();
            this.urlidTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // userText
            // 
            this.userText.Location = new System.Drawing.Point(12, 29);
            this.userText.Name = "userText";
            this.userText.Size = new System.Drawing.Size(100, 22);
            this.userText.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(115, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // passText
            // 
            this.passText.Location = new System.Drawing.Point(118, 29);
            this.passText.Name = "passText";
            this.passText.PasswordChar = '*';
            this.passText.Size = new System.Drawing.Size(100, 22);
            this.passText.TabIndex = 2;
            // 
            // up
            // 
            this.up.Enabled = false;
            this.up.Location = new System.Drawing.Point(12, 450);
            this.up.Margin = new System.Windows.Forms.Padding(0);
            this.up.Name = "up";
            this.up.Size = new System.Drawing.Size(320, 47);
            this.up.TabIndex = 8;
            this.up.Text = "Поднять!";
            this.up.UseVisualStyleBackColor = true;
            this.up.Click += new System.EventHandler(this.up_Click);
            // 
            // albumsListBox
            // 
            this.albumsListBox.Enabled = false;
            this.albumsListBox.FormattingEnabled = true;
            this.albumsListBox.HorizontalScrollbar = true;
            this.albumsListBox.ItemHeight = 16;
            this.albumsListBox.Location = new System.Drawing.Point(12, 251);
            this.albumsListBox.Name = "albumsListBox";
            this.albumsListBox.Size = new System.Drawing.Size(320, 116);
            this.albumsListBox.TabIndex = 5;
            this.albumsListBox.SelectedIndexChanged += new System.EventHandler(this.albumsListBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 231);
            this.label3.MaximumSize = new System.Drawing.Size(326, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Список альбомов";
            // 
            // enterBut
            // 
            this.enterBut.Location = new System.Drawing.Point(225, 29);
            this.enterBut.Name = "enterBut";
            this.enterBut.Size = new System.Drawing.Size(107, 22);
            this.enterBut.TabIndex = 3;
            this.enterBut.Text = "Enter";
            this.enterBut.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.enterBut.UseVisualStyleBackColor = true;
            this.enterBut.Click += new System.EventHandler(this.enterBut_Click);
            // 
            // groupsListBox
            // 
            this.groupsListBox.Enabled = false;
            this.groupsListBox.FormattingEnabled = true;
            this.groupsListBox.HorizontalScrollbar = true;
            this.groupsListBox.ItemHeight = 16;
            this.groupsListBox.Location = new System.Drawing.Point(12, 115);
            this.groupsListBox.Name = "groupsListBox";
            this.groupsListBox.Size = new System.Drawing.Size(320, 100);
            this.groupsListBox.TabIndex = 4;
            this.groupsListBox.SelectedIndexChanged += new System.EventHandler(this.groupsListBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 95);
            this.label4.MaximumSize = new System.Drawing.Size(326, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Список групп";
            // 
            // prev50
            // 
            this.prev50.Enabled = false;
            this.prev50.Location = new System.Drawing.Point(12, 373);
            this.prev50.Name = "prev50";
            this.prev50.Size = new System.Drawing.Size(160, 36);
            this.prev50.TabIndex = 6;
            this.prev50.Text = "Предыдущие 50";
            this.prev50.UseVisualStyleBackColor = true;
            this.prev50.Click += new System.EventHandler(this.prev50_Click);
            // 
            // enterLabel
            // 
            this.enterLabel.AutoSize = true;
            this.enterLabel.Location = new System.Drawing.Point(12, 67);
            this.enterLabel.MaximumSize = new System.Drawing.Size(326, 0);
            this.enterLabel.Name = "enterLabel";
            this.enterLabel.Size = new System.Drawing.Size(281, 17);
            this.enterLabel.TabIndex = 5;
            this.enterLabel.Text = "Вы должны войти перед использованием";
            // 
            // next50
            // 
            this.next50.Enabled = false;
            this.next50.Location = new System.Drawing.Point(172, 373);
            this.next50.Name = "next50";
            this.next50.Size = new System.Drawing.Size(160, 36);
            this.next50.TabIndex = 6;
            this.next50.Text = "Следующие 50";
            this.next50.UseVisualStyleBackColor = true;
            this.next50.Click += new System.EventHandler(this.next50_Click);
            // 
            // urlidCheckBox
            // 
            this.urlidCheckBox.AutoSize = true;
            this.urlidCheckBox.Enabled = false;
            this.urlidCheckBox.Location = new System.Drawing.Point(15, 416);
            this.urlidCheckBox.Name = "urlidCheckBox";
            this.urlidCheckBox.Size = new System.Drawing.Size(125, 21);
            this.urlidCheckBox.TabIndex = 9;
            this.urlidCheckBox.Text = "По URL или ID";
            this.urlidCheckBox.UseVisualStyleBackColor = true;
            this.urlidCheckBox.CheckedChanged += new System.EventHandler(this.urlidCheckBox_CheckedChanged);
            // 
            // urlidTextBox
            // 
            this.urlidTextBox.Location = new System.Drawing.Point(146, 416);
            this.urlidTextBox.Name = "urlidTextBox";
            this.urlidTextBox.Size = new System.Drawing.Size(184, 22);
            this.urlidTextBox.TabIndex = 10;
            this.urlidTextBox.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 509);
            this.Controls.Add(this.urlidTextBox);
            this.Controls.Add(this.urlidCheckBox);
            this.Controls.Add(this.next50);
            this.Controls.Add(this.prev50);
            this.Controls.Add(this.enterBut);
            this.Controls.Add(this.enterLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupsListBox);
            this.Controls.Add(this.albumsListBox);
            this.Controls.Add(this.up);
            this.Controls.Add(this.passText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userText);
            this.Name = "Form1";
            this.Text = "VKAudioteka";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox userText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox passText;
        private System.Windows.Forms.Button up;
        private System.Windows.Forms.ListBox albumsListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button enterBut;
        private System.Windows.Forms.ListBox groupsListBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button prev50;
        private System.Windows.Forms.Label enterLabel;
        private System.Windows.Forms.Button next50;
        private System.Windows.Forms.CheckBox urlidCheckBox;
        private System.Windows.Forms.TextBox urlidTextBox;
    }
}


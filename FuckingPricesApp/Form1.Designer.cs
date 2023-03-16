
namespace FuckingPricesApp
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.InstructionLabel_1 = new System.Windows.Forms.Label();
            this.ChoseButton_1 = new System.Windows.Forms.Button();
            this.ChoseLabel_1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ChoseFolderImagesLabel_1 = new System.Windows.Forms.Label();
            this.ChoseImagesFolderButton_1 = new System.Windows.Forms.Button();
            this.GenerateButton_1 = new System.Windows.Forms.Button();
            this.SaveButton_1 = new System.Windows.Forms.Button();
            this.ProgressLable_1 = new System.Windows.Forms.Label();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ColumnCheckBox = new System.Windows.Forms.CheckBox();
            this.IdTextBox = new System.Windows.Forms.TextBox();
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.PriceTextBox = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.AddCheckBox = new System.Windows.Forms.CheckBox();
            this.PacketCheckBox = new System.Windows.Forms.CheckBox();
            this.ChoseGroupButton = new System.Windows.Forms.Button();
            this.SaveGroupBotton = new System.Windows.Forms.Button();
            this.ChoseGroupLabel = new System.Windows.Forms.Label();
            this.ChoseDiscriptionButton = new System.Windows.Forms.Button();
            this.ChoseFolderDiscriptionLabel = new System.Windows.Forms.Label();
            this.SaveFolderLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // InstructionLabel_1
            // 
            this.InstructionLabel_1.AutoSize = true;
            this.InstructionLabel_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InstructionLabel_1.Location = new System.Drawing.Point(29, 7);
            this.InstructionLabel_1.MaximumSize = new System.Drawing.Size(267, 0);
            this.InstructionLabel_1.Name = "InstructionLabel_1";
            this.InstructionLabel_1.Size = new System.Drawing.Size(267, 17);
            this.InstructionLabel_1.TabIndex = 0;
            this.InstructionLabel_1.Text = "Выберете прайс-лист в формате Excel:";
            // 
            // ChoseButton_1
            // 
            this.ChoseButton_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChoseButton_1.Location = new System.Drawing.Point(82, 28);
            this.ChoseButton_1.Name = "ChoseButton_1";
            this.ChoseButton_1.Size = new System.Drawing.Size(171, 29);
            this.ChoseButton_1.TabIndex = 1;
            this.ChoseButton_1.Text = "Выбрать файл";
            this.ChoseButton_1.UseVisualStyleBackColor = true;
            this.ChoseButton_1.Click += new System.EventHandler(this.ChoseButton_1_Click);
            // 
            // ChoseLabel_1
            // 
            this.ChoseLabel_1.AutoSize = true;
            this.ChoseLabel_1.Location = new System.Drawing.Point(30, 66);
            this.ChoseLabel_1.MaximumSize = new System.Drawing.Size(240, 26);
            this.ChoseLabel_1.Name = "ChoseLabel_1";
            this.ChoseLabel_1.Size = new System.Drawing.Size(0, 13);
            this.ChoseLabel_1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(2, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(337, 51);
            this.label2.TabIndex = 3;
            this.label2.Text = "Выберете папки с изображениями и описаниями \r\nтоваров (Названия файлов должны \r\nс" +
    "оответствовать артикулам товаров):";
            // 
            // ChoseFolderImagesLabel_1
            // 
            this.ChoseFolderImagesLabel_1.AutoSize = true;
            this.ChoseFolderImagesLabel_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChoseFolderImagesLabel_1.Location = new System.Drawing.Point(56, 168);
            this.ChoseFolderImagesLabel_1.MaximumSize = new System.Drawing.Size(250, 26);
            this.ChoseFolderImagesLabel_1.Name = "ChoseFolderImagesLabel_1";
            this.ChoseFolderImagesLabel_1.Size = new System.Drawing.Size(0, 24);
            this.ChoseFolderImagesLabel_1.TabIndex = 4;
            // 
            // ChoseImagesFolderButton_1
            // 
            this.ChoseImagesFolderButton_1.Enabled = false;
            this.ChoseImagesFolderButton_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChoseImagesFolderButton_1.Location = new System.Drawing.Point(75, 165);
            this.ChoseImagesFolderButton_1.Name = "ChoseImagesFolderButton_1";
            this.ChoseImagesFolderButton_1.Size = new System.Drawing.Size(183, 30);
            this.ChoseImagesFolderButton_1.TabIndex = 5;
            this.ChoseImagesFolderButton_1.Text = "Папка с изображениями";
            this.ChoseImagesFolderButton_1.UseVisualStyleBackColor = true;
            this.ChoseImagesFolderButton_1.Click += new System.EventHandler(this.ChoseImagesFolder_1_Click);
            // 
            // GenerateButton_1
            // 
            this.GenerateButton_1.Enabled = false;
            this.GenerateButton_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GenerateButton_1.Location = new System.Drawing.Point(82, 303);
            this.GenerateButton_1.Name = "GenerateButton_1";
            this.GenerateButton_1.Size = new System.Drawing.Size(171, 48);
            this.GenerateButton_1.TabIndex = 7;
            this.GenerateButton_1.Text = "Сгенерировать";
            this.GenerateButton_1.UseVisualStyleBackColor = true;
            this.GenerateButton_1.Click += new System.EventHandler(this.GenerateButton_1_Click);
            // 
            // SaveButton_1
            // 
            this.SaveButton_1.Enabled = false;
            this.SaveButton_1.Location = new System.Drawing.Point(82, 374);
            this.SaveButton_1.Name = "SaveButton_1";
            this.SaveButton_1.Size = new System.Drawing.Size(171, 23);
            this.SaveButton_1.TabIndex = 8;
            this.SaveButton_1.Text = "Сохранить как";
            this.SaveButton_1.UseVisualStyleBackColor = true;
            this.SaveButton_1.Visible = false;
            this.SaveButton_1.Click += new System.EventHandler(this.SaveButton_1_Click);
            // 
            // ProgressLable_1
            // 
            this.ProgressLable_1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.ProgressLable_1.Location = new System.Drawing.Point(81, 354);
            this.ProgressLable_1.Name = "ProgressLable_1";
            this.ProgressLable_1.Size = new System.Drawing.Size(171, 17);
            this.ProgressLable_1.TabIndex = 9;
            this.ProgressLable_1.Text = "Процесс обработки";
            this.ProgressLable_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ProgressLable_1.Visible = false;
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // ColumnCheckBox
            // 
            this.ColumnCheckBox.AutoSize = true;
            this.ColumnCheckBox.Location = new System.Drawing.Point(15, 239);
            this.ColumnCheckBox.Name = "ColumnCheckBox";
            this.ColumnCheckBox.Size = new System.Drawing.Size(182, 30);
            this.ColumnCheckBox.TabIndex = 11;
            this.ColumnCheckBox.Text = "Изменить номера колонок\r\nАртикул:     Название:     Цена:";
            this.toolTip1.SetToolTip(this.ColumnCheckBox, "Если номера колонок в Excel файле другие");
            this.ColumnCheckBox.UseVisualStyleBackColor = true;
            this.ColumnCheckBox.Visible = false;
            this.ColumnCheckBox.CheckedChanged += new System.EventHandler(this.ColumnCheckBox_CheckedChanged);
            // 
            // IdTextBox
            // 
            this.IdTextBox.Enabled = false;
            this.IdTextBox.Location = new System.Drawing.Point(47, 273);
            this.IdTextBox.Name = "IdTextBox";
            this.IdTextBox.Size = new System.Drawing.Size(18, 20);
            this.IdTextBox.TabIndex = 12;
            this.IdTextBox.Text = "3";
            this.IdTextBox.Visible = false;
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.Enabled = false;
            this.TitleTextBox.Location = new System.Drawing.Point(105, 273);
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.Size = new System.Drawing.Size(18, 20);
            this.TitleTextBox.TabIndex = 13;
            this.TitleTextBox.Text = "4";
            this.TitleTextBox.Visible = false;
            // 
            // PriceTextBox
            // 
            this.PriceTextBox.Enabled = false;
            this.PriceTextBox.Location = new System.Drawing.Point(164, 273);
            this.PriceTextBox.Name = "PriceTextBox";
            this.PriceTextBox.Size = new System.Drawing.Size(18, 20);
            this.PriceTextBox.TabIndex = 14;
            this.PriceTextBox.Text = "5";
            this.PriceTextBox.Visible = false;
            // 
            // AddCheckBox
            // 
            this.AddCheckBox.AutoSize = true;
            this.AddCheckBox.Checked = true;
            this.AddCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AddCheckBox.Location = new System.Drawing.Point(203, 240);
            this.AddCheckBox.Name = "AddCheckBox";
            this.AddCheckBox.Size = new System.Drawing.Size(131, 30);
            this.AddCheckBox.TabIndex = 15;
            this.AddCheckBox.Text = "Добавить титульную\r\nстраницу";
            this.toolTip1.SetToolTip(this.AddCheckBox, "Добавляет титульную страницу\r\nс названием на основе названия Excel файла");
            this.AddCheckBox.UseVisualStyleBackColor = true;
            this.AddCheckBox.Visible = false;
            // 
            // PacketCheckBox
            // 
            this.PacketCheckBox.AutoSize = true;
            this.PacketCheckBox.Location = new System.Drawing.Point(255, 49);
            this.PacketCheckBox.Name = "PacketCheckBox";
            this.PacketCheckBox.Size = new System.Drawing.Size(79, 43);
            this.PacketCheckBox.TabIndex = 16;
            this.PacketCheckBox.Text = "Пакетная\r\nобработка\r\nфайлов";
            this.PacketCheckBox.UseVisualStyleBackColor = true;
            this.PacketCheckBox.CheckedChanged += new System.EventHandler(this.PacketCheckBox_CheckedChanged);
            // 
            // ChoseGroupButton
            // 
            this.ChoseGroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChoseGroupButton.Location = new System.Drawing.Point(82, 44);
            this.ChoseGroupButton.Name = "ChoseGroupButton";
            this.ChoseGroupButton.Size = new System.Drawing.Size(171, 29);
            this.ChoseGroupButton.TabIndex = 17;
            this.ChoseGroupButton.Text = "Выбрать файлы";
            this.ChoseGroupButton.UseVisualStyleBackColor = true;
            this.ChoseGroupButton.Visible = false;
            this.ChoseGroupButton.Click += new System.EventHandler(this.ChoseGroupButton_Click);
            // 
            // SaveGroupBotton
            // 
            this.SaveGroupBotton.Enabled = false;
            this.SaveGroupBotton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveGroupBotton.Location = new System.Drawing.Point(82, 73);
            this.SaveGroupBotton.Name = "SaveGroupBotton";
            this.SaveGroupBotton.Size = new System.Drawing.Size(171, 29);
            this.SaveGroupBotton.TabIndex = 18;
            this.SaveGroupBotton.Text = "Папка для сохранения";
            this.SaveGroupBotton.UseVisualStyleBackColor = true;
            this.SaveGroupBotton.Visible = false;
            this.SaveGroupBotton.Click += new System.EventHandler(this.SaveGroupBotton_Click);
            // 
            // ChoseGroupLabel
            // 
            this.ChoseGroupLabel.AutoSize = true;
            this.ChoseGroupLabel.Location = new System.Drawing.Point(16, 53);
            this.ChoseGroupLabel.Name = "ChoseGroupLabel";
            this.ChoseGroupLabel.Size = new System.Drawing.Size(0, 13);
            this.ChoseGroupLabel.TabIndex = 19;
            // 
            // ChoseDiscriptionButton
            // 
            this.ChoseDiscriptionButton.Enabled = false;
            this.ChoseDiscriptionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChoseDiscriptionButton.Location = new System.Drawing.Point(75, 201);
            this.ChoseDiscriptionButton.Name = "ChoseDiscriptionButton";
            this.ChoseDiscriptionButton.Size = new System.Drawing.Size(183, 30);
            this.ChoseDiscriptionButton.TabIndex = 20;
            this.ChoseDiscriptionButton.Text = "Папка с описаниями";
            this.ChoseDiscriptionButton.UseVisualStyleBackColor = true;
            this.ChoseDiscriptionButton.Click += new System.EventHandler(this.ChoseDiscriptionButton_Click);
            // 
            // ChoseFolderDiscriptionLabel
            // 
            this.ChoseFolderDiscriptionLabel.AutoSize = true;
            this.ChoseFolderDiscriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChoseFolderDiscriptionLabel.Location = new System.Drawing.Point(54, 203);
            this.ChoseFolderDiscriptionLabel.MaximumSize = new System.Drawing.Size(250, 26);
            this.ChoseFolderDiscriptionLabel.Name = "ChoseFolderDiscriptionLabel";
            this.ChoseFolderDiscriptionLabel.Size = new System.Drawing.Size(0, 24);
            this.ChoseFolderDiscriptionLabel.TabIndex = 21;
            // 
            // SaveFolderLabel
            // 
            this.SaveFolderLabel.AutoSize = true;
            this.SaveFolderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveFolderLabel.Location = new System.Drawing.Point(57, 77);
            this.SaveFolderLabel.MaximumSize = new System.Drawing.Size(250, 26);
            this.SaveFolderLabel.Name = "SaveFolderLabel";
            this.SaveFolderLabel.Size = new System.Drawing.Size(0, 24);
            this.SaveFolderLabel.TabIndex = 22;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 411);
            this.Controls.Add(this.SaveFolderLabel);
            this.Controls.Add(this.ChoseFolderDiscriptionLabel);
            this.Controls.Add(this.ChoseDiscriptionButton);
            this.Controls.Add(this.ChoseGroupLabel);
            this.Controls.Add(this.SaveGroupBotton);
            this.Controls.Add(this.ChoseGroupButton);
            this.Controls.Add(this.PacketCheckBox);
            this.Controls.Add(this.AddCheckBox);
            this.Controls.Add(this.PriceTextBox);
            this.Controls.Add(this.TitleTextBox);
            this.Controls.Add(this.IdTextBox);
            this.Controls.Add(this.ColumnCheckBox);
            this.Controls.Add(this.ProgressLable_1);
            this.Controls.Add(this.SaveButton_1);
            this.Controls.Add(this.GenerateButton_1);
            this.Controls.Add(this.ChoseImagesFolderButton_1);
            this.Controls.Add(this.ChoseFolderImagesLabel_1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ChoseLabel_1);
            this.Controls.Add(this.ChoseButton_1);
            this.Controls.Add(this.InstructionLabel_1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(350, 460);
            this.MinimumSize = new System.Drawing.Size(333, 450);
            this.Name = "Form1";
            this.Text = "Prices";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label InstructionLabel_1;
        private System.Windows.Forms.Button ChoseButton_1;
        private System.Windows.Forms.Label ChoseLabel_1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ChoseFolderImagesLabel_1;
        private System.Windows.Forms.Button ChoseImagesFolderButton_1;
        private System.Windows.Forms.Button GenerateButton_1;
        private System.Windows.Forms.Button SaveButton_1;
        private System.Windows.Forms.Label ProgressLable_1;
        private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.CheckBox ColumnCheckBox;
        private System.Windows.Forms.TextBox IdTextBox;
        private System.Windows.Forms.TextBox TitleTextBox;
        private System.Windows.Forms.TextBox PriceTextBox;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox AddCheckBox;
        private System.Windows.Forms.CheckBox PacketCheckBox;
        private System.Windows.Forms.Button ChoseGroupButton;
        private System.Windows.Forms.Button SaveGroupBotton;
        private System.Windows.Forms.Label ChoseGroupLabel;
        private System.Windows.Forms.Button ChoseDiscriptionButton;
        private System.Windows.Forms.Label ChoseFolderDiscriptionLabel;
        private System.Windows.Forms.Label SaveFolderLabel;
    }
}


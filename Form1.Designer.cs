namespace ImageLab1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        /// Освободить все используемые ресурсы.
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
            this.btnAddImage = new System.Windows.Forms.Button();
            this.btnRemoveLayer = new System.Windows.Forms.Button();
            this.btnRender = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lstLayers = new System.Windows.Forms.ListBox();
            this.pictureBoxResult = new System.Windows.Forms.PictureBox();
            this.lblBlend = new System.Windows.Forms.Label();
            this.cmbBlendMode = new System.Windows.Forms.ComboBox();
            this.lblOpacity = new System.Windows.Forms.Label();
            this.trbOpacity = new System.Windows.Forms.TrackBar();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbOpacity)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddImage
            // 
            this.btnAddImage.Location = new System.Drawing.Point(16, 15);
            this.btnAddImage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(200, 37);
            this.btnAddImage.TabIndex = 0;
            this.btnAddImage.Text = "Добавить изображение";
            this.btnAddImage.UseVisualStyleBackColor = true;
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // btnRemoveLayer
            // 
            this.btnRemoveLayer.Location = new System.Drawing.Point(224, 15);
            this.btnRemoveLayer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRemoveLayer.Name = "btnRemoveLayer";
            this.btnRemoveLayer.Size = new System.Drawing.Size(160, 37);
            this.btnRemoveLayer.TabIndex = 1;
            this.btnRemoveLayer.Text = "Удалить слой";
            this.btnRemoveLayer.UseVisualStyleBackColor = true;
            this.btnRemoveLayer.Click += new System.EventHandler(this.btnRemoveLayer_Click);
            // 
            // btnRender
            // 
            this.btnRender.Location = new System.Drawing.Point(392, 15);
            this.btnRender.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRender.Name = "btnRender";
            this.btnRender.Size = new System.Drawing.Size(133, 37);
            this.btnRender.TabIndex = 2;
            this.btnRender.Text = "Обновить";
            this.btnRender.UseVisualStyleBackColor = true;
            this.btnRender.Click += new System.EventHandler(this.btnRender_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(533, 15);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(173, 37);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Сохранить результат";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lstLayers
            // 
            this.lstLayers.FormattingEnabled = true;
            this.lstLayers.ItemHeight = 16;
            this.lstLayers.Location = new System.Drawing.Point(16, 62);
            this.lstLayers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstLayers.Name = "lstLayers";
            this.lstLayers.Size = new System.Drawing.Size(372, 500);
            this.lstLayers.TabIndex = 4;
            // 
            // pictureBoxResult
            // 
            this.pictureBoxResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxResult.Location = new System.Drawing.Point(397, 62);
            this.pictureBoxResult.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBoxResult.Name = "pictureBoxResult";
            this.pictureBoxResult.Size = new System.Drawing.Size(666, 492);
            this.pictureBoxResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxResult.TabIndex = 5;
            this.pictureBoxResult.TabStop = false;
            // 
            // lblBlend
            // 
            this.lblBlend.AutoSize = true;
            this.lblBlend.Location = new System.Drawing.Point(16, 578);
            this.lblBlend.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBlend.Name = "lblBlend";
            this.lblBlend.Size = new System.Drawing.Size(128, 16);
            this.lblBlend.TabIndex = 6;
            this.lblBlend.Text = "Режим наложения:";
            // 
            // cmbBlendMode
            // 
            this.cmbBlendMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBlendMode.FormattingEnabled = true;
            this.cmbBlendMode.Location = new System.Drawing.Point(160, 575);
            this.cmbBlendMode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbBlendMode.Name = "cmbBlendMode";
            this.cmbBlendMode.Size = new System.Drawing.Size(225, 24);
            this.cmbBlendMode.TabIndex = 7;
            // 
            // lblOpacity
            // 
            this.lblOpacity.AutoSize = true;
            this.lblOpacity.Location = new System.Drawing.Point(400, 578);
            this.lblOpacity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOpacity.Name = "lblOpacity";
            this.lblOpacity.Size = new System.Drawing.Size(157, 16);
            this.lblOpacity.TabIndex = 8;
            this.lblOpacity.Text = "Непрозрачность: 100%";
            // 
            // trbOpacity
            // 
            this.trbOpacity.Location = new System.Drawing.Point(560, 566);
            this.trbOpacity.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trbOpacity.Maximum = 100;
            this.trbOpacity.Name = "trbOpacity";
            this.trbOpacity.Size = new System.Drawing.Size(200, 56);
            this.trbOpacity.TabIndex = 9;
            this.trbOpacity.Value = 100;
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Location = new System.Drawing.Point(16, 615);
            this.btnMoveUp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(107, 37);
            this.btnMoveUp.TabIndex = 10;
            this.btnMoveUp.Text = "↑ Вверх";
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Location = new System.Drawing.Point(133, 615);
            this.btnMoveDown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(107, 37);
            this.btnMoveDown.TabIndex = 11;
            this.btnMoveDown.Text = "↓ Вниз";
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 677);
            this.Controls.Add(this.btnMoveDown);
            this.Controls.Add(this.btnMoveUp);
            this.Controls.Add(this.trbOpacity);
            this.Controls.Add(this.lblOpacity);
            this.Controls.Add(this.cmbBlendMode);
            this.Controls.Add(this.lblBlend);
            this.Controls.Add(this.pictureBoxResult);
            this.Controls.Add(this.lstLayers);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRender);
            this.Controls.Add(this.btnRemoveLayer);
            this.Controls.Add(this.btnAddImage);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Лабораторная работа 1 - Работа с изображениями (50 баллов)";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbOpacity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddImage;
        private System.Windows.Forms.Button btnRemoveLayer;
        private System.Windows.Forms.Button btnRender;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ListBox lstLayers;
        private System.Windows.Forms.PictureBox pictureBoxResult;
        private System.Windows.Forms.Label lblBlend;
        private System.Windows.Forms.ComboBox cmbBlendMode;
        private System.Windows.Forms.Label lblOpacity;
        private System.Windows.Forms.TrackBar trbOpacity;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnMoveDown;
    }
}
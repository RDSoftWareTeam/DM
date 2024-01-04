namespace DM
{
    partial class Enroll
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
            this.labelUser = new System.Windows.Forms.Label();
            this.labelCode = new System.Windows.Forms.Label();
            this.labelRole = new System.Windows.Forms.Label();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.textBoxCode = new System.Windows.Forms.TextBox();
            this.comboBoxRole = new System.Windows.Forms.ComboBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelHeadPortrait = new System.Windows.Forms.Label();
            this.pictureBoxHeadPortrait = new System.Windows.Forms.PictureBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHeadPortrait)).BeginInit();
            this.SuspendLayout();
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(65, 70);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(41, 12);
            this.labelUser.TabIndex = 0;
            this.labelUser.Text = "用户名";
            // 
            // labelCode
            // 
            this.labelCode.AutoSize = true;
            this.labelCode.Location = new System.Drawing.Point(65, 120);
            this.labelCode.Name = "labelCode";
            this.labelCode.Size = new System.Drawing.Size(29, 12);
            this.labelCode.TabIndex = 1;
            this.labelCode.Text = "密码";
            // 
            // labelRole
            // 
            this.labelRole.AutoSize = true;
            this.labelRole.Location = new System.Drawing.Point(65, 220);
            this.labelRole.Name = "labelRole";
            this.labelRole.Size = new System.Drawing.Size(29, 12);
            this.labelRole.TabIndex = 2;
            this.labelRole.Text = "角色";
            // 
            // textBoxUser
            // 
            this.textBoxUser.Location = new System.Drawing.Point(150, 70);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(100, 21);
            this.textBoxUser.TabIndex = 3;
            // 
            // textBoxCode
            // 
            this.textBoxCode.Location = new System.Drawing.Point(150, 120);
            this.textBoxCode.Name = "textBoxCode";
            this.textBoxCode.Size = new System.Drawing.Size(100, 21);
            this.textBoxCode.TabIndex = 4;
            // 
            // comboBoxRole
            // 
            this.comboBoxRole.FormattingEnabled = true;
            this.comboBoxRole.Location = new System.Drawing.Point(150, 220);
            this.comboBoxRole.Name = "comboBoxRole";
            this.comboBoxRole.Size = new System.Drawing.Size(100, 20);
            this.comboBoxRole.TabIndex = 5;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(65, 170);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(53, 12);
            this.labelName.TabIndex = 6;
            this.labelName.Text = "真实姓名";
            // 
            // labelHeadPortrait
            // 
            this.labelHeadPortrait.AutoSize = true;
            this.labelHeadPortrait.Location = new System.Drawing.Point(65, 270);
            this.labelHeadPortrait.Name = "labelHeadPortrait";
            this.labelHeadPortrait.Size = new System.Drawing.Size(29, 12);
            this.labelHeadPortrait.TabIndex = 7;
            this.labelHeadPortrait.Text = "头像";
            // 
            // pictureBoxHeadPortrait
            // 
            this.pictureBoxHeadPortrait.Location = new System.Drawing.Point(150, 270);
            this.pictureBoxHeadPortrait.Name = "pictureBoxHeadPortrait";
            this.pictureBoxHeadPortrait.Size = new System.Drawing.Size(100, 87);
            this.pictureBoxHeadPortrait.TabIndex = 8;
            this.pictureBoxHeadPortrait.TabStop = false;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(150, 170);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 21);
            this.textBoxName.TabIndex = 9;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(116, 390);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 10;
            this.buttonSave.Text = "保存";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // Enroll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 442);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.pictureBoxHeadPortrait);
            this.Controls.Add(this.labelHeadPortrait);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.comboBoxRole);
            this.Controls.Add(this.textBoxCode);
            this.Controls.Add(this.textBoxUser);
            this.Controls.Add(this.labelRole);
            this.Controls.Add(this.labelCode);
            this.Controls.Add(this.labelUser);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Enroll";
            this.Text = "登录";
            this.Load += new System.EventHandler(this.Enroll_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHeadPortrait)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Label labelCode;
        private System.Windows.Forms.Label labelRole;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.TextBox textBoxCode;
        private System.Windows.Forms.ComboBox comboBoxRole;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelHeadPortrait;
        private System.Windows.Forms.PictureBox pictureBoxHeadPortrait;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button buttonSave;
    }
}
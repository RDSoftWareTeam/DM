namespace DM
{
    partial class Form_roleAuth
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
            this.gc_roleAuth = new DevExpress.XtraGrid.GridControl();
            this.t_roleAuth = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gc_roleAuth_select = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_roleAuth_btn_select = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gc_roleAuth_moduleID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_roleAuth_modulename = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_roleAuth_modulekey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_auth_rolename = new System.Windows.Forms.TextBox();
            this.btn_roleAuth_save = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gc_roleAuth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_roleAuth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_roleAuth_btn_select)).BeginInit();
            this.SuspendLayout();
            // 
            // gc_roleAuth
            // 
            this.gc_roleAuth.AccessibleName = "";
            this.gc_roleAuth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc_roleAuth.Location = new System.Drawing.Point(0, 80);
            this.gc_roleAuth.MainView = this.t_roleAuth;
            this.gc_roleAuth.Margin = new System.Windows.Forms.Padding(0);
            this.gc_roleAuth.Name = "gc_roleAuth";
            this.gc_roleAuth.Padding = new System.Windows.Forms.Padding(100, 0, 0, 0);
            this.gc_roleAuth.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gc_roleAuth_btn_select});
            this.gc_roleAuth.Size = new System.Drawing.Size(785, 605);
            this.gc_roleAuth.TabIndex = 2;
            this.gc_roleAuth.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.t_roleAuth});
            // 
            // t_roleAuth
            // 
            this.t_roleAuth.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gc_roleAuth_select,
            this.gc_roleAuth_moduleID,
            this.gc_roleAuth_modulename,
            this.gc_roleAuth_modulekey});
            this.t_roleAuth.GridControl = this.gc_roleAuth;
            this.t_roleAuth.IndicatorWidth = 60;
            this.t_roleAuth.Name = "t_roleAuth";
            this.t_roleAuth.OptionsBehavior.ReadOnly = true;
            this.t_roleAuth.OptionsView.ShowGroupPanel = false;
            this.t_roleAuth.ViewCaption = "角色-功能授权表";
            this.t_roleAuth.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.t_roleAuth_CustomDrawRowIndicator);
            // 
            // gc_roleAuth_select
            // 
            this.gc_roleAuth_select.Caption = "选择";
            this.gc_roleAuth_select.ColumnEdit = this.gc_roleAuth_btn_select;
            this.gc_roleAuth_select.MaxWidth = 50;
            this.gc_roleAuth_select.MinWidth = 50;
            this.gc_roleAuth_select.Name = "gc_roleAuth_select";
            this.gc_roleAuth_select.Visible = true;
            this.gc_roleAuth_select.VisibleIndex = 0;
            this.gc_roleAuth_select.Width = 50;
            // 
            // gc_roleAuth_btn_select
            // 
            this.gc_roleAuth_btn_select.AutoHeight = false;
            this.gc_roleAuth_btn_select.Name = "gc_roleAuth_btn_select";
            this.gc_roleAuth_btn_select.Click += new System.EventHandler(this.gc_roleAuth_btn_select_Click);
            // 
            // gc_roleAuth_moduleID
            // 
            this.gc_roleAuth_moduleID.Caption = "ID";
            this.gc_roleAuth_moduleID.Name = "gc_roleAuth_moduleID";
            this.gc_roleAuth_moduleID.Visible = true;
            this.gc_roleAuth_moduleID.VisibleIndex = 1;
            // 
            // gc_roleAuth_modulename
            // 
            this.gc_roleAuth_modulename.Caption = "功能名";
            this.gc_roleAuth_modulename.Name = "gc_roleAuth_modulename";
            this.gc_roleAuth_modulename.Visible = true;
            this.gc_roleAuth_modulename.VisibleIndex = 2;
            // 
            // gc_roleAuth_modulekey
            // 
            this.gc_roleAuth_modulekey.Caption = "功能key";
            this.gc_roleAuth_modulekey.Name = "gc_roleAuth_modulekey";
            this.gc_roleAuth_modulekey.Visible = true;
            this.gc_roleAuth_modulekey.VisibleIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "角色名:";
            // 
            // textBox_auth_rolename
            // 
            this.textBox_auth_rolename.Location = new System.Drawing.Point(101, 28);
            this.textBox_auth_rolename.Name = "textBox_auth_rolename";
            this.textBox_auth_rolename.ReadOnly = true;
            this.textBox_auth_rolename.Size = new System.Drawing.Size(150, 28);
            this.textBox_auth_rolename.TabIndex = 4;
            // 
            // btn_roleAuth_save
            // 
            this.btn_roleAuth_save.Location = new System.Drawing.Point(643, 21);
            this.btn_roleAuth_save.Name = "btn_roleAuth_save";
            this.btn_roleAuth_save.Size = new System.Drawing.Size(100, 40);
            this.btn_roleAuth_save.TabIndex = 5;
            this.btn_roleAuth_save.Text = "保存";
            this.btn_roleAuth_save.Click += new System.EventHandler(this.btn_roleAuth_save_Click);
            // 
            // Form_roleAuth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 685);
            this.Controls.Add(this.btn_roleAuth_save);
            this.Controls.Add(this.textBox_auth_rolename);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gc_roleAuth);
            this.Name = "Form_roleAuth";
            this.Padding = new System.Windows.Forms.Padding(0, 80, 0, 0);
            this.Text = "授权表";
            this.Load += new System.EventHandler(this.Form_roleAuth_Load);
            this.Resize += new System.EventHandler(this.Form_roleAuth_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.gc_roleAuth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_roleAuth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_roleAuth_btn_select)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gc_roleAuth;
        private DevExpress.XtraGrid.Views.Grid.GridView t_roleAuth;
        private DevExpress.XtraGrid.Columns.GridColumn gc_roleAuth_modulename;
        private DevExpress.XtraGrid.Columns.GridColumn gc_roleAuth_modulekey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_auth_rolename;
        private DevExpress.XtraGrid.Columns.GridColumn gc_roleAuth_select;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit gc_roleAuth_btn_select;
        private DevExpress.XtraGrid.Columns.GridColumn gc_roleAuth_moduleID;
        private DevExpress.XtraEditors.SimpleButton btn_roleAuth_save;
    }
}
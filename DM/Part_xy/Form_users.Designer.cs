namespace DM
{
    partial class Form_users
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.gc_users = new DevExpress.XtraGrid.GridControl();
            this.t_users = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gc_users_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_users_username = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_users_userpwd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_users_realname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_users_photo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_users_idt_role = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_users_delete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_users_btn_delete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gc_users_edit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_users_btn_edit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.btn_users_add = new DevExpress.XtraEditors.SimpleButton();
            this.btn_users_import = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_users)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_users)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_users_btn_delete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_users_btn_edit)).BeginInit();
            this.SuspendLayout();
            // 
            // gc_users
            // 
            this.gc_users.AccessibleName = "";
            this.gc_users.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc_users.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gc_users.Location = new System.Drawing.Point(0, 53);
            this.gc_users.MainView = this.t_users;
            this.gc_users.Margin = new System.Windows.Forms.Padding(0);
            this.gc_users.Name = "gc_users";
            this.gc_users.Padding = new System.Windows.Forms.Padding(67, 0, 0, 0);
            this.gc_users.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gc_users_btn_edit,
            this.gc_users_btn_delete});
            this.gc_users.Size = new System.Drawing.Size(721, 351);
            this.gc_users.TabIndex = 1;
            this.gc_users.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.t_users});
            // 
            // t_users
            // 
            this.t_users.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gc_users_id,
            this.gc_users_username,
            this.gc_users_userpwd,
            this.gc_users_realname,
            this.gc_users_photo,
            this.gc_users_idt_role,
            this.gc_users_delete,
            this.gc_users_edit});
            this.t_users.GridControl = this.gc_users;
            this.t_users.IndicatorWidth = 60;
            this.t_users.Name = "t_users";
            this.t_users.OptionsBehavior.ReadOnly = true;
            this.t_users.OptionsView.ShowGroupPanel = false;
            this.t_users.ViewCaption = "用户表";
            this.t_users.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.t_users_CustomDrawRowIndicator);
            // 
            // gc_users_id
            // 
            this.gc_users_id.Caption = "ID";
            this.gc_users_id.Name = "gc_users_id";
            // 
            // gc_users_username
            // 
            this.gc_users_username.Caption = "用户名";
            this.gc_users_username.Name = "gc_users_username";
            this.gc_users_username.Visible = true;
            this.gc_users_username.VisibleIndex = 0;
            this.gc_users_username.Width = 145;
            // 
            // gc_users_userpwd
            // 
            this.gc_users_userpwd.Caption = "密码";
            this.gc_users_userpwd.Name = "gc_users_userpwd";
            this.gc_users_userpwd.Visible = true;
            this.gc_users_userpwd.VisibleIndex = 1;
            this.gc_users_userpwd.Width = 145;
            // 
            // gc_users_realname
            // 
            this.gc_users_realname.Caption = "真实姓名";
            this.gc_users_realname.Name = "gc_users_realname";
            this.gc_users_realname.Visible = true;
            this.gc_users_realname.VisibleIndex = 2;
            this.gc_users_realname.Width = 145;
            // 
            // gc_users_photo
            // 
            this.gc_users_photo.Caption = "头像";
            this.gc_users_photo.Name = "gc_users_photo";
            this.gc_users_photo.Visible = true;
            this.gc_users_photo.VisibleIndex = 3;
            this.gc_users_photo.Width = 145;
            // 
            // gc_users_idt_role
            // 
            this.gc_users_idt_role.Caption = "角色";
            this.gc_users_idt_role.Name = "gc_users_idt_role";
            this.gc_users_idt_role.Visible = true;
            this.gc_users_idt_role.VisibleIndex = 4;
            this.gc_users_idt_role.Width = 145;
            // 
            // gc_users_delete
            // 
            this.gc_users_delete.Caption = "操作";
            this.gc_users_delete.ColumnEdit = this.gc_users_btn_delete;
            this.gc_users_delete.Name = "gc_users_delete";
            this.gc_users_delete.Visible = true;
            this.gc_users_delete.VisibleIndex = 5;
            this.gc_users_delete.Width = 80;
            // 
            // gc_users_btn_delete
            // 
            this.gc_users_btn_delete.AutoHeight = false;
            this.gc_users_btn_delete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "删除", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.gc_users_btn_delete.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gc_users_btn_delete.Name = "gc_users_btn_delete";
            this.gc_users_btn_delete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.gc_users_btn_delete.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.gc_users_btn_delete_ButtonClick);
            // 
            // gc_users_edit
            // 
            this.gc_users_edit.Caption = "操作";
            this.gc_users_edit.ColumnEdit = this.gc_users_btn_edit;
            this.gc_users_edit.Name = "gc_users_edit";
            this.gc_users_edit.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gc_users_edit.Visible = true;
            this.gc_users_edit.VisibleIndex = 6;
            this.gc_users_edit.Width = 80;
            // 
            // gc_users_btn_edit
            // 
            this.gc_users_btn_edit.AutoHeight = false;
            this.gc_users_btn_edit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "编辑", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true)});
            this.gc_users_btn_edit.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gc_users_btn_edit.Name = "gc_users_btn_edit";
            this.gc_users_btn_edit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.gc_users_btn_edit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.gc_users_btn_edit_ButtonClick);
            // 
            // btn_users_add
            // 
            this.btn_users_add.Location = new System.Drawing.Point(547, 13);
            this.btn_users_add.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_users_add.Name = "btn_users_add";
            this.btn_users_add.Size = new System.Drawing.Size(67, 27);
            this.btn_users_add.TabIndex = 2;
            this.btn_users_add.Text = "增加";
            this.btn_users_add.Click += new System.EventHandler(this.btn_users_add_Click);
            // 
            // btn_users_import
            // 
            this.btn_users_import.Location = new System.Drawing.Point(630, 13);
            this.btn_users_import.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_users_import.Name = "btn_users_import";
            this.btn_users_import.Size = new System.Drawing.Size(67, 27);
            this.btn_users_import.TabIndex = 3;
            this.btn_users_import.Text = "导入";
            // 
            // Form_users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 404);
            this.Controls.Add(this.btn_users_import);
            this.Controls.Add(this.btn_users_add);
            this.Controls.Add(this.gc_users);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form_users";
            this.Padding = new System.Windows.Forms.Padding(0, 53, 0, 0);
            this.Text = "用户表";
            this.Load += new System.EventHandler(this.Form_users_Load);
            this.Resize += new System.EventHandler(this.Form_users_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_users)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_users)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_users_btn_delete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_users_btn_edit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraGrid.Views.Grid.GridView t_users;
        private DevExpress.XtraGrid.Columns.GridColumn gc_users_id;
        private DevExpress.XtraGrid.Columns.GridColumn gc_users_username;
        private DevExpress.XtraGrid.Columns.GridColumn gc_users_userpwd;
        private DevExpress.XtraGrid.Columns.GridColumn gc_users_realname;
        private DevExpress.XtraGrid.Columns.GridColumn gc_users_photo;
        private DevExpress.XtraGrid.Columns.GridColumn gc_users_idt_role;
        private DevExpress.XtraGrid.Columns.GridColumn gc_users_delete;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit gc_users_btn_delete;
        private DevExpress.XtraGrid.Columns.GridColumn gc_users_edit;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit gc_users_btn_edit;
        private DevExpress.XtraEditors.SimpleButton btn_users_add;
        private DevExpress.XtraEditors.SimpleButton btn_users_import;
        public DevExpress.XtraGrid.GridControl gc_users;
    }
}


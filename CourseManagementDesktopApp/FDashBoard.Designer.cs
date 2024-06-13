namespace CourseManagementDesktopApp
{
    partial class FDashBoard
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FDashBoard));
            this.tbDashboard = new System.Windows.Forms.TabControl();
            this.tpCategory = new System.Windows.Forms.TabPage();
            this.tpCourse = new System.Windows.Forms.TabPage();
            this.tpClassroom = new System.Windows.Forms.TabPage();
            this.tpUsers = new System.Windows.Forms.TabPage();
            this.tpStatistic = new System.Windows.Forms.TabPage();
            this.iList = new System.Windows.Forms.ImageList(this.components);
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.personDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgvUsersPerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.perNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnUsersControl = new System.Windows.Forms.Panel();
            this.lblPerID = new System.Windows.Forms.Label();
            this.txbPerID = new System.Windows.Forms.TextBox();
            this.lblPerName = new System.Windows.Forms.Label();
            this.txbPerName = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txbPhone = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txbAddress = new System.Windows.Forms.TextBox();
            this.lblSex = new System.Windows.Forms.Label();
            this.cbSex = new System.Windows.Forms.ComboBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.cbRole = new System.Windows.Forms.ComboBox();
            this.lblDateCreated = new System.Windows.Forms.Label();
            this.txbDateCreated = new System.Windows.Forms.TextBox();
            this.lblDateModifier = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tbDashboard.SuspendLayout();
            this.tpUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personDTOBindingSource)).BeginInit();
            this.pnUsersControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbDashboard
            // 
            this.tbDashboard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDashboard.Controls.Add(this.tpUsers);
            this.tbDashboard.Controls.Add(this.tpCategory);
            this.tbDashboard.Controls.Add(this.tpCourse);
            this.tbDashboard.Controls.Add(this.tpClassroom);
            this.tbDashboard.Controls.Add(this.tpStatistic);
            this.tbDashboard.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDashboard.ImageList = this.iList;
            this.tbDashboard.Location = new System.Drawing.Point(-3, 0);
            this.tbDashboard.Multiline = true;
            this.tbDashboard.Name = "tbDashboard";
            this.tbDashboard.SelectedIndex = 0;
            this.tbDashboard.Size = new System.Drawing.Size(804, 450);
            this.tbDashboard.TabIndex = 0;
            // 
            // tpCategory
            // 
            this.tpCategory.BackColor = System.Drawing.Color.White;
            this.tpCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tpCategory.Location = new System.Drawing.Point(4, 47);
            this.tpCategory.Name = "tpCategory";
            this.tpCategory.Padding = new System.Windows.Forms.Padding(3);
            this.tpCategory.Size = new System.Drawing.Size(796, 399);
            this.tpCategory.TabIndex = 0;
            this.tpCategory.Text = "DANH MỤC";
            this.tpCategory.ToolTipText = "Quản lý các danh mục";
            // 
            // tpCourse
            // 
            this.tpCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tpCourse.Location = new System.Drawing.Point(4, 47);
            this.tpCourse.Name = "tpCourse";
            this.tpCourse.Padding = new System.Windows.Forms.Padding(3);
            this.tpCourse.Size = new System.Drawing.Size(796, 399);
            this.tpCourse.TabIndex = 1;
            this.tpCourse.Text = "MÔN HỌC";
            this.tpCourse.ToolTipText = "Quản lý các môn học";
            this.tpCourse.UseVisualStyleBackColor = true;
            // 
            // tpClassroom
            // 
            this.tpClassroom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tpClassroom.Location = new System.Drawing.Point(4, 47);
            this.tpClassroom.Name = "tpClassroom";
            this.tpClassroom.Size = new System.Drawing.Size(796, 399);
            this.tpClassroom.TabIndex = 2;
            this.tpClassroom.Text = "KHOÁ HỌC";
            this.tpClassroom.ToolTipText = "Quản lý các khoá học, mở lớp học theo định kỳ";
            this.tpClassroom.UseVisualStyleBackColor = true;
            // 
            // tpUsers
            // 
            this.tpUsers.Controls.Add(this.pnUsersControl);
            this.tpUsers.Controls.Add(this.dgvUsers);
            this.tpUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tpUsers.Location = new System.Drawing.Point(4, 47);
            this.tpUsers.Name = "tpUsers";
            this.tpUsers.Size = new System.Drawing.Size(796, 399);
            this.tpUsers.TabIndex = 3;
            this.tpUsers.Text = "NGƯỜI DÙNG";
            this.tpUsers.ToolTipText = "Quản lý người dùng, phân quyền, xem hoạt động";
            this.tpUsers.UseVisualStyleBackColor = true;
            // 
            // tpStatistic
            // 
            this.tpStatistic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tpStatistic.Location = new System.Drawing.Point(4, 47);
            this.tpStatistic.Name = "tpStatistic";
            this.tpStatistic.Size = new System.Drawing.Size(796, 399);
            this.tpStatistic.TabIndex = 4;
            this.tpStatistic.Text = "THỐNG KÊ";
            this.tpStatistic.ToolTipText = "Thống kê mọi sự hoạt động";
            this.tpStatistic.UseVisualStyleBackColor = true;
            // 
            // iList
            // 
            this.iList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iList.ImageStream")));
            this.iList.TransparentColor = System.Drawing.Color.Transparent;
            this.iList.Images.SetKeyName(0, "users.png");
            this.iList.Images.SetKeyName(1, "categories.png");
            this.iList.Images.SetKeyName(2, "courses.png");
            this.iList.Images.SetKeyName(3, "scheduled.png");
            this.iList.Images.SetKeyName(4, "satistics.png");
            this.iList.Images.SetKeyName(5, "add.png");
            this.iList.Images.SetKeyName(6, "delete.png");
            this.iList.Images.SetKeyName(7, "update.png");
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.AllowUserToOrderColumns = true;
            this.dgvUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsers.AutoGenerateColumns = false;
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvUsersPerID,
            this.perNameDataGridViewTextBoxColumn,
            this.phoneDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn,
            this.roleDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn});
            this.dgvUsers.DataSource = this.personDTOBindingSource;
            this.dgvUsers.Location = new System.Drawing.Point(3, 3);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.Size = new System.Drawing.Size(320, 393);
            this.dgvUsers.TabIndex = 0;
            // 
            // personDTOBindingSource
            // 
            this.personDTOBindingSource.DataSource = typeof(CourseManagementDesktopApp.Models.PersonDTO);
            // 
            // dgvUsersPerID
            // 
            this.dgvUsersPerID.DataPropertyName = "PerID";
            this.dgvUsersPerID.HeaderText = "PerID";
            this.dgvUsersPerID.Name = "dgvUsersPerID";
            this.dgvUsersPerID.ReadOnly = true;
            // 
            // perNameDataGridViewTextBoxColumn
            // 
            this.perNameDataGridViewTextBoxColumn.DataPropertyName = "PerName";
            this.perNameDataGridViewTextBoxColumn.HeaderText = "PerName";
            this.perNameDataGridViewTextBoxColumn.Name = "perNameDataGridViewTextBoxColumn";
            this.perNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // phoneDataGridViewTextBoxColumn
            // 
            this.phoneDataGridViewTextBoxColumn.DataPropertyName = "Phone";
            this.phoneDataGridViewTextBoxColumn.HeaderText = "Phone";
            this.phoneDataGridViewTextBoxColumn.Name = "phoneDataGridViewTextBoxColumn";
            this.phoneDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "Email";
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            this.emailDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // roleDataGridViewTextBoxColumn
            // 
            this.roleDataGridViewTextBoxColumn.DataPropertyName = "Role";
            this.roleDataGridViewTextBoxColumn.HeaderText = "Role";
            this.roleDataGridViewTextBoxColumn.Name = "roleDataGridViewTextBoxColumn";
            this.roleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pnUsersControl
            // 
            this.pnUsersControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnUsersControl.Controls.Add(this.btnDelete);
            this.pnUsersControl.Controls.Add(this.btnUpdate);
            this.pnUsersControl.Controls.Add(this.btnAddPerson);
            this.pnUsersControl.Controls.Add(this.textBox2);
            this.pnUsersControl.Controls.Add(this.lblDateModifier);
            this.pnUsersControl.Controls.Add(this.txbDateCreated);
            this.pnUsersControl.Controls.Add(this.lblDateCreated);
            this.pnUsersControl.Controls.Add(this.cbRole);
            this.pnUsersControl.Controls.Add(this.lblRole);
            this.pnUsersControl.Controls.Add(this.cbSex);
            this.pnUsersControl.Controls.Add(this.lblSex);
            this.pnUsersControl.Controls.Add(this.txbAddress);
            this.pnUsersControl.Controls.Add(this.lblAddress);
            this.pnUsersControl.Controls.Add(this.textBox1);
            this.pnUsersControl.Controls.Add(this.lblEmail);
            this.pnUsersControl.Controls.Add(this.txbPhone);
            this.pnUsersControl.Controls.Add(this.lblPhone);
            this.pnUsersControl.Controls.Add(this.txbPerName);
            this.pnUsersControl.Controls.Add(this.lblPerName);
            this.pnUsersControl.Controls.Add(this.txbPerID);
            this.pnUsersControl.Controls.Add(this.lblPerID);
            this.pnUsersControl.Location = new System.Drawing.Point(329, 3);
            this.pnUsersControl.Name = "pnUsersControl";
            this.pnUsersControl.Size = new System.Drawing.Size(464, 393);
            this.pnUsersControl.TabIndex = 1;
            // 
            // lblPerID
            // 
            this.lblPerID.AutoSize = true;
            this.lblPerID.Location = new System.Drawing.Point(3, 9);
            this.lblPerID.Name = "lblPerID";
            this.lblPerID.Size = new System.Drawing.Size(81, 13);
            this.lblPerID.TabIndex = 0;
            this.lblPerID.Text = "Mã người dùng:";
            this.lblPerID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbPerID
            // 
            this.txbPerID.Location = new System.Drawing.Point(111, 6);
            this.txbPerID.Name = "txbPerID";
            this.txbPerID.ReadOnly = true;
            this.txbPerID.Size = new System.Drawing.Size(347, 20);
            this.txbPerID.TabIndex = 1;
            // 
            // lblPerName
            // 
            this.lblPerName.AutoSize = true;
            this.lblPerName.Location = new System.Drawing.Point(3, 42);
            this.lblPerName.Name = "lblPerName";
            this.lblPerName.Size = new System.Drawing.Size(85, 13);
            this.lblPerName.TabIndex = 2;
            this.lblPerName.Text = "Tên người dùng:";
            // 
            // txbPerName
            // 
            this.txbPerName.Location = new System.Drawing.Point(111, 42);
            this.txbPerName.Name = "txbPerName";
            this.txbPerName.Size = new System.Drawing.Size(347, 20);
            this.txbPerName.TabIndex = 3;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(3, 113);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(73, 13);
            this.lblPhone.TabIndex = 4;
            this.lblPhone.Text = "Số điện thoại:";
            // 
            // txbPhone
            // 
            this.txbPhone.Location = new System.Drawing.Point(111, 110);
            this.txbPhone.Name = "txbPhone";
            this.txbPhone.Size = new System.Drawing.Size(347, 20);
            this.txbPhone.TabIndex = 5;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(3, 77);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "Email:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(111, 74);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(347, 20);
            this.textBox1.TabIndex = 7;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(3, 148);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(44, 13);
            this.lblAddress.TabIndex = 8;
            this.lblAddress.Text = "Địa Chỉ:";
            // 
            // txbAddress
            // 
            this.txbAddress.Location = new System.Drawing.Point(111, 145);
            this.txbAddress.Name = "txbAddress";
            this.txbAddress.Size = new System.Drawing.Size(347, 20);
            this.txbAddress.TabIndex = 9;
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.Location = new System.Drawing.Point(3, 184);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(50, 13);
            this.lblSex.TabIndex = 10;
            this.lblSex.Text = "Giới tính:";
            // 
            // cbSex
            // 
            this.cbSex.FormattingEnabled = true;
            this.cbSex.Items.AddRange(new object[] {
            "None",
            "Nam",
            "Nữ"});
            this.cbSex.Location = new System.Drawing.Point(111, 181);
            this.cbSex.Name = "cbSex";
            this.cbSex.Size = new System.Drawing.Size(144, 21);
            this.cbSex.TabIndex = 11;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(261, 184);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(50, 13);
            this.lblRole.TabIndex = 12;
            this.lblRole.Text = "Chức vụ:";
            // 
            // cbRole
            // 
            this.cbRole.FormattingEnabled = true;
            this.cbRole.Items.AddRange(new object[] {
            "None",
            "Học Viên",
            "Giảng Viên",
            "Quản Lý",
            "Người Quản Trị"});
            this.cbRole.Location = new System.Drawing.Point(317, 181);
            this.cbRole.Name = "cbRole";
            this.cbRole.Size = new System.Drawing.Size(141, 21);
            this.cbRole.TabIndex = 13;
            // 
            // lblDateCreated
            // 
            this.lblDateCreated.AutoSize = true;
            this.lblDateCreated.Location = new System.Drawing.Point(3, 225);
            this.lblDateCreated.Name = "lblDateCreated";
            this.lblDateCreated.Size = new System.Drawing.Size(75, 13);
            this.lblDateCreated.TabIndex = 14;
            this.lblDateCreated.Text = "Thời điểm tạo:";
            // 
            // txbDateCreated
            // 
            this.txbDateCreated.Location = new System.Drawing.Point(111, 222);
            this.txbDateCreated.Name = "txbDateCreated";
            this.txbDateCreated.ReadOnly = true;
            this.txbDateCreated.Size = new System.Drawing.Size(347, 20);
            this.txbDateCreated.TabIndex = 15;
            // 
            // lblDateModifier
            // 
            this.lblDateModifier.AutoSize = true;
            this.lblDateModifier.Location = new System.Drawing.Point(3, 262);
            this.lblDateModifier.Name = "lblDateModifier";
            this.lblDateModifier.Size = new System.Drawing.Size(102, 13);
            this.lblDateModifier.TabIndex = 16;
            this.lblDateModifier.Text = "Chỉnh sửa gần nhất:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(111, 259);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(347, 20);
            this.textBox2.TabIndex = 17;
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddPerson.BackColor = System.Drawing.Color.Yellow;
            this.btnAddPerson.FlatAppearance.BorderSize = 0;
            this.btnAddPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAddPerson.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAddPerson.Image = ((System.Drawing.Image)(resources.GetObject("btnAddPerson.Image")));
            this.btnAddPerson.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddPerson.Location = new System.Drawing.Point(6, 325);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(130, 63);
            this.btnAddPerson.TabIndex = 18;
            this.btnAddPerson.Text = "Thêm";
            this.btnAddPerson.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.BackColor = System.Drawing.Color.Red;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(170, 325);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(130, 63);
            this.btnUpdate.TabIndex = 19;
            this.btnUpdate.Text = "Cập Nhật";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.Lime;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.Blue;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(331, 325);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(130, 63);
            this.btnDelete.TabIndex = 20;
            this.btnDelete.Text = "Xoá";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // FDashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbDashboard);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FDashBoard";
            this.Text = "Quản Lý Khoá Học";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FCDashBoardEvent);
            this.tbDashboard.ResumeLayout(false);
            this.tpUsers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personDTOBindingSource)).EndInit();
            this.pnUsersControl.ResumeLayout(false);
            this.pnUsersControl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbDashboard;
        private System.Windows.Forms.TabPage tpCategory;
        private System.Windows.Forms.TabPage tpCourse;
        private System.Windows.Forms.TabPage tpUsers;
        private System.Windows.Forms.TabPage tpClassroom;
        private System.Windows.Forms.TabPage tpStatistic;
        private System.Windows.Forms.ImageList iList;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.BindingSource personDTOBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvUsersPerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn perNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn roleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel pnUsersControl;
        private System.Windows.Forms.Label lblPerID;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txbPhone;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txbPerName;
        private System.Windows.Forms.Label lblPerName;
        private System.Windows.Forms.TextBox txbPerID;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox cbRole;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox cbSex;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.TextBox txbAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblDateModifier;
        private System.Windows.Forms.TextBox txbDateCreated;
        private System.Windows.Forms.Label lblDateCreated;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
    }
}
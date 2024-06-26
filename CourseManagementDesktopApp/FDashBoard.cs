﻿using CourseManagementDesktopApp.Models;
using CourseManagementDesktopApp.Properties;
using CourseManagementDTO;
using CourseManagementModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseManagementDesktopApp
{
    public partial class FDashBoard : Form
    {
        public FDashBoard()
        {
            InitializeComponent();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FDashBoard));

            tpUsers.ImageIndex = 0;
            tpCategory.ImageIndex = 1;
            tpCourse.ImageIndex = 2;
            tpClassroom.ImageIndex = 3;
            tpStatistic.ImageIndex = 4;

            Bitmap mapBtnAdd = new Bitmap(((Image)(resources.GetObject("btnAddPerson.Image"))), new Size(40, 40));
            btnAddPerson.Image = (Image)mapBtnAdd;
            Bitmap mapBtnUpdate = new Bitmap(((Image)(resources.GetObject("btnUpdatePerson.Image"))), new Size(40, 40));
            btnUpdatePerson.Image = (Image)mapBtnUpdate;
            Bitmap mapBtnDelete = new Bitmap(((Image)(resources.GetObject("btnDeletePerson.Image"))), new Size(40, 40));
            btnDeletePerson.Image = (Image)mapBtnDelete;

            Bitmap mapBtnCategoryAdd = new Bitmap(((Image)(resources.GetObject("btnAddCate.Image"))), new Size(40, 40));
            btnAddCate.Image = (Image)mapBtnCategoryAdd;
            Bitmap mapBtnCategoryUpdate = new Bitmap(((Image)(resources.GetObject("btnUpdateCate.Image"))), new Size(40, 40));
            btnUpdateCate.Image = (Image)mapBtnCategoryUpdate;
            Bitmap mapBtnCategoryDelete = new Bitmap(((Image)(resources.GetObject("btnDeleteCate.Image"))), new Size(40, 40));
            btnDeleteCate.Image = (Image)mapBtnCategoryDelete;

            Bitmap mapBtnCourseAdd = new Bitmap(((Image)(resources.GetObject("btnAddCourse.Image"))), new Size(40, 40));
            btnAddCourse.Image = (Image)mapBtnCourseAdd;
            Bitmap mapBtnCourseUpdate = new Bitmap(((Image)(resources.GetObject("btnUpdateCourse.Image"))), new Size(40, 40));
            btnUpdateCourse.Image = (Image)mapBtnCourseUpdate;
            Bitmap mapBtnCourseDelete = new Bitmap(((Image)(resources.GetObject("btnDeleteCourse.Image"))), new Size(40, 40));
            btnDeleteCourse.Image = (Image)mapBtnCourseDelete;

            Bitmap mapBtnClassroomAdd = new Bitmap(((Image)(resources.GetObject("btnAddClassroom.Image"))), new Size(40, 40));
            btnAddClassroom.Image = (Image)mapBtnClassroomAdd;
            Bitmap mapBtnClassroomUpdate = new Bitmap(((Image)(resources.GetObject("btnUpdateClassroom.Image"))), new Size(40, 40));
            btnUpdateClassroom.Image = (Image)mapBtnClassroomUpdate;
            Bitmap mapBtnClassroomDelete = new Bitmap(((Image)(resources.GetObject("btnDeleteClassroom.Image"))), new Size(40, 40));
            btnDeleteClassroom.Image = (Image)mapBtnClassroomDelete;

            LoadDataComboBoxCategory();
            LoadDataComboBoxClassroom();

            LoadDataUsersDGV();
            LoadDataCategoryDGV();
            LoadDataCourseDGV();
            LoadDataClassroomDGV();
        }

        private void LoadDataComboBoxClassroom()
        {
            using(CourseManagementEntities entities = new CourseManagementEntities())
            {
                //ComboBox Course
                List<string> dataCourseID = new List<string>();
                foreach(Course course in entities.Courses.ToList())
                {
                    dataCourseID.Add($"{course.CourseID} - {course.CourseName}");
                }
                cbCourseID.DataSource = dataCourseID;

                //ComboBox Teacher
                List<string> dataTeacherID = new List<string>();
                foreach (Person person in entities.People.Where(p => p.Role.Equals("Giáo Viên")))
                {
                    dataTeacherID.Add($"{person.PerID} - {person.PerName}");
                }
                cbTeacherID.DataSource = dataTeacherID;

            }
        }

        private void LoadDataComboBoxCategory()
        {
            using(CourseManagementEntities entities = new CourseManagementEntities())
            {
                // ComboBox Category - Category Management
                List<string> dataCateParent = new List<string>();
                dataCateParent.Add("None");
                foreach(Category category in entities.Categories)
                {
                    dataCateParent.Add($"{category.CateID} - {category.CateName}");
                }
                cbCategoryParent.DataSource = dataCateParent;

                // ComboBox Category - Course Management
                dataCateParent.Remove("None");
                cbCateID.DataSource = dataCateParent;

                // ComboBox Course - Classroom Management
                List<string> dataCourses = new List<string>();
                foreach (Course course in entities.Courses)
                {
                    dataCourses.Add($"{course.CourseID} - {course.CourseName}");
                }
                cbCourseID.DataSource = dataCourses;

                // ComboBox Teacher - Classroom Management
                List<string> dataTeacher = new List<string>();
                foreach(Person person in entities.People.Where(p => p.Role.Equals("Giáo Viên")))
                {
                    dataTeacher.Add($"{person.PerID} - {person.PerName}");
                }
                cbTeacherID.DataSource = dataTeacher;
            }
        }

        private void LoadDataUsersDGV()
        {
            using(CourseManagementEntities entities = new CourseManagementEntities())
            {
                List<PersonDTO> personDTOs = new List<PersonDTO>();
                foreach (var persons in entities.People)
                {
                    personDTOs.Add(new PersonDTO()
                    {
                        PerID = persons.PerID,
                        PerName = persons.PerName,
                        Email = persons.Email,
                        Phone = persons.Phone,
                        Role = persons.Role,
                        Status = persons.Status,
                    });
                }

                dgvUsers.DataSource = personDTOs;
            }
        }

        private void LoadDataCategoryDGV()
        {
            using(CourseManagementEntities entities = new CourseManagementEntities())
            {
                List<CategoryDTO> categoryDTOs = new List<CategoryDTO>();
                foreach (var category in entities.Categories)
                {
                    categoryDTOs.Add(new CategoryDTO()
                    {
                        CateID = category.CateID,
                        CateName = category.CateName,
                        CateParent = category.CateParent == null ? 
                                null : category.CateParent + " - " + entities.Categories
                                                            .FirstOrDefault(c => c.CateID.Equals(category.CateParent)).CateName
                    });
                }
                dgvCategory.DataSource = categoryDTOs;
            }
        }

        private void LoadDataCourseDGV()
        {
            using(CourseManagementEntities entities = new CourseManagementEntities())
            {
                List<CourseDTO> courseDTOs = new List<CourseDTO>();
                foreach (var course in entities.Courses)
                {
                    courseDTOs.Add(new CourseDTO()
                    {
                        CourseID = course.CourseID,
                        CourseName = course.CourseName,
                        CourseDescription = course.CourseDescription,
                        CateID = course.CourseID + " - " + entities.Categories.FirstOrDefault(c => c.CateID.Equals(course.CateID)).CateName
                    });
                }
                dgvCourse.DataSource = courseDTOs;
            }
        }

        private void LoadDataClassroomDGV() {
            using(CourseManagementEntities entities = new CourseManagementEntities())
            {
                List<ClassroomDTO> classroomDTOs = new List<ClassroomDTO>();
                foreach (var classroom in entities.ClassRooms)
                {
                    classroomDTOs.Add(new ClassroomDTO()
                    {
                        ClassID = classroom.ClassID,
                        TypeStudy = classroom.TypeStudy,
                        DateStarted = classroom.DateStarted,
                        DateEnded = classroom.DateEnded,
                        TeacherID = classroom.TeacherID + " - " + entities.People.FirstOrDefault(p => p.PerID.Equals(classroom.TeacherID)).PerName,
                        CourseID = classroom.CourseID + " - " + entities.Courses.FirstOrDefault(c => c.CourseID.Equals(classroom.CourseID)).CourseName,
                        MaxStudent = classroom.MaxStudent,
                        ClassStatus = classroom.ClassStatus
                    });
                }
                dgvClassroom.DataSource = classroomDTOs;
            }
        }

        private void FCDashBoardEvent(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void BtnChooseImageClicked(object sender, EventArgs e)
        {
            if(ofdFileImage.ShowDialog() == DialogResult.OK)
            {
                string fileName = ofdFileImage.FileName;
            }
        }

        private string GetGenerateDataID(string type)
        {
            using(CourseManagementEntities entities = new CourseManagementEntities())
            {
                string dateCheck = DateTime.Now.ToString("yyMMdd");
                switch (type)
                {
                    case "Person":
                        {
                            string getRole = cbRole.SelectedItem == null ? "Học Viên" : cbRole.SelectedItem.ToString();
                            if(getRole.Equals("Học Viên"))
                            {
                                dateCheck = dateCheck + "1";
                                Person target = entities.People.Where(p => p.PerID.StartsWith(dateCheck)).OrderByDescending(p => p.PerID).FirstOrDefault();
                                if(target is null) 
                                {
                                    return dateCheck + "001";
                                } else
                                {
                                    return (Convert.ToInt64(target.PerID) + 1).ToString();
                                }
                            } else if(getRole.Equals("Giáo Viên"))
                            {
                                dateCheck = dateCheck + "2";
                                Person target = entities.People.Where(p => p.PerID.StartsWith(dateCheck)).OrderByDescending(p => p.PerID).FirstOrDefault();
                                if (target is null)
                                {
                                    return dateCheck + "001";
                                }
                                else
                                {
                                    return (Convert.ToInt64(target.PerID) + 1).ToString();
                                }
                            } else
                            {
                                dateCheck = dateCheck + "3";
                                Person target = entities.People.Where(p => p.PerID.StartsWith(dateCheck)).OrderByDescending(p => p.PerID).FirstOrDefault();
                                if (target is null)
                                {
                                    return dateCheck + "001";
                                }
                                else
                                {
                                    return (Convert.ToInt64(target.PerID) + 1).ToString();
                                }
                            }
                        }
                    case "Category":
                        {
                            Category cateTarget = entities.Categories
                                .Where(c => c.CateID.StartsWith(dateCheck))
                                .OrderByDescending(c => c.CateID)
                                .FirstOrDefault();
                            string cateResult = cateTarget is null ? dateCheck + "001" : (Convert.ToInt64(cateTarget.CateID) + 1).ToString();
                            return cateResult;
                        }
                    case "Course":
                        {
                            Course courseTarget = entities.Courses.Where(c => c.CourseID.StartsWith(dateCheck)).OrderByDescending(c => c.CourseID).FirstOrDefault();
                            string courseResult = courseTarget is null ? dateCheck + "001" : (Convert.ToInt64(courseTarget.CourseID) + 1).ToString();
                            return courseResult;
                        }
                    case "Classroom":
                        {
                            ClassRoom classroomTarget = entities.ClassRooms.Where(cr => cr.ClassID.StartsWith(dateCheck)).OrderByDescending(cr => cr.ClassID).FirstOrDefault();
                            string classroomResult = classroomTarget is null ? dateCheck + "001" : (Convert.ToInt64(classroomTarget.ClassID) + 1).ToString();
                            return classroomResult;
                        }
                    default:
                        {
                            throw new Exception("Can't find the type");
                        }
                }
            }
        }

        /**
         * Persons
         */
        private void CellPersonClickEvent(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgvRowPerson = dgvUsers.Rows[e.RowIndex];
            string getPersonID = dgvRowPerson.Cells[0].Value?.ToString() ?? string.Empty;

            if(getPersonID == string.Empty)
            {
                MessageBox.Show("Đã có lỗi xảy ra khi lấy dữ liệu! Vui lòng liên hệ nhà phát triển", "Người Dùng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadDataUsersDGV();
                return;
            }

            using(CourseManagementEntities entities = new CourseManagementEntities())
            {
                Person target = entities.People.FirstOrDefault(p => p.PerID.Equals(getPersonID));
                txbPerID.Text = target.PerID;
                txbPerName.Text = target.PerName;
                txbEmail.Text = target.Email;
                txbPhone.Text = target.Phone;
                txbAddress.Text = target.Address;
                cbSex.SelectedItem = target.Sex ? "Nữ" : "Nam";
                cbRole.SelectedItem = target.Role;
                dtpDateCreated.Value = target.DateCreated.Value;
                dtpDateModifier.Value = target.DateModifier.Value;
            }
        }

        private void CBRoleSelectChangedEvent(object sender, EventArgs e)
        {
            if(btnAddPerson.Text == "Xác Nhận")
            {
                txbPerID.Text = GetGenerateDataID("Person");
            } 
        }

        private void BtnAddPersonClicked(object sender, EventArgs e)
        {
            if(btnAddPerson.Text.Equals("Thêm"))
            {
                btnAddPerson.Text = "Xác Nhận";
                btnAddPerson.TextAlign = ContentAlignment.MiddleRight;
                btnUpdatePerson.Enabled = btnDeletePerson.Enabled = false;
                btnUpdatePerson.BackColor = btnDeletePerson.BackColor = Color.Gray;
                txbPerID.Text = GetGenerateDataID("Person");
                txbPerName.Text = txbEmail.Text = txbPhone.Text = txbAddress.Text = string.Empty;
                cbSex.SelectedItem = "Nam";
                cbRole.SelectedItem = "Học Viên";
                dtpDateCreated.Value = dtpDateModifier.Value = DateTime.Now;

                txbPerID.Enabled = txbPerName.Enabled = txbEmail.Enabled = txbPhone.Enabled = txbAddress.Enabled 
                    = cbSex.Enabled = cbRole.Enabled = true;
                txbPerID.Text = GetGenerateDataID("Person");
                dtpDateCreated.Value = dtpDateModifier.Value = DateTime.Now;
            } else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc là thêm người dùng này không?", "Người Dùng", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    Person target = new Person()
                    {
                        PerID = txbPerID.Text,
                        PerName = txbPerName.Text,
                        Email = txbEmail.Text,
                        Phone = txbPhone.Text,
                        Address = txbAddress.Text,
                        AccountName = txbPerID.Text,
                        Password = "123456789",
                        Sex = cbSex.SelectedItem.ToString().Equals("Nam") ? false : true,
                        Role = cbRole.SelectedItem.ToString(),
                        DateCreated = DateTime.Now,
                        DateModifier = DateTime.Now,
                        Status = 1
                    };

                    using(CourseManagementEntities entities = new CourseManagementEntities())
                    {
                        try
                        {
                            entities.People.Add(target);
                            entities.SaveChanges();
                            MessageBox.Show("Thêm người dùng thành công!", "Người Dùng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txbPerID.Text = txbPerName.Text = txbEmail.Text = txbPhone.Text = txbAddress.Text = string.Empty;
                            cbSex.SelectedItem = "Nam";
                            cbRole.SelectedItem = "Học Viên";
                            dtpDateCreated.Value = dtpDateModifier.Value = DateTime.Now;
                            btnAddPerson.Text = "Thêm";
                            btnAddPerson.TextAlign = ContentAlignment.MiddleCenter;
                            btnUpdatePerson.Enabled = btnDeletePerson.Enabled = true;
                            btnUpdatePerson.BackColor = Color.Red;
                            btnDeletePerson.BackColor = Color.Lime;
                            txbPerID.Enabled = txbPerName.Enabled = txbEmail.Enabled = txbPhone.Enabled = txbAddress.Enabled
                            = cbSex.Enabled = cbRole.Enabled = false;
                            LoadDataUsersDGV();
                        } catch
                        {
                            MessageBox.Show("Thêm người dùng thất bại! Liên hệ nhà phát triển", "Người Dùng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    
                } else if(result == DialogResult.No)
                {
                    btnAddPerson.Text = "Thêm";
                    btnAddPerson.TextAlign = ContentAlignment.MiddleCenter;
                    btnUpdatePerson.Enabled = btnDeletePerson.Enabled = true;
                    btnUpdatePerson.BackColor = Color.Red;
                    btnDeletePerson.BackColor = Color.Lime;
                    txbPerID.Text = txbPerName.Text = txbEmail.Text = txbPhone.Text = txbAddress.Text = string.Empty;
                    cbSex.SelectedItem = "Nam";
                    cbRole.SelectedItem = "Học Viên";
                    dtpDateCreated.Value = dtpDateModifier.Value = DateTime.Now;

                    txbPerID.Enabled = txbPerName.Enabled = txbEmail.Enabled = txbPhone.Enabled = txbAddress.Enabled
                    = cbSex.Enabled = cbRole.Enabled = false;
                }
            }
        }

        private void BtnUpdatePersonClicked(object sender, EventArgs e)
        {
            if(btnUpdatePerson.Text.Equals("Cập Nhật"))
            {
                btnUpdatePerson.Text = "Xác Nhận";
                btnAddPerson.Enabled = btnDeletePerson.Enabled = false;
                btnAddPerson.BackColor = btnDeletePerson.BackColor = Color.Gray;
                txbPerName.Enabled = txbEmail.Enabled = txbPhone.Enabled = txbAddress.Enabled = cbSex.Enabled = cbRole.Enabled = true;

            } else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc là cập nhật thông tin người dùng này không?", "Người Dùng", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    using(CourseManagementEntities entities = new CourseManagementEntities())
                    {
                        Person target = entities.People.FirstOrDefault(p => p.PerID.Equals(txbPerID.Text));
                        if(target is null)
                        {
                            MessageBox.Show("Không tìm thấy mã người dùng này! Liên hệ nhà phát triển", "Người Dùng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        target.PerID = txbPerID.Text;
                        target.PerName = txbPerName.Text;
                        target.Email = txbEmail.Text;
                        target.Phone = txbPhone.Text;
                        target.Address = txbAddress.Text;
                        target.Sex = cbSex.SelectedItem.ToString().Equals("Nam") ? false : true;
                        target.Role = cbRole.SelectedItem.ToString();
                        target.DateModifier = DateTime.Now;


                        entities.People.AddOrUpdate(target);
                        entities.SaveChanges();

                        MessageBox.Show("Cập nhật thông tin người dùng thành công!", "Người Dùng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataUsersDGV();
                        txbPerID.Text = txbPerName.Text = txbEmail.Text = txbPhone.Text = txbAddress.Text = string.Empty;
                        cbSex.SelectedItem = "Nam";
                        cbRole.SelectedItem = "Học Viên";
                        dtpDateCreated.Value = dtpDateModifier.Value = DateTime.Now;
                        btnUpdatePerson.Text = "Cập Nhật";
                        btnAddPerson.Enabled = btnDeletePerson.Enabled = true;
                        btnAddPerson.BackColor = Color.Yellow;
                        btnDeletePerson.BackColor = Color.Lime;
                        txbPerName.Enabled = txbEmail.Enabled = txbPhone.Enabled = txbAddress.Enabled = cbSex.Enabled = cbRole.Enabled = false;

                    }
                } else if(result == DialogResult.No)
                {
                    btnUpdatePerson.Text = "Xác Nhận";
                    btnAddPerson.Enabled = btnDeletePerson.Enabled = true;
                    btnAddPerson.BackColor = Color.Yellow;
                    btnDeletePerson.BackColor = Color.Lime;
                    txbPerName.Enabled = txbEmail.Enabled = txbPhone.Enabled = txbAddress.Enabled = cbSex.Enabled = cbRole.Enabled = false;
                    txbPerID.Text = txbPerName.Text = txbEmail.Text = txbPhone.Text = txbAddress.Text = string.Empty;
                } 
            }
        }

        private void BtnDeletePersonClicked(object sender, EventArgs e)
        {
            if(dgvUsers.SelectedRows.Count > 0)
            {
                if(MessageBox.Show("Bạn có chắc là xoá người dùng này không?", "Người Dùng", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using(CourseManagementEntities entities = new CourseManagementEntities())
                    {
                        entities.People.Remove(entities.People.FirstOrDefault(p => p.PerID.Equals(txbPerID.Text)));
                        entities.SaveChanges();
                        MessageBox.Show("Xoá người dùng thành công!", "Người Dùng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataUsersDGV();
                    }
                }
            } else
            {
                MessageBox.Show("Hãy chọn 1 dòng dữ liệu để xoá", "Người Dùng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /**
         * Categories
         */
        private void CellCategoryClickEvent(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !btnAddCate.Text.Equals("Xác Nhận"))
            {
                DataGridViewRow dgvRowCategory = dgvCategory.Rows[e.RowIndex];
                txbCategoryID.Text = dgvRowCategory.Cells[0].Value?.ToString() ?? string.Empty;
                txbCategoryName.Text = dgvRowCategory.Cells[1].Value?.ToString() ?? string.Empty;
                cbCategoryParent.SelectedItem = dgvRowCategory.Cells[2].Value != null ? dgvRowCategory.Cells[2].Value.ToString() : "None";
            }
        }

        // Add Category
        private void BtnAddCategoryClicked(object sender, EventArgs e)
        {
            if (btnAddCate.Text.Equals("Thêm"))
            {
                btnAddCate.Text = "Xác Nhận";
                btnAddCate.TextAlign = ContentAlignment.MiddleRight;
                btnUpdateCate.Enabled = btnDeleteCate.Enabled = false;
                btnUpdateCate.BackColor = btnDeleteCate.BackColor = Color.Gray;
                txbCategoryID.Text = txbCategoryName.Text = string.Empty;
                cbCategoryParent.SelectedItem = "None";
                txbCategoryID.Text = GetGenerateDataID("Category");

                txbCategoryName.ReadOnly = false;
                cbCategoryParent.Enabled = true;

            } else
            {
                DialogResult result = MessageBox.Show("Xác nhận thêm danh mục?", "Danh Mục", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if(txbCategoryName.Text == string.Empty)
                    {
                        MessageBox.Show("Tên danh mục không được để trống!", "Danh Mục", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    Category category = new Category()
                    {
                        CateID = txbCategoryID.Text,
                        CateName = txbCategoryName.Text,
                        CateParent = cbCategoryParent.SelectedItem.ToString().Equals("None") ? null : cbCategoryParent.SelectedItem.ToString().Split('-')[0].Trim()
                    };

                    using(CourseManagementEntities entities = new CourseManagementEntities())
                    {
                        try
                        {
                            entities.Categories.Add(category);
                            entities.SaveChanges();
                            MessageBox.Show("Thêm danh mục thành công!", "Thêm Danh Mục", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txbCategoryID.Text = txbCategoryName.Text = string.Empty;
                            cbCategoryParent.SelectedItem = "None";
                            btnAddCate.Text = "Thêm";
                            btnUpdateCate.Enabled = btnDeleteCate.Enabled = true;
                            btnUpdateCate.BackColor = Color.Red;
                            btnDeleteCate.BackColor = Color.Lime;
                            LoadDataCategoryDGV();

                            txbCategoryName.ReadOnly = true;
                            cbCategoryParent.Enabled = false;
                        } catch
                        {
                            MessageBox.Show("Thêm danh mục thất bại! Liên hệ nhà phát triển", "Thêm Danh Mục", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                } else if(result == DialogResult.No)
                {
                    btnAddCate.Text = "Thêm";
                    btnAddCate.TextAlign = ContentAlignment.MiddleCenter;
                    btnUpdateCate.Enabled = btnDeleteCate.Enabled = true;
                    btnUpdateCate.BackColor = Color.Red;
                    btnDeleteCate.BackColor = Color.Lime;
                    txbCategoryID.Text = txbCategoryName.Text = string.Empty;
                    txbCategoryName.ReadOnly = false;
                    cbCategoryParent.Enabled = true;
                }
            }
        }

        //Update Category
        private void BtnUpdateCategoryClicked(object sender, EventArgs e)
        {
            if(dgvCategory.SelectedRows.Count > 0)
            {
                if(btnUpdateCate.Text.Equals("Cập Nhật"))
                {
                    btnUpdateCate.Text = "Xác Nhận";
                    btnAddCate.Enabled = btnDeleteCate.Enabled = false;
                    btnAddCate.BackColor = btnDeleteCate.BackColor = Color.Gray;
                    txbCategoryName.ReadOnly = false;
                    cbCategoryParent.Enabled = true;

                } else
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn cập nhật thông tin không?", "Cập Nhật", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (result.Equals(DialogResult.Yes))
                    {
                        if(txbCategoryName.Text == string.Empty)
                        {
                            MessageBox.Show("Tên danh mục không được để trống", "Cập Nhật", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        using(CourseManagementEntities entities = new CourseManagementEntities())
                        {
                            try
                            {
                                Category category = entities.Categories.FirstOrDefault(c => c.CateID.Equals(txbCategoryID.Text));
                                category.CateName = txbCategoryName.Text;
                                category.CateParent = cbCategoryParent.SelectedItem.ToString().Equals("None") ? null : cbCategoryParent.SelectedItem.ToString().Split('-')[0].Trim();
                                entities.Categories.AddOrUpdate(category);
                                entities.SaveChanges();
                                MessageBox.Show("Cập nhật danh mục thành công!", "Cập Nhật", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadDataCategoryDGV();
                                txbCategoryID.Text = txbCategoryName.Text = string.Empty;
                                cbCategoryParent.SelectedItem = "None";
                                btnUpdateCate.Text = "Cập Nhật";
                                btnAddCate.Enabled = btnDeleteCate.Enabled = true;
                                btnAddCate.BackColor = Color.Yellow;
                                btnDeleteCate.BackColor = Color.Lime;
                                txbCategoryName.ReadOnly = true;
                                cbCategoryParent.Enabled = false;
                            } catch
                            {
                                MessageBox.Show("Cập nhật danh mục thất bại! Liên hệ nhà phát triển", "Cập Nhật", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            } 
                        }

                    } else if(result.Equals(DialogResult.No))
                    {
                        btnUpdateCate.Text = "Cập Nhật";
                        btnAddCate.Enabled = btnDeleteCate.Enabled = true;
                        txbCategoryName.ReadOnly = true;
                        cbCategoryParent.Enabled = false;
                        btnAddCate.BackColor = Color.Yellow;
                        btnDeleteCate.BackColor = Color.Lime;
                    }
                }

            } else
            {
                MessageBox.Show("Bạn phải chọn 1 dòng để có thể cập nhật thông tin", "Cập Nhật", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Delete Category
        private void BtnDeleteCategoryClicked(object sender, EventArgs e)
        {
            if(dgvCategory.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc là xoá dữ liệu này không?", "Danh Mục", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    using (CourseManagementEntities entities = new CourseManagementEntities())
                    {
                        entities.Categories.Remove(entities.Categories.FirstOrDefault(c => c.CateID.Equals(txbCategoryID.Text)));
                        entities.SaveChanges();
                        MessageBox.Show("Xoá danh mục thành công!", "Danh Mục", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txbCategoryName.Text = string.Empty;
                        cbCategoryParent.SelectedItem = "None";
                        LoadDataCategoryDGV();
                    }
                }

            } else
            {
                MessageBox.Show("Hãy chọn 1 dòng dữ liệu trong bảng để xoá", "Danh Mục", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /**
         *  Course
         */
        private void CellCourseClickEvent(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !btnAddCourse.Text.Equals("Xác Nhận"))
            {
                DataGridViewRow dgvRowCourse = dgvCourse.Rows[e.RowIndex];
                string getCourseID = dgvRowCourse.Cells[0].Value?.ToString() ?? string.Empty;
                if(getCourseID == string.Empty)
                {
                    MessageBox.Show("Đã có lỗi xảy ra khi lấy dữ liệu! Vui lòng liên hệ nhà phát triển", "Môn Học", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }

                using(CourseManagementEntities entities = new CourseManagementEntities())
                {
                    Course target = entities.Courses.FirstOrDefault(c => c.CourseID.Equals(getCourseID));
                    if(target is null)
                    {
                        MessageBox.Show("Không tìm thấy dữ liệu của môn học này", "Môn Học", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LoadDataCourseDGV();
                        return;
                    }

                    txbCourseID.Text = target.CourseID;
                    txbCourseName.Text = target.CourseName;
                    txbCourseDescription.Text = target.CourseDescription;
                    txbDateCreatedCourse.Text = target.DateCreated.ToString();
                    txbDateModifierCourse.Text = target.DateModifier.ToString();
                    cbCateID.SelectedItem = target.CateID + " - " + entities.Categories.FirstOrDefault(c => c.CateID.Equals(target.CateID)).CateName;
                }
            }
        }

        private void BtnAddCourseClicked(object sender, EventArgs e)
        {
            string getCourseID = GetGenerateDataID("Course");
            if (btnAddCourse.Text.Equals("Thêm"))
            {
                btnAddCourse.Text = "Xác Nhận";
                btnAddCourse.TextAlign = ContentAlignment.MiddleRight;
                btnUpdateCourse.Enabled = btnDeleteCourse.Enabled = false;
                btnUpdateCourse.BackColor = btnDeleteCourse.BackColor = Color.Gray;
                txbCourseID.Text = getCourseID;
                txbCourseName.Text = txbCourseDescription.Text = string.Empty;
                txbDateCreatedCourse.Text = DateTime.Now.ToString();
                txbDateModifierCourse.Text = DateTime.Now.ToString();
                txbCourseName.ReadOnly = txbCourseDescription.ReadOnly = false;
            }
            else
            {
                DialogResult result = MessageBox.Show("Xác nhận thêm môn học?", "Môn Học", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (txbCourseName.Text == string.Empty)
                    {
                        MessageBox.Show("Tên môn học không được để trống!", "Môn Học", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    Course course = new Course()
                    {
                        CourseID = getCourseID,
                        CourseName = txbCourseName.Text,
                        CourseDescription = txbCourseDescription.Text,
                        CateID = cbCateID.SelectedItem.ToString().Split('-')[0].Trim(),
                        DateCreated = DateTime.Now,
                        DateModifier = DateTime.Now
                    };

                    using (CourseManagementEntities entities = new CourseManagementEntities())
                    {
                        try
                        {
                            entities.Courses.Add(course);
                            entities.SaveChanges();
                            MessageBox.Show("Thêm môn học thành công!", "Môn Học", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txbCourseID.Text = txbCourseName.Text = txbCourseDescription.Text = string.Empty;
                            txbDateCreatedCourse.Text = DateTime.Now.ToString();
                            txbDateModifierCourse.Text = DateTime.Now.ToString();
                            btnAddCourse.Text = "Thêm";
                            btnUpdateCourse.Enabled = btnDeleteCourse.Enabled = true;
                            btnUpdateCourse.BackColor = Color.Red;
                            btnDeleteCourse.BackColor = Color.Lime;
                            txbCourseName.ReadOnly = txbCourseDescription.ReadOnly = true;
                            LoadDataCourseDGV();
                        }
                        catch
                        {
                            MessageBox.Show("Thêm môn học thất bại! Liên hệ nhà phát triển", "Môn Học", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                } else if(result == DialogResult.No)
                {
                    btnAddCourse.Text = "Thêm";
                    btnAddCourse.TextAlign = ContentAlignment.MiddleCenter;
                    btnUpdateCourse.Enabled = btnDeleteCourse.Enabled = true;
                    btnUpdateCourse.BackColor = Color.Red;
                    btnDeleteCourse.BackColor = Color.Lime;
                    txbCourseID.Text = txbCourseName.Text = txbCourseDescription.Text
                        = txbDateCreatedCourse.Text = txbDateModifierCourse.Text = string.Empty;
                    txbCourseName.ReadOnly = txbCourseDescription.ReadOnly = true;
                }
            }
        }

        private void BtnUpdateCourseClicked(object sender, EventArgs e)
        {
            if(dgvCourse.SelectedRows.Count > 0)
            {
                if (btnUpdateCourse.Text.Equals("Cập Nhật"))
                {
                    btnUpdateCourse.Text = "Xác Nhận";
                    btnAddCourse.BackColor = btnDeleteCourse.BackColor = Color.Gray;
                    btnAddCourse.Enabled = btnDeleteCourse.Enabled = false;
                    txbCourseName.ReadOnly = txbCourseDescription.ReadOnly = false;
                }
                else
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn cập nhật thông tin không?", "Cập Nhật", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        if (txbCourseName.Text == string.Empty || txbCourseDescription.Text == string.Empty)
                        {
                            MessageBox.Show("Tên môn học và mô tả không được để trống", "Cập Nhật", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        using (CourseManagementEntities entities = new CourseManagementEntities())
                        {
                            try
                            {
                                Course course = entities.Courses.FirstOrDefault(c => c.CourseID.Equals(txbCourseID.Text));
                                course.CourseName = txbCourseName.Text;
                                course.CourseDescription = txbCourseDescription.Text;
                                course.DateModifier = DateTime.Now;
                                entities.Courses.AddOrUpdate(course);
                                entities.SaveChanges();
                                MessageBox.Show("Cập nhật môn học thành công!", "Cập Nhật", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadDataCourseDGV();
                                txbCourseID.Text = txbCourseName.Text = txbCourseDescription.Text = string.Empty;
                                txbDateCreatedCourse.Text = txbDateModifierCourse.Text = string.Empty;
                                btnUpdateCourse.Text = "Cập Nhật";
                                btnAddCourse.Enabled = btnDeleteCourse.Enabled = true;
                                btnAddCourse.BackColor = Color.Red;
                                btnDeleteCourse.BackColor = Color.Lime;
                                txbCourseName.ReadOnly = txbCourseDescription.ReadOnly = true;
                            }
                            catch
                            {
                                MessageBox.Show("Cập nhật môn học thất bại! Liên hệ nhà phát triển", "Cập Nhật", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else if (result == DialogResult.No)
                    {
                        btnUpdateCourse.Text = "Cập Nhật";
                        btnAddCourse.Enabled = btnDeleteCourse.Enabled = true;
                        btnAddCourse.BackColor = Color.Yellow;
                        btnDeleteCourse.BackColor = Color.Lime;
                        txbCourseName.ReadOnly = txbCourseDescription.ReadOnly = true;
                    }
                }
            } else
            {
                MessageBox.Show("Hãy chọn 1 dòng để có thể cập nhật thông tin", "Môn Học", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDeleteCourseClicked(object sender, EventArgs e)
        {
            if(dgvCourse.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc là xoá dữ liệu này không?", "Môn Học", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    using (CourseManagementEntities entities = new CourseManagementEntities())
                    {
                        entities.Courses.Remove(entities.Courses.FirstOrDefault(c => c.CourseID.Equals(txbCourseID.Text)));
                        entities.SaveChanges();
                        MessageBox.Show("Xoá môn học thành công!", "Môn Học", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txbCourseID.Text = txbCourseName.Text = txbCourseDescription.Text = string.Empty;
                        txbDateCreatedCourse.Text = txbDateModifierCourse.Text = string.Empty;
                        LoadDataCourseDGV();
                    }
                }
            } else
            {
                MessageBox.Show("Hãy chọn 1 dòng để có thể xoá thông tin", "Môn Học", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /**
         *  Classroom
         */
        private void CellClassroomClickEvent(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !btnAddClassroom.Text.Equals("Xác Nhận"))
            {
                DataGridViewRow dgvRowClassroom = dgvClassroom.Rows[e.RowIndex];
                string getClassroomID = dgvRowClassroom.Cells[0].Value?.ToString() ?? string.Empty;
                if(getClassroomID == string.Empty)
                {
                    MessageBox.Show("Đã có lỗi xảy ra khi lấy dữ liệu! Vui lòng liên hệ nhà phát triển", "Lớp Học", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                    return;
                }

                using(CourseManagementEntities entities = new CourseManagementEntities())
                {
                    ClassRoom target = entities.ClassRooms.FirstOrDefault(cr => cr.ClassID.Equals(getClassroomID));
                    if(target is null)
                    {
                        MessageBox.Show("Không tìm thấy dữ liệu mã lớp học này: " + getClassroomID, "Lớp Học", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LoadDataClassroomDGV();
                        return;
                    }

                    txbClassroomID.Text = target.ClassID;
                    nupMaxStudent.Value = target.MaxStudent;
                    cbCourseID.SelectedItem = target.CourseID;
                    cbTeacherID.SelectedItem = target.TeacherID;
                    cbTypeStudy.SelectedItem = target.TypeStudy == 1 ? "Online" : "Offline";
                    dtpDateStarted.Value = target.DateStarted;
                    dtpDateEnded.Value = target.DateEnded;
                    txbClassDescription.Text = target.ClassDescription;
                }
            }
        }

        //Add Classroom
        private void BtnAddClassroomClicked(object sender, EventArgs e)
        {
            if(btnAddClassroom.Text.Equals("Thêm"))
            {
                btnAddClassroom.Text = "Xác Nhận";
                btnAddClassroom.TextAlign = ContentAlignment.MiddleRight;
                btnUpdateClassroom.BackColor = btnDeleteClassroom.BackColor = Color.Gray;
                btnUpdateClassroom.Enabled = btnDeleteClassroom.Enabled = false;

                txbClassroomID.Text = GetGenerateDataID("Classroom");
                nupMaxStudent.Enabled = cbCourseID.Enabled = cbTeacherID.Enabled = cbTypeStudy.Enabled = dtpDateStarted.Enabled
                    = dtpDateEnded.Enabled = txbClassDescription.Enabled = true;

            } else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc thêm một lớp học không?", "Lớp Học", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    if(dtpDateStarted.Value >= dtpDateEnded.Value)
                    {
                        MessageBox.Show("Ngày bắt đầu không thể nào sau ngày kết thúc", "Lớp Học", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    } else
                    {
                        ClassRoom target = new ClassRoom()
                        {
                            ClassID = txbClassroomID.Text,
                            MaxStudent = (int)nupMaxStudent.Value,
                            CourseID = cbCourseID.SelectedItem.ToString().Split('-')[0].Trim(),
                            TeacherID = cbTeacherID.SelectedItem.ToString().Split('-')[0].Trim(),
                            TypeStudy = cbTypeStudy.SelectedItem.ToString().Equals("Online") ? 1 : 0,
                            DateStarted = dtpDateStarted.Value,
                            DateEnded = dtpDateEnded.Value,
                            ClassDescription = txbClassDescription.Text,
                            ClassStatus = "Đang Mở"
                        };

                        using (CourseManagementEntities entities = new CourseManagementEntities())
                        {
                            try
                            {
                                entities.ClassRooms.Add(target);
                                entities.SaveChanges();
                                MessageBox.Show("Thêm lớp học thành công!", "Lớp Học", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txbClassroomID.Text = txbClassDescription.Text = string.Empty;
                                nupMaxStudent.Value = 0;
                                cbCourseID.SelectedItem = cbTeacherID.SelectedItem = cbTypeStudy.SelectedItem = null;
                                dtpDateStarted.Value = dtpDateEnded.Value = DateTime.Now;
                                btnAddClassroom.Text = "Thêm";
                                btnAddClassroom.TextAlign = ContentAlignment.MiddleCenter;
                                btnUpdateClassroom.BackColor = Color.Red;
                                btnDeleteClassroom.BackColor = Color.Lime;
                                btnUpdateClassroom.Enabled = btnDeleteClassroom.Enabled = true;
                                nupMaxStudent.Enabled = cbCourseID.Enabled = cbTeacherID.Enabled = cbTypeStudy.Enabled = dtpDateStarted.Enabled
                                = dtpDateEnded.Enabled = txbClassDescription.Enabled = false;
                                LoadDataClassroomDGV();
                            }
                            catch
                            {
                                MessageBox.Show("Thêm lớp học thất bại! Liên hệ nhà phát triển", "Lớp Học", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                } else if(result ==  DialogResult.No)
                {

                    btnAddClassroom.Text = "Thêm";
                    btnAddClassroom.TextAlign = ContentAlignment.MiddleCenter;
                    btnUpdateClassroom.BackColor = Color.Red;
                    btnDeleteClassroom.BackColor = Color.Lime;
                    btnUpdateClassroom.Enabled = btnDeleteClassroom.Enabled = true;

                    txbClassroomID.Text = txbClassDescription.Text = string.Empty;
                    nupMaxStudent.Enabled = cbCourseID.Enabled = cbTeacherID.Enabled = cbTypeStudy.Enabled = dtpDateStarted.Enabled
                    = dtpDateEnded.Enabled = txbClassDescription.Enabled = false;
                }
            }
        }

        //Update Classroom
        private void BtnUpdateClassroomClicked(object sender, EventArgs e)
        {
            if (dgvClassroom.SelectedRows.Count > 0)
            {
                if (btnUpdateClassroom.Text.Equals("Cập Nhật"))
                {
                    btnUpdateClassroom.Text = "Xác Nhận";
                    btnAddClassroom.BackColor = btnDeleteClassroom.BackColor = Color.Gray;
                    btnAddClassroom.Enabled = btnDeleteClassroom.Enabled = false;
                    nupMaxStudent.Enabled = cbCourseID.Enabled = cbTeacherID.Enabled = cbTypeStudy.Enabled = dtpDateStarted.Enabled
                        = dtpDateEnded.Enabled = txbClassDescription.Enabled = true;
                }
                else
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc cập nhật thông tin này không?", "Lớp Học", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {

                        if (dtpDateStarted.Value >= dtpDateEnded.Value)
                        {
                            MessageBox.Show("Ngày bắt đầu không thể nào sau ngày kết thúc", "Lớp Học", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        using (CourseManagementEntities entities = new CourseManagementEntities())
                            try
                            {
                                ClassRoom target = new ClassRoom()
                                {
                                    ClassID = txbClassroomID.Text,
                                    MaxStudent = (int)nupMaxStudent.Value,
                                    CourseID = cbCourseID.SelectedItem.ToString().Split('-')[0].Trim(),
                                    TeacherID = cbTeacherID.SelectedItem.ToString().Split('-')[0].Trim(),
                                    TypeStudy = cbTypeStudy.SelectedItem.ToString().Equals("Online") ? 1 : 0,
                                    DateStarted = dtpDateStarted.Value,
                                    DateEnded = dtpDateEnded.Value,
                                    ClassDescription = txbClassDescription.Text,
                                    ClassStatus = "Đang Mở"
                                };

                                entities.ClassRooms.AddOrUpdate(target);
                                entities.SaveChanges();
                                MessageBox.Show("Cập nhật lớp học thành công!", "Lớp Học", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txbClassroomID.Text = txbClassDescription.Text = string.Empty;
                                nupMaxStudent.Value = 0;
                                cbCourseID.SelectedItem = cbTeacherID.SelectedItem = cbTypeStudy.SelectedItem = null;
                                dtpDateStarted.Value = dtpDateEnded.Value = DateTime.Now;
                                btnUpdateClassroom.Text = "Cập Nhật";
                                btnAddClassroom.BackColor = Color.Yellow;
                                btnDeleteClassroom.BackColor = Color.Lime;
                                btnAddClassroom.Enabled = btnDeleteClassroom.Enabled = true;
                                nupMaxStudent.Enabled = cbCourseID.Enabled = cbTeacherID.Enabled = cbTypeStudy.Enabled = dtpDateStarted.Enabled = dtpDateEnded.Enabled
                                    = txbClassDescription.Enabled = false;

                                LoadDataClassroomDGV();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Đã xảy ra lỗi trong quá trình cập nhật! Liên hệ nhà phát triển", "Lớp Học", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                    } else if(result == DialogResult.No)
                    {
                        btnUpdateClassroom.Text = "Cập Nhật";
                        btnAddClassroom.BackColor = Color.Yellow;
                        btnDeleteClassroom.BackColor = Color.Lime;
                        btnAddClassroom.Enabled = btnDeleteClassroom.Enabled = true;
                        nupMaxStudent.Enabled = cbCourseID.Enabled = cbTeacherID.Enabled = cbTypeStudy.Enabled = dtpDateStarted.Enabled = dtpDateEnded.Enabled 
                            = txbClassDescription.Enabled = false;
                        nupMaxStudent.Value = 0;
                        dtpDateEnded.Value = dtpDateStarted.Value = DateTime.Now;
                        txbClassDescription.Text = string.Empty;
                    }
                }
            } else
            {
                MessageBox.Show("Hãy chọn 1 dòng để có thể cập nhật thông tin", "Lớp Học", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Delete Classroom
        private void BtnDeleteClassroomClicked(object sender, EventArgs e)
        {
            if(dgvClassroom.SelectedCells.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn xoá dữ liệu này không?", "Lớp Học", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    using (CourseManagementEntities entities = new CourseManagementEntities())
                    {
                        entities.ClassRooms.Remove(entities.ClassRooms.FirstOrDefault(cr => cr.ClassID.Equals(txbClassroomID.Text)));
                        entities.SaveChanges();
                        MessageBox.Show("Xoá lớp học thành công!", "Lớp Học", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txbClassroomID.Text = txbClassDescription.Text = string.Empty;
                        nupMaxStudent.Value = 0;
                        cbCourseID.SelectedItem = cbTeacherID.SelectedItem = cbTypeStudy.SelectedItem = null;
                        dtpDateStarted.Value = dtpDateEnded.Value = DateTime.Now;
                        LoadDataClassroomDGV();
                    }
                }
            } else
            {
                MessageBox.Show("Hãy chọn 1 dòng dữ liệu để xoá!", "Lớp Học", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}

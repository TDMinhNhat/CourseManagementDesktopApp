using CourseManagementDesktopApp.Models;
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
            Bitmap mapBtnUpdate = new Bitmap(((Image)(resources.GetObject("btnUpdate.Image"))), new Size(40, 40));
            btnUpdate.Image = (Image)mapBtnUpdate;
            Bitmap mapBtnDelete = new Bitmap(((Image)(resources.GetObject("btnDelete.Image"))), new Size(40, 40));
            btnDelete.Image = (Image)mapBtnDelete;

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

            LoadDataComboBox();

            LoadDataUsersDGV();
            LoadDataCategoryDGV();
            LoadDataCourseDGV();
            LoadDataClassroomDGV();
        }

        private void LoadDataComboBox()
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
                        MaxStudent = classroom.MaxStudent
                    });
                }
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
                            return null;
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

        

    }
}

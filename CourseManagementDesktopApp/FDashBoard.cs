using CourseManagementDesktopApp.Models;
using CourseManagementDesktopApp.Properties;
using CourseManagementDTO;
using CourseManagementModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FDashBoard));

            tpUsers.ImageIndex = 0;
            tpCategory.ImageIndex = 1;
            tpCourse.ImageIndex = 2;
            tpClassroom.ImageIndex = 3;
            tpStatistic.ImageIndex = 4;

            Bitmap mapBtnAdd = new Bitmap(((System.Drawing.Image)(resources.GetObject("btnAddPerson.Image"))), new Size(40, 40));
            btnAddPerson.Image = (Image)mapBtnAdd;
            Bitmap mapBtnUpdate = new Bitmap(((System.Drawing.Image)(resources.GetObject("btnUpdate.Image"))), new Size(40, 40));
            btnUpdate.Image = (Image)mapBtnUpdate;
            Bitmap mapBtnDelete = new Bitmap(((System.Drawing.Image)(resources.GetObject("btnDelete.Image"))), new Size(40, 40));
            btnDelete.Image = (Image)mapBtnDelete;

            Bitmap mapBtnCategoryAdd = new Bitmap(((System.Drawing.Image)(resources.GetObject("btnAddCate.Image"))), new Size(40, 40));
            btnAddCate.Image = (Image)mapBtnCategoryAdd;
            Bitmap mapBtnCategoryUpdate = new Bitmap(((System.Drawing.Image)(resources.GetObject("btnUpdateCate.Image"))), new Size(40, 40));
            btnUpdateCate.Image = (Image)mapBtnCategoryUpdate;
            Bitmap mapBtnCategoryDelete = new Bitmap(((System.Drawing.Image)(resources.GetObject("btnDeleteCate.Image"))), new Size(40, 40));
            btnDeleteCate.Image = (Image)mapBtnCategoryDelete;

            Bitmap mapBtnCourseAdd = new Bitmap(((System.Drawing.Image)(resources.GetObject("btnAddCourse.Image"))), new Size(40, 40));
            btnAddCourse.Image = (Image)mapBtnCourseAdd;
            Bitmap mapBtnCourseUpdate = new Bitmap(((System.Drawing.Image)(resources.GetObject("btnUpdateCourse.Image"))), new Size(40, 40));
            btnUpdateCourse.Image = (Image)mapBtnCourseUpdate;
            Bitmap mapBtnCourseDelete = new Bitmap(((System.Drawing.Image)(resources.GetObject("btnDeleteCourse.Image"))), new Size(40, 40));
            btnDeleteCourse.Image = (Image)mapBtnCourseDelete;

            LoadDataUsersDGV();
            LoadDataCategoryDGV();
            LoadDataCourseDGV();
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
                        CateParent = category.CateParent
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
                        CateID = course.CourseID
                    });
                }
                dgvCourse.DataSource = courseDTOs;
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
    }
}

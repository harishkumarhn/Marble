using Marbale.BusinessObject.Inventory;
using Marbale.DataAccess;
using Marble.Business;
using Marble.Business.InventoryBL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marbale.Inventory.Master
{
    public partial class frmCategory : Form
    {
        public frmCategory()
        {
            InitializeComponent();
            InitialiseUI initialiseUI = new InitialiseUI();
            initialiseUI.SetSubFormUI(this);

        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            PopulateCategoryGrid();
        }


        void PopulateCategoryGrid()
        {
            CategoryBL categoryBL = new CategoryBL();
            List<Category> lstCategory = categoryBL.GetCategory();

            BindingSource categoryListBS = new BindingSource();
 
            if (categoryListBS != null)
                categoryListBS.DataSource = new SortableBindingList<Category>(lstCategory);
            else
            {
                categoryListBS.DataSource = new SortableBindingList<Category>();
            }

            dgvCategory.DataSource = categoryListBS;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateCategoryGrid();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CategoryBL categoryBL = new CategoryBL();
                BindingSource categoryListBS = (BindingSource)dgvCategory.DataSource;
                var categoryList= (SortableBindingList<Category>)categoryListBS.DataSource;
                if (categoryList.Count > 0)
                {
                    foreach (Category category in categoryList)
                    {
                        if (category.IsChanged)
                        {
                            if (string.IsNullOrEmpty(category.CategoryName))
                            {
                                MessageBox.Show("Please enter the name.");
                                return;
                            }
                            else
                            {
                                categoryBL.Save(category,"rakshith");
                            }
                        }

                       
                    }
                    PopulateCategoryGrid();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvCategory.SelectedRows.Count <= 0 && this.dgvCategory.SelectedCells.Count <= 0)
                {
                    MessageBox.Show("No record selected");
                    return;
                }
               
                if (this.dgvCategory.SelectedCells.Count > 0)
                {
                    foreach (DataGridViewCell cell in this.dgvCategory.SelectedCells)
                    {
                        dgvCategory.Rows[cell.RowIndex].Selected = true;
                    }
                }
                foreach (DataGridViewRow row in this.dgvCategory.SelectedRows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        if (Convert.ToInt32(row.Cells[0].Value) < 0)
                        {
                            dgvCategory.Rows.RemoveAt(row.Index);
                        }
                        else
                        {
                            if ( MessageBox.Show("Do you want to Delete", "Confirm Inactivation.", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                BindingSource categoryListBS = (BindingSource)dgvCategory.DataSource;
                                var categoryList = (SortableBindingList<Category>)categoryListBS.DataSource;
                                Category category = categoryList[row.Index];
                                category.IsActive = false;
                                CategoryBL categoryBL = new CategoryBL();
                                categoryBL.Save(category, "rakshith");
                            }
                        }
                    }
                }

                PopulateCategoryGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}

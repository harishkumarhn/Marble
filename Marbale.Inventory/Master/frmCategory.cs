using Marbale.BusinessObject.Inventory;
using Marble.Business;
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
        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            PoupulateCategoryGrid();
        }


        void PoupulateCategoryGrid()
        {
            CategoryBL categoryBL = new CategoryBL();
            List<Category> lstCategory = categoryBL.GetCategory();

            BindingSource categoryListBS = new BindingSource();

            if (lstCategory != null && lstCategory.Count > 0)
            {
                categoryListBS.DataSource = lstCategory;
            }
            else
            {
                categoryListBS.DataSource = new List<Vendor>();
            }

            dgvCategory.DataSource = categoryListBS;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PoupulateCategoryGrid();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CategoryBL categoryBL = new CategoryBL();
                BindingSource categoryListBS = (BindingSource)dgvCategory.DataSource;
                var categoryList = (List<Category>)categoryListBS.DataSource;

                if (categoryList.Count > 0)
                {
                    foreach (Category category in categoryList)
                    {
                        if (category.IsChanged)
                        {
                            categoryBL.Save(category);
                        }
                    }
                    PoupulateCategoryGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

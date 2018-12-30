using Marbale.SiteSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marbale.Product
{
    public partial class MarbleAdmin : Form
    {
         bool a = false;
         public MarbleAdmin()
        {
            InitializeComponent();
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ProductForm_Load_1(object sender, EventArgs e)
        {
            panel1.Height = 0;
            btnGame.Top = ProductPanel.Top;
            btnSiteSetup.Top = btnGame.Bottom;
            ReportButton.Top = btnSiteSetup.Bottom;
         //   linkLabel1.Hide();
          //  linkLabel2.Hide();
            SiteSetUpPanel.Hide();
            gamePanel.Hide();
            ReportsPanel.Hide();
        }
        private void POSShiftViewlinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void WirelesslinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void btnGame_Click(object sender, EventArgs e)
        {
            if (a == false)
            {
                ProductPanel.Hide();
                btnSiteSetup.Top = gamePanel.Top + gamePanel.Height + 10;
                
                //panel1.Height = 231;
               // btnGame.Top = ProductPanel.Top + ProductPanel.Height + 10;
                btnSiteSetup.Top = gamePanel.Bottom;
                ReportButton.Top = btnSiteSetup.Bottom;
                gamePanel.Show();
                a = true;
            }
            else
            {
                panel1.Height = 0;
                btnGame.Top = ProductPanel.Top;
                btnSiteSetup.Top = btnGame.Bottom;
                ReportButton.Top = btnSiteSetup.Bottom;
                gamePanel.Hide();
                a = false;
            }
        }

        private void btnSiteSetup_Click(object sender, EventArgs e)
        {
            if (a == false)
            {
                gamePanel.Hide();
                ProductPanel.Hide();
                ReportButton.Top = SiteSetUpPanel.Top + SiteSetUpPanel.Height + 10;

                //panel1.Height = 231;
                // btnGame.Top = ProductPanel.Top + ProductPanel.Height + 10;
                ReportButton.Top = SiteSetUpPanel.Bottom;
              //  ReportButton.Top = btnSiteSetup.Bottom;
                SiteSetUpPanel.Show();
                a = true;
            }
            else
            {
                panel1.Height = 0;
                btnSiteSetup.Top = btnGame.Bottom;
               ReportButton.Top = btnSiteSetup.Bottom;
              //  ReportButton.Top = btnSiteSetup.Bottom;
                SiteSetUpPanel.Hide();
                a = false;
            }
        }

        private void ReportButton_Click(object sender, EventArgs e)
        {
            if (a == false)
            {
                SiteSetUpPanel.Hide();
                ProductPanel.Hide();
                gamePanel.Hide();
              //  ReportButton.Top = SiteSetUpPanel.Top + SiteSetUpPanel.Height + 10;

                //panel1.Height = 231;
                // btnGame.Top = ProductPanel.Top + ProductPanel.Height + 10;
              //  ReportButton.Top = SiteSetUpPanel.Bottom;
                ReportsPanel.Top=ReportButton.Bottom;
                ReportsPanel.Show();
                a = true;
            }
            else
            {
                panel1.Height = 0;
                ReportsPanel.Hide();
                a = false;
            }
        }
        private void btnProduct_Click(object sender, EventArgs e)
        {
            if (a == false)
            {

                //panel1.Height = 231;
                btnGame.Top = ProductPanel.Top + ProductPanel.Height + 10;
                btnSiteSetup.Top = btnGame.Bottom;
                ReportButton.Top = btnSiteSetup.Bottom;
                ProductPanel.Show();
                a = true;
            }
            else
            {
                panel1.Height = 0;
                btnGame.Top = ProductPanel.Top;
                btnSiteSetup.Top = btnGame.Bottom;
                ReportButton.Top = btnSiteSetup.Bottom;
                ProductPanel.Hide();
                a = false;
            }
        }

        private void productlink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProductSubForms subform = new ProductSubForms();
               subform.ShowDialog();
        }

        private void btnProduct_MouseHover(object sender, EventArgs e)
        {
            btnProduct.BackColor = Color.FromArgb(72,61,139);
        }

        private void btnProduct_MouseLeave(object sender, EventArgs e)
        {
            btnProduct.BackColor = Color.FromArgb(128, 128, 255);
        }

        private void ConfigurationlinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SiteConfiguration sitesetup = new SiteConfiguration();
            sitesetup.ShowDialog();
        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}

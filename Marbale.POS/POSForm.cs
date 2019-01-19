using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Marbale.Business;
using Marbale.BusinessObject;

namespace Marbale.POS
{
    public partial class POSForm : Form
    {
        //LoginModel loginmodel = new LoginModel();
        ProductBusiness marbleb= new ProductBusiness();
        POSBusiness posBusiness = new POSBusiness();
        string CardNumber = "";
        bool status = true;
        IList<POSProperties> CardStatuses = new List<POSProperties>();
        public POSForm()
        {
            InitializeComponent();
            this.ActiveControl = txtCardNumber;
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {

        }

        private void txtCardNumber_TextChanged(object sender, EventArgs e)

    {
                    POSOperations pos = new POSOperations();
                    if (CardNumber.Length >= 12)
                    {
                        txtCardNumber.Clear();
                        CardNumber= "";
                       
                       
                    }
          
            if (CardNumber.Length <= 11 && status==true)
            {
                this.ActiveControl = txtCardNumber;
                Console.ReadLine();
                txtCardNumber.ForeColor = Color.Red;
                        CardNumber = txtCardNumber.Text;
                      //  CardNumber = Regex.Replace(CardNumber, @"\n|\t|\r", "");
                
                //txtCardNumber.Text = CardNumber;
             //   POSOperations pos = new POSOperations();
                
              
                    CardStatuses = pos.IssuedCards();
                if (CardNumber.Length >= 11)
                {
                    
                       
                    if (CardNumber.Length > 10)
                    {

                       
                        CardNumber = Regex.Replace(CardNumber, @"\n|\t|\r", "");
                        if (CardNumber.Length > 10)
                        {
                            CardNumber = CardNumber.Substring(CardNumber.Length - 10);
                        }
                        txtCardNumber.Text = CardNumber.ToUpper();
                        //CardNumber = CardNumber.Substring(CardNumber.Length - 10);
                    }
                    foreach (var item in CardStatuses)
	                      {
                              
                     
                        if (Convert.ToString(item.CardNumber) == CardNumber)
                              { 

                                  status = false;
                                  break;
                              }          
	                      }
                    if(status==true)
                    {
                      
                       
                                
                        lblDisplayCardStatus.Text = "New Card";
                        string CardNum = CardNumber;
                        pos.InserCardNumber(CardNum);
                        CardNumber = "";
                     

                    }
                    else
                    {
                         lblDisplayCardStatus.Text = "Issued Card";
                         CardNumber = "";
                         status = true;
                    //     System.Threading.Thread.Sleep(2000);
                   
                    }
                }
            }
        }

        private void POSForm_Load(object sender, EventArgs e)
        {
           this.MinimumSize = new System.Drawing.Size(this.Width, this.Height);

            // no larger than screen size
         //   this.MaximumSize = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, (int)System.Windows.SystemParameters.PrimaryScreenHeight);

            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            POSOperations pos = new POSOperations();
          //  TaskPanel.Hide();
         
            var dataTable = marbleb.GetAppSettings("POS");
            ChangePOSColor(dataTable);
            CardStatuses = pos.IssuedCards();
            var datatable = posBusiness.GetDefaultPaymentDropdown();
            cmbDefaultCashMode.DataSource = datatable;
            cmbDefaultCashMode.DisplayMember = "CashMode";
            cmbDefaultCashMode.ValueMember = "id";
        }

        private void ChangePOSColor(List<Marbale.BusinessObject.AppSetting> dataTable)
        {

            panel3.BackColor =Color.FromName(dataTable.Where(o => o.Name == "POS_SKIN_COLOR").Select(o => o.Value).Single());
        }

        private void TaskPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ToolSubPanel.Hide();
            btnTransperCard.Show();
            //CardValueAmount.Hide();
            //TaskPanel.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnTransperCard.Hide();
            //CardValueAmount.Show();
          //  CardAmountPanel.Show();
        }

        private void cmbDefaultCashMode_SelectedIndexChanged(object sender, EventArgs e)
        {

        //    var datatable = posBusiness.GetDefaultPaymentDropdown();
        }

        private void btnChangelogin_Click(object sender, EventArgs e)
        {
            if (LoginModel.Password == txtCurrentPassword.Text && txtNewPassword.Text==txtRenterNewPassword.Text)
            {
           int updateloginCondition=     posBusiness.UpdatePOSUserCredential(txtCurrentPassword.Text);
           if (updateloginCondition == 1)
           {
               lblErrorDisplaymsgPOS.Text = "Upated Successfully";
           }
           else
           {
               lblErrorDisplaymsgPOS.Text = "Error Occured";
           }
            }
            else
            {
                POSDisplayErrorMsg();
               // MessageBox.Show("Please Enter Correct credentials");
            }
        }
        public void POSDisplayErrorMsg()
        {
            lblErrorDisplaymsgPOS.Show();
            lblErrorDisplaymsgPOS.BackColor = Color.Red;
            lblErrorDisplaymsgPOS.ForeColor = Color.White;
            lblErrorDisplaymsgPOS.Text = "Error Occured";
        }
        public void ResetErrorMsgPOS()
        {
            lblErrorDisplaymsgPOS.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ToolSubPanel.Show();
        }

        private void btnTransperCard_Click(object sender, EventArgs e)
        {
            CardTask cardtask = new CardTask();
            cardtask.StartPosition = FormStartPosition.CenterParent;
        }

        private void ChangeSkinColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
            {
             CardReaderPanel.BackColor=panel3.BackColor = colorDialog1.Color;
               
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            var dataTable = marbleb.GetAppSettings("POS");
            ChangePOSColor(dataTable);
            ResetErrorMsgPOS();
        }
    }
}

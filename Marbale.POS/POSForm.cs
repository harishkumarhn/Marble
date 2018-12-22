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

namespace Marbale.POS
{
    public partial class POSForm : Form
    {
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
            POSOperations pos = new POSOperations();
            CardStatuses = pos.IssuedCards();

        }

        private void TaskPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

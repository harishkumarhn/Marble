using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marbale.Inventory
{
    public class InitialiseUI
    {
        public void SetUI(Form currentForm)
        {
            Color Warn1Color = Color.FromArgb(255, 0, 0);//default colour
            currentForm.BackColor = ColorTranslator.FromHtml("#B983FF");  
        }

        public void SetSubFormUI(Form currentForm)
        {
            Color Warn1Color = Color.FromArgb(255, 0, 0);//default colour
            currentForm.BackColor = ColorTranslator.FromHtml("#B983FF");

            foreach (Control control in currentForm.Controls)
            {
                if (control.GetType() == typeof(Panel))
                {

                }

                if (control.GetType() == typeof(Button))
                {
                    Button bt = (Button)control;

                     bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        bt.BackColor = currentForm.BackColor = ColorTranslator.FromHtml("#B983FF");

                    bt.ForeColor = currentForm.BackColor = ColorTranslator.FromHtml("#FFF");
                }
                if (control.GetType() == typeof(DataGridView))
                {
                    DataGridView dv = (DataGridView)control;
                    dv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#5C7AEA");
                    dv.BackgroundColor = ColorTranslator.FromHtml("#F6F2D4");
                }
               
                //AddToList((Panel)control); //this function pass the panel object so further processing can be done 
            }
        }
    }
}

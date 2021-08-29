using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marble.Business
{
    public class Utility
    {

        MarbleEnvironment environment = new MarbleEnvironment();


        public DataGridViewCellStyle GetGViewDateTimeCellStyle()
        {
             
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            style.Format = environment.DATETIME_FORMAT;
            return style;
        }

        public DataGridViewCellStyle GetGViewAmountCellStyle()
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();

            style.Alignment = DataGridViewContentAlignment.MiddleRight;
            style.Format = environment.AMOUNT_FORMAT;
            return style;
        }

        public DataGridViewCellStyle GetGViewNumericCellStyle()
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();

            style.Alignment = DataGridViewContentAlignment.MiddleRight;
            style.Format = environment.NUMBER_FORMAT;
            return style;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marbale.POS.Common
{
    public static class NumberPadForm
    {
        static NumberPad numPad;
        static Form FormNumPad;
        static Form _parent;

        public static double ShowNumberPadForm(string FormText, char firstKey, Form ParentForm = null)
        {
            _parent = ParentForm;

            initialize(FormText);
            numPad.GetKey(firstKey);

            DialogResult DR = FormNumPad.ShowDialog(ParentForm);
            return numPad.ReturnNumber;
        }

        public static double ShowNumberPadForm(string FormText, string firstString, Form ParentForm = null)
        {
            _parent = ParentForm;

            initialize(FormText);
            numPad.handleaction(firstString);
            numPad.NewEntry = true;

            DialogResult DR = FormNumPad.ShowDialog(ParentForm);
            return numPad.ReturnNumber;
        }

        static void initialize(string FormText)
        {
            FormNumPad = new Form();
            FormNumPad.Name = "FormNumPad";
            FormNumPad.Text = FormText;
            if (_parent != null)
            {
                FormNumPad.StartPosition = FormStartPosition.Manual;
                FormNumPad.Location = new System.Drawing.Point(_parent.Location.X + _parent.Width / 2 - FormNumPad.Width / 2,
                                        _parent.Location.Y + _parent.Height / 2 - FormNumPad.Height / 2);
            }
            else
                FormNumPad.StartPosition = FormStartPosition.CenterParent;

            FormNumPad.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            FormNumPad.SizeGripStyle = SizeGripStyle.Hide;
            FormNumPad.MinimizeBox = FormNumPad.MaximizeBox = false;

            numPad = new NumberPad("#,###", 2); // Amount_Form, RoundingPrecision
            Panel NumberPadVarPanel = numPad.NumPadPanel();
            FormNumPad.Size = NumberPadVarPanel.Size;
            FormNumPad.Width = FormNumPad.Width + 15;
            FormNumPad.Height = FormNumPad.Height + 35;
            NumberPadVarPanel.Location = new System.Drawing.Point(FormNumPad.DisplayRectangle.Width / 2 - NumberPadVarPanel.Width / 2, FormNumPad.DisplayRectangle.Height / 2 - NumberPadVarPanel.Height / 2);
            FormNumPad.Controls.Add(NumberPadVarPanel);
            numPad.setReceiveAction = EventnumPadOKReceived;

            FormNumPad.KeyPreview = true;

            FormNumPad.KeyPress += new KeyPressEventHandler(FormNumPad_KeyPress);
            FormNumPad.FormClosing += new FormClosingEventHandler(FormNumPad_FormClosing);
        }

        static void FormNumPad_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FormNumPad.DialogResult == DialogResult.Cancel)
                numPad.ReturnNumber = -1;
        }

        static void FormNumPad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                FormNumPad.DialogResult = DialogResult.Cancel;
                FormNumPad.Close();
            }
            else
                numPad.GetKey(e.KeyChar);
        }

        private static void EventnumPadOKReceived()
        {
            FormNumPad.DialogResult = DialogResult.OK;
            FormNumPad.Close();
        }
    }
}

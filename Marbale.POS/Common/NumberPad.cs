using Marbale.POS.Keypad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marbale.POS.Common
{
    public class NumberPad
    {
        private System.Windows.Forms.TextBox textBoxNumPadDisplay;
        private System.Windows.Forms.Panel panelNumpadDisplay;
        private System.Windows.Forms.Panel panelNumPad;
        private System.Windows.Forms.Button RefButton;

        private System.Windows.Forms.Button OKButton;

        public bool NewEntry = true;

        public delegate void ReceiveAction();
        ReceiveAction receiveAction;

        public delegate void KeyAction();
        KeyAction keyAction;

        public double ReturnNumber;

        static string decimalStr = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
        char decimalChar = decimalStr[0];
        static string AMOUNT_FORMAT;
        static int RoundingPrecision = 2;

        public ReceiveAction setReceiveAction
        {
            get
            {
                return receiveAction;
            }
            set
            {
                receiveAction = value;
            }
        }

        public KeyAction setKeyAction
        {
            get
            {
                return keyAction;
            }
            set
            {
                keyAction = value;
            }
        }

        public System.Windows.Forms.Panel NumPadPanel()
        {
            return panelNumPad;
        }

        public NumberPad(string AmountFormat, int RoundingPrecision = 2)
        {
            AMOUNT_FORMAT = AmountFormat;

            panelNumPad = new System.Windows.Forms.Panel();
            panelNumpadDisplay = new System.Windows.Forms.Panel();

            textBoxNumPadDisplay = new System.Windows.Forms.TextBox();
            textBoxNumPadDisplay.BackColor = System.Drawing.Color.Gainsboro;
            textBoxNumPadDisplay.Font = new System.Drawing.Font("Arial", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textBoxNumPadDisplay.BorderStyle = BorderStyle.None;
            textBoxNumPadDisplay.Location = new System.Drawing.Point(1, 3);
            textBoxNumPadDisplay.Name = "textBoxNumPadDisplay";
            textBoxNumPadDisplay.Size = new System.Drawing.Size(250, 35);
            textBoxNumPadDisplay.Text = 0.ToString(AMOUNT_FORMAT);
            textBoxNumPadDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            textBoxNumPadDisplay.TabStop = false;
            textBoxNumPadDisplay.ReadOnly = true;

            panelNumpadDisplay.BackColor = System.Drawing.Color.Gray;
            panelNumpadDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelNumpadDisplay.Controls.Add(textBoxNumPadDisplay);
            panelNumpadDisplay.Location = new System.Drawing.Point(4, 3);
            panelNumpadDisplay.Name = "panelNumpadDisplay";
            panelNumpadDisplay.Size = new System.Drawing.Size(255, 45);

            // panelNumPad
            // 
            panelNumPad.Controls.Add(panelNumpadDisplay);
            panelNumPad.Location = new System.Drawing.Point(1, 0);
            panelNumPad.Name = "panelNumPad";
            panelNumPad.Size = new System.Drawing.Size(265, 312);
            panelNumPad.BackColor = System.Drawing.Color.Gray;
            panelNumPad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            RefButton = new Button();

            RefButton.BackColor = System.Drawing.Color.White;
            RefButton.Font = new System.Drawing.Font("Arial", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            RefButton.ForeColor = System.Drawing.Color.White;
            RefButton.Location = new System.Drawing.Point(3, 50);
            RefButton.Name = "buttonNumPad";
            RefButton.Size = new System.Drawing.Size(65, 65);
            RefButton.Text = "Ref";
            RefButton.UseVisualStyleBackColor = false;

            for (int i = 1; i <= 14; i++)
            {
                Button buttonNumPad = new Button();

                buttonNumPad.FlatStyle = FlatStyle.Flat;
                buttonNumPad.FlatAppearance.BorderSize = 0;
                buttonNumPad.FlatAppearance.MouseOverBackColor =
                    buttonNumPad.FlatAppearance.MouseDownBackColor =
                    buttonNumPad.BackColor = System.Drawing.Color.Transparent;
               // buttonNumPad.BackgroundImage = KeyPadResources._0;
                buttonNumPad.BackgroundImageLayout = ImageLayout.Stretch;

                buttonNumPad.Font = RefButton.Font;
                buttonNumPad.ForeColor = RefButton.ForeColor;
                buttonNumPad.Size = RefButton.Size;
                buttonNumPad.UseVisualStyleBackColor = RefButton.UseVisualStyleBackColor;
                buttonNumPad.Name = RefButton.Name + i.ToString();
                int row, col;
                row = Math.DivRem(i - 1, 4, out col);
                buttonNumPad.Location = new System.Drawing.Point(RefButton.Location.X + col * (RefButton.Size.Width - 1), RefButton.Location.Y + row * (RefButton.Size.Height - 1));

                switch (i)
                {
                    case 1: buttonNumPad.BackgroundImage = KeyPadResources._1; break;
                    case 2: buttonNumPad.BackgroundImage = KeyPadResources._2; break;
                    case 3: buttonNumPad.BackgroundImage = KeyPadResources._3; break;
                    case 4: buttonNumPad.BackgroundImage = KeyPadResources.clear; break;
                    case 5: buttonNumPad.BackgroundImage = KeyPadResources._4; break;
                    case 6: buttonNumPad.BackgroundImage = KeyPadResources._5; break;
                    case 7: buttonNumPad.BackgroundImage = KeyPadResources._6; break;
                    case 8: buttonNumPad.BackgroundImage = KeyPadResources.back; break;
                    case 9: buttonNumPad.BackgroundImage = KeyPadResources._7; break;
                    case 10: buttonNumPad.BackgroundImage = KeyPadResources._8; break;
                    case 11: buttonNumPad.BackgroundImage = KeyPadResources._9; break;
                    case 12: buttonNumPad.BackgroundImage = KeyPadResources.dot; break;
                    case 13: buttonNumPad.BackgroundImage = KeyPadResources._0; break;
                    case 14: buttonNumPad.BackgroundImage = KeyPadResources.ok; break;
                }

                switch (i)
                {
                    case 4:
                        buttonNumPad.Name = RefButton.Name + "Cancel";
                        break;
                    case 8:
                        buttonNumPad.Name = RefButton.Name + "BackSpace";
                        break;
                    case 12:
                        buttonNumPad.Name = RefButton.Name + "Dot";
                        buttonNumPad.Text = decimalStr;
                        break;
                    case 13:
                        buttonNumPad.Name = RefButton.Name + "0";
                        buttonNumPad.Width = buttonNumPad.Size.Width * 2 - 1;
                        break;
                    case 14:
                        buttonNumPad.Width = buttonNumPad.Size.Width * 2;
                        buttonNumPad.Name = RefButton.Name + "OK";
                        buttonNumPad.Location = new System.Drawing.Point(buttonNumPad.Location.X + RefButton.Width - 1, buttonNumPad.Location.Y);
                        OKButton = buttonNumPad;
                        break;
                    default:
                        string name = "";
                        if (i < 4)
                            name = i.ToString();
                        else if (i < 8)
                            name = (i - 1).ToString();
                        else if (i < 12)
                            name = (i - 2).ToString();
                        buttonNumPad.Name = RefButton.Name + name;
                        break;
                }
                buttonNumPad.Click += new EventHandler(buttonNumPad_Click);
                buttonNumPad.MouseDown += buttonNumPad_MouseDown;
                buttonNumPad.MouseUp += buttonNumPad_MouseUp;
                panelNumPad.Controls.Add(buttonNumPad);
            }

            NewEntry = true;
            OKButton.TabIndex = 0;
        }

        void buttonNumPad_MouseUp(object sender, MouseEventArgs e)
        {
            Button buttonNumPad = (Button)sender;
            String Action = buttonNumPad.Name.Substring(RefButton.Name.Length);
            switch (Action)
            {
                case "1": buttonNumPad.BackgroundImage = KeyPadResources._1; break;
                case "2": buttonNumPad.BackgroundImage = KeyPadResources._2; break;
                case "3": buttonNumPad.BackgroundImage = KeyPadResources._3; break;
                case "Cancel": buttonNumPad.BackgroundImage = KeyPadResources.clear; break;
                case "4": buttonNumPad.BackgroundImage = KeyPadResources._4; break;
                case "5": buttonNumPad.BackgroundImage = KeyPadResources._5; break;
                case "6": buttonNumPad.BackgroundImage = KeyPadResources._6; break;
                case "BackSpace": buttonNumPad.BackgroundImage = KeyPadResources.back; break;
                case "7": buttonNumPad.BackgroundImage = KeyPadResources._7; break;
                case "8": buttonNumPad.BackgroundImage = KeyPadResources._8; break;
                case "9": buttonNumPad.BackgroundImage = KeyPadResources._9; break;
                case "Dot": buttonNumPad.BackgroundImage = KeyPadResources.dot; break;
                case "0": buttonNumPad.BackgroundImage = KeyPadResources._0; break;
                case "OK": buttonNumPad.BackgroundImage = KeyPadResources.ok; break;
            }
        }

        void buttonNumPad_MouseDown(object sender, MouseEventArgs e)
        {
            Button buttonNumPad = (Button)sender;
            String Action = buttonNumPad.Name.Substring(RefButton.Name.Length);
            switch (Action)
            {
                case "1": buttonNumPad.BackgroundImage = KeyPadResources._1_pressed; break;
                case "2": buttonNumPad.BackgroundImage = KeyPadResources._2_pressed; break;
                case "3": buttonNumPad.BackgroundImage = KeyPadResources._3_pressed; break;
                case "Cancel": buttonNumPad.BackgroundImage = KeyPadResources.clear_pressed; break;
                case "4": buttonNumPad.BackgroundImage = KeyPadResources._4_pressed; break;
                case "5": buttonNumPad.BackgroundImage = KeyPadResources._5_pressed; break;
                case "6": buttonNumPad.BackgroundImage = KeyPadResources._6_pressed; break;
                case "BackSpace": buttonNumPad.BackgroundImage = KeyPadResources.back_pressed; break;
                case "7": buttonNumPad.BackgroundImage = KeyPadResources._7_pressed; break;
                case "8": buttonNumPad.BackgroundImage = KeyPadResources._8_pressed; break;
                case "9": buttonNumPad.BackgroundImage = KeyPadResources._9_pressed; break;
                case "Dot": buttonNumPad.BackgroundImage = KeyPadResources.dot_pressed; break;
                case "0": buttonNumPad.BackgroundImage = KeyPadResources._0_pressed; break;
                case "OK": buttonNumPad.BackgroundImage = KeyPadResources.ok_pressed; break;
            }
        }

        void buttonNumPad_Click(object sender, EventArgs e)
        {
            Button buttonNumPad = (Button)sender;
            String Action = buttonNumPad.Name.Substring(RefButton.Name.Length);
            handleaction(Action);
            OKButton.Focus();

            if (keyAction != null)
            {
                try
                {
                    ReturnNumber = Math.Round(Convert.ToDouble(textBoxNumPadDisplay.Text), RoundingPrecision + 2, MidpointRounding.AwayFromZero);
                }
                catch { }
                keyAction.Invoke();
            }
        }

        public void handleaction(string Action)
        {
            bool OKPressed = false;

            switch (Action)
            {
                case "Cancel": NewEntry = true; break;
                case "BackSpace":
                    if (!NewEntry)
                    {
                        textBoxNumPadDisplay.Text = textBoxNumPadDisplay.Text.Substring(0, textBoxNumPadDisplay.Text.Length - 1);
                        if (textBoxNumPadDisplay.Text == "")
                            NewEntry = true;
                    }
                    break;
                case "Dot":
                    if (NewEntry)
                    {
                        textBoxNumPadDisplay.Text = "";
                        NewEntry = false;
                    }
                    if (!textBoxNumPadDisplay.Text.Contains(decimalStr)) textBoxNumPadDisplay.AppendText(decimalStr); break;
                case "OK":
                    if (textBoxNumPadDisplay.Text == decimalStr)
                        ReturnNumber = 0;
                    else
                        try
                        {
                            ReturnNumber = Math.Round(Convert.ToDouble(textBoxNumPadDisplay.Text), RoundingPrecision + 2, MidpointRounding.AwayFromZero);
                        }
                        catch { }
                    textBoxNumPadDisplay.Text = string.Format("{0:" + AMOUNT_FORMAT + "}", ReturnNumber);
                    NewEntry = true;
                    OKPressed = true;
                    receiveAction.Invoke();
                    break;
                default:
                    if (NewEntry)
                    {
                        textBoxNumPadDisplay.Text = "";
                    }
                    textBoxNumPadDisplay.AppendText(Action);
                    NewEntry = false;
                    break;
            }
            if (OKPressed)
                OKPressed = false;
            else if (NewEntry)
                textBoxNumPadDisplay.Text = 0.ToString(AMOUNT_FORMAT);
        }

        public void GetKey(Char Key)
        {
            string Action;
            switch ((Keys)Key)
            {
                case Keys.Escape: Action = "Cancel"; break;
                case Keys.Enter: Action = "OK"; break;
                case Keys.Back: Action = "BackSpace"; break;
                default:
                    if (Key == decimalChar)
                    {
                        Action = "Dot";
                    }
                    else if (Key >= '0' && Key <= '9')
                    {
                        Action = Key.ToString();
                    }
                    else
                    {
                        Action = "XX";
                    }
                    break;
            }
            if (Action != "XX")
                handleaction(Action);
            OKButton.Focus();
        }
    }
}

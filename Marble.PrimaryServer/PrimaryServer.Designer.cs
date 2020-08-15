namespace Marble.PrimaryServer
{
    partial class PrimaryServer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_minimize = new System.Windows.Forms.Button();
            this.btn_shutDownExit = new System.Windows.Forms.Button();
            this.btn_ShoutDown = new System.Windows.Forms.Button();
            this.btn_restart = new System.Windows.Forms.Button();
            this.btn_hideServer = new System.Windows.Forms.Button();
            this.richText_primaryServer = new System.Windows.Forms.RichTextBox();
            this.lab_PrimaryServer = new System.Windows.Forms.Label();
            this.serverLayout = new System.Windows.Forms.TableLayoutPanel();
            this.panel1.SuspendLayout();
            this.serverLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_minimize);
            this.panel1.Controls.Add(this.btn_shutDownExit);
            this.panel1.Controls.Add(this.btn_ShoutDown);
            this.panel1.Controls.Add(this.btn_restart);
            this.panel1.Controls.Add(this.btn_hideServer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 425);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(767, 42);
            this.panel1.TabIndex = 2;
            // 
            // btn_minimize
            // 
            this.btn_minimize.BackColor = System.Drawing.Color.White;
            this.btn_minimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_minimize.Location = new System.Drawing.Point(153, 3);
            this.btn_minimize.Name = "btn_minimize";
            this.btn_minimize.Size = new System.Drawing.Size(123, 32);
            this.btn_minimize.TabIndex = 4;
            this.btn_minimize.Text = "Minimize to Tray";
            this.btn_minimize.UseVisualStyleBackColor = false;
            this.btn_minimize.Click += new System.EventHandler(this.btn_minimize_Click);
            // 
            // btn_shutDownExit
            // 
            this.btn_shutDownExit.BackColor = System.Drawing.Color.White;
            this.btn_shutDownExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_shutDownExit.Location = new System.Drawing.Point(601, 2);
            this.btn_shutDownExit.Name = "btn_shutDownExit";
            this.btn_shutDownExit.Size = new System.Drawing.Size(123, 32);
            this.btn_shutDownExit.TabIndex = 3;
            this.btn_shutDownExit.Text = "ShutDown, Exit";
            this.btn_shutDownExit.UseVisualStyleBackColor = false;
            this.btn_shutDownExit.Click += new System.EventHandler(this.btn_shutDownExit_Click);
            // 
            // btn_ShoutDown
            // 
            this.btn_ShoutDown.BackColor = System.Drawing.Color.White;
            this.btn_ShoutDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ShoutDown.Location = new System.Drawing.Point(442, 3);
            this.btn_ShoutDown.Name = "btn_ShoutDown";
            this.btn_ShoutDown.Size = new System.Drawing.Size(139, 30);
            this.btn_ShoutDown.TabIndex = 2;
            this.btn_ShoutDown.Text = "ShutDown Servers";
            this.btn_ShoutDown.UseVisualStyleBackColor = false;
            this.btn_ShoutDown.Click += new System.EventHandler(this.btn_ShoutDown_Click);
            // 
            // btn_restart
            // 
            this.btn_restart.BackColor = System.Drawing.Color.White;
            this.btn_restart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_restart.Location = new System.Drawing.Point(302, 2);
            this.btn_restart.Name = "btn_restart";
            this.btn_restart.Size = new System.Drawing.Size(123, 32);
            this.btn_restart.TabIndex = 1;
            this.btn_restart.Text = "Restart Servers";
            this.btn_restart.UseVisualStyleBackColor = false;
            this.btn_restart.Click += new System.EventHandler(this.btn_restart_Click);
            // 
            // btn_hideServer
            // 
            this.btn_hideServer.BackColor = System.Drawing.Color.White;
            this.btn_hideServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_hideServer.Location = new System.Drawing.Point(9, 3);
            this.btn_hideServer.Name = "btn_hideServer";
            this.btn_hideServer.Size = new System.Drawing.Size(123, 32);
            this.btn_hideServer.TabIndex = 0;
            this.btn_hideServer.Text = "Hide Servers";
            this.btn_hideServer.UseVisualStyleBackColor = false;
            // 
            // richText_primaryServer
            // 
            this.richText_primaryServer.Location = new System.Drawing.Point(3, 73);
            this.richText_primaryServer.Name = "richText_primaryServer";
            this.richText_primaryServer.Size = new System.Drawing.Size(767, 346);
            this.richText_primaryServer.TabIndex = 1;
            this.richText_primaryServer.Text = "";
            // 
            // lab_PrimaryServer
            // 
            this.lab_PrimaryServer.AutoSize = true;
            this.lab_PrimaryServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_PrimaryServer.Location = new System.Drawing.Point(3, 0);
            this.lab_PrimaryServer.Name = "lab_PrimaryServer";
            this.lab_PrimaryServer.Size = new System.Drawing.Size(276, 31);
            this.lab_PrimaryServer.TabIndex = 0;
            this.lab_PrimaryServer.Text = "Marble PrimaryServer";
            // 
            // serverLayout
            // 
            this.serverLayout.ColumnCount = 1;
            this.serverLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.serverLayout.Controls.Add(this.lab_PrimaryServer, 0, 0);
            this.serverLayout.Controls.Add(this.richText_primaryServer, 0, 1);
            this.serverLayout.Controls.Add(this.panel1, 0, 2);
            this.serverLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serverLayout.Location = new System.Drawing.Point(0, 0);
            this.serverLayout.Name = "serverLayout";
            this.serverLayout.RowCount = 3;
            this.serverLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.serverLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.serverLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.serverLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.serverLayout.Size = new System.Drawing.Size(773, 470);
            this.serverLayout.TabIndex = 0;
            // 
            // PrimaryServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 470);
            this.Controls.Add(this.serverLayout);
            this.Name = "PrimaryServer";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.serverLayout.ResumeLayout(false);
            this.serverLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_shutDownExit;
        private System.Windows.Forms.Button btn_ShoutDown;
        private System.Windows.Forms.Button btn_restart;
        private System.Windows.Forms.Button btn_hideServer;
        private System.Windows.Forms.RichTextBox richText_primaryServer;
        private System.Windows.Forms.Label lab_PrimaryServer;
        private System.Windows.Forms.TableLayoutPanel serverLayout;
        private System.Windows.Forms.Button btn_minimize;

    }
}


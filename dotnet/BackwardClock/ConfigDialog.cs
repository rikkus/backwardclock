using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace BackwardClock
{
	/// <summary>
	/// Summary description for ConfigDialog.
	/// </summary>
	public class ConfigDialog : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage colourPage;
		private System.Windows.Forms.TabPage sizePage;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ConfigDialog()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.colourPage = new System.Windows.Forms.TabPage();
			this.sizePage = new System.Windows.Forms.TabPage();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.tabControl1.SuspendLayout();
			this.colourPage.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.AddRange(new System.Windows.Forms.Control[] {
																																							this.colourPage,
																																							this.sizePage});
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(6, 6);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(372, 314);
			this.tabControl1.TabIndex = 0;
			this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
			// 
			// colourPage
			// 
			this.colourPage.Controls.AddRange(new System.Windows.Forms.Control[] {
																																						 this.label6,
																																						 this.label5,
																																						 this.label4,
																																						 this.label3,
																																						 this.label2,
																																						 this.label1});
			this.colourPage.Location = new System.Drawing.Point(4, 22);
			this.colourPage.Name = "colourPage";
			this.colourPage.Size = new System.Drawing.Size(364, 288);
			this.colourPage.TabIndex = 0;
			this.colourPage.Text = "Colours";
			this.colourPage.Click += new System.EventHandler(this.colourPage_Click);
			// 
			// sizePage
			// 
			this.sizePage.Location = new System.Drawing.Point(4, 22);
			this.sizePage.Name = "sizePage";
			this.sizePage.Size = new System.Drawing.Size(364, 288);
			this.sizePage.TabIndex = 1;
			this.sizePage.Text = "Sizes";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.TabIndex = 0;
			this.label1.Text = "Minute hand:";
			// 
			// button1
			// 
			this.button1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.button1.Location = new System.Drawing.Point(116, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(80, 24);
			this.button1.TabIndex = 1;
			this.button1.Text = "OK";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.button2.Location = new System.Drawing.Point(204, 8);
			this.button2.Name = "button2";
			this.button2.TabIndex = 2;
			this.button2.Text = "Cancel";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.button3.Location = new System.Drawing.Point(284, 8);
			this.button3.Name = "button3";
			this.button3.TabIndex = 3;
			this.button3.Text = "Apply";
			// 
			// panel1
			// 
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																																				 this.button1,
																																				 this.button2,
																																				 this.button3});
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(6, 320);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(372, 40);
			this.panel1.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 56);
			this.label2.Name = "label2";
			this.label2.TabIndex = 1;
			this.label2.Text = "Hour hand:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 96);
			this.label3.Name = "label3";
			this.label3.TabIndex = 2;
			this.label3.Text = "Markers:";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 176);
			this.label4.Name = "label4";
			this.label4.TabIndex = 3;
			this.label4.Text = "Face:";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 136);
			this.label5.Name = "label5";
			this.label5.TabIndex = 4;
			this.label5.Text = "Edge:";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(16, 216);
			this.label6.Name = "label6";
			this.label6.TabIndex = 5;
			this.label6.Text = "Background:";
			// 
			// ConfigDialog
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(384, 366);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																																	this.tabControl1,
																																	this.panel1});
			this.DockPadding.All = 6;
			this.Name = "ConfigDialog";
			this.Text = "Configure BackwardClock";
			this.tabControl1.ResumeLayout(false);
			this.colourPage.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
		
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
		
		}

		private void colourPage_Click(object sender, System.EventArgs e)
		{
		
		}
	}
}

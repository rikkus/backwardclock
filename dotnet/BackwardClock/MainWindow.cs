using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace BackwardClock
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class MainWindow : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem configureMenuItem;
		private System.Windows.Forms.MenuItem exitMenuItem;
		private System.ComponentModel.IContainer components;

		private int LastMinute = 0;

		public MainWindow()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
	
			base.ResizeRedraw = true;

			SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
			SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			SetStyle(ControlStyles.Selectable, true);
			
			timer1.Interval = 1000;
			timer1.Start();

			Invalidate();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
			this.components = new System.ComponentModel.Container();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.configureMenuItem = new System.Windows.Forms.MenuItem();
			this.exitMenuItem = new System.Windows.Forms.MenuItem();
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																								 this.configureMenuItem,
																																								 this.exitMenuItem});
			// 
			// configureMenuItem
			// 
			this.configureMenuItem.Index = 0;
			this.configureMenuItem.Text = "&Configure...";
			this.configureMenuItem.Visible = false;
			// 
			// exitMenuItem
			// 
			this.exitMenuItem.Index = 1;
			this.exitMenuItem.Text = "E&xit";
			this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
			// 
			// MainWindow
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(160, 142);
			this.ContextMenu = this.contextMenu1;
			this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "MainWindow";
			this.TopMost = true;

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainWindow());
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			if (DateTime.Now.Minute > LastMinute)
				Repaint();

			LastMinute = DateTime.Now.Minute;
		}

		private void Repaint()
		{
			DateTime now = DateTime.Now;
			Text =
				now.DayOfWeek.ToString() + " " +
				DateTime.Now.Date.ToShortDateString();

			Invalidate();
		}

		private int Smaller(int x, int y)
		{
			return x < y ? x : y;
		}

		private int Larger(int x, int y)
		{
			return x > y ? x : y;
		}

		protected override void OnPaint ( System.Windows.Forms.PaintEventArgs e )
		{
			DateTime now = DateTime.Now;

			int second  = now.Second;
			int minute  = now.Minute;
			int hour		= now.Hour;

			Pen secondPen = new Pen(Brushes.DarkMagenta, 2);
			Pen minutePen = new Pen(Brushes.DarkRed, 2);
			Pen hourPen		= new Pen(Brushes.DarkBlue, 2);

			Graphics g = e.Graphics;
			g.SmoothingMode = SmoothingMode.AntiAlias;

			Point centre = new Point(ClientSize.Width / 2, ClientSize.Height / 2);

			double TWOPI = Math.PI * 2;

			int faceSize =
				(int)((Smaller(ClientSize.Width, ClientSize.Height)) * 0.9);

			g.DrawEllipse
				(
					new Pen(Brushes.DarkBlue, 2),
					centre.X - faceSize / 2,
					centre.Y - faceSize / 2,
					faceSize,
					faceSize
				);

			int tickOuterRadius =
				(int)((Smaller(ClientSize.Width, ClientSize.Height) / 2) * 0.8);

			int tickInnerRadius =
				(int)((Smaller(ClientSize.Width, ClientSize.Height) / 2) * 0.65);

			for (int i = 0; i < 360; i += 30)
			{
				double angle = (i / 360.0) * TWOPI - Math.PI / 2;

				g.DrawLine
					(
						new Pen(Brushes.Purple, 2),
						new Point
						(
							centre.X + (int)(tickInnerRadius * Math.Cos(angle)),
							centre.Y + (int)(tickInnerRadius * Math.Sin(angle))
						),
						new Point
						(
							centre.X + (int)(tickOuterRadius * Math.Cos(angle)),
							centre.Y + (int)(tickOuterRadius * Math.Sin(angle))
						)
					);
			}

			int maxHandLength = Smaller(ClientSize.Width, ClientSize.Height) / 2;

			int secondHandLength	= (int)(maxHandLength * 0.8);
			int minuteHandLength	= (int)(maxHandLength * 0.8);
			int hourHandLength		= (int)(maxHandLength * 0.6);

			double secondHandDegrees	= second  / 60.0;
			double minuteHandDegrees	= minute  / 60.0;
			double hourHandDegrees		= (hour + minute / 60.0) / 12.0;
			
			double secondHandRadians  = secondHandDegrees * TWOPI + Math.PI /2;
			double minuteHandRadians	= minuteHandDegrees * TWOPI + Math.PI /2;
			double hourHandRadians		= hourHandDegrees		* TWOPI + Math.PI /2;

			secondHandRadians = -secondHandRadians;
			minuteHandRadians	= -minuteHandRadians;
			hourHandRadians		= -hourHandRadians;

			//       /|
			//      / |
			//   H /  |
			//    /   | O
			//   /    |
			//  /a____|
			//     A

			// We know the hypotenuse.
			// We need to know the opposite and adjacent.
			// We know the angle.

			// S = O / H
			// O = HS
			// O = handLength * sine(HandRadians)

			// C = A / H
			// A = HC
			// A = handLength * cos(HandRadians)
			
			Point secondHandEnd		=
				new Point
				(
					centre.X + (int)(secondHandLength * Math.Cos(secondHandRadians)),
					centre.Y + (int)(secondHandLength * Math.Sin(secondHandRadians))
				);

			Point minuteHandEnd		=
				new Point
				(
					centre.X + (int)(minuteHandLength * Math.Cos(minuteHandRadians)),
					centre.Y + (int)(minuteHandLength * Math.Sin(minuteHandRadians))
				);

			Point hourHandEnd		=
				new Point
				(
					centre.X + (int)(hourHandLength * Math.Cos(hourHandRadians)),
					centre.Y + (int)(hourHandLength * Math.Sin(hourHandRadians))
				);

			g.DrawLine(hourPen,		centre,	hourHandEnd);
			g.DrawLine(minutePen,	centre,	minuteHandEnd);		
//			g.DrawLine(secondPen,	centre,	secondHandEnd);
		}

		private void exitMenuItem_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}



	}
}

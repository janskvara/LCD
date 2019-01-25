using Microsoft.Win32;
using S7.Net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace LCD
{
    public partial class Vescon : Form
    {
        
        //private void RB1_ERROR_Paint(object sender, PaintEventArgs e)
        //{
        //    Pen Pen = new Pen(Brushes.Red);
        //    Pen.Width = 10.0F;
        //    Pen.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel;
        //    e.Graphics.DrawRectangle(Pen,
        //        new Rectangle(0, 0, RB1_ERROR.Width, RB1_ERROR.Height));
        //    Pen.Dispose();
        //}

        
        //private void RB1_WARNING_Paint(object sender, PaintEventArgs e)
        //{
        //    Pen Pen = new Pen(Brushes.Yellow);
        //    Pen.Width = 10.0F;
        //    Pen.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel;
        //    e.Graphics.DrawRectangle(Pen,
        //        new Rectangle(0, 0, RB1_ERROR.Width, RB1_ERROR.Height));
        //    Pen.Dispose();
        //}


        private ushort OK_L, NOK_L, OK_P, NOK_P, plan_L, plan_P;

        private bool chyba_1RB1,chyba_2KT,chyba_3RP1,chyba_3LD1,chyba_4RB2,chyba_5RP24,
                       chyba_5RP23, chyba_5RP22, chyba_5RP21, chyba_5LD2,chyba_6VK;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Vescon_Load(object sender, EventArgs e)
        {

        }

        private bool  upozornenie_1RB1, upozornenie_2KT, upozornenie_3RP1, upozornenie_3LD1, upozornenie_4RB2, upozornenie_5RP24,
                       upozornenie_5RP23, upozornenie_5RP22, upozornenie_5RP21, upozornenie_5LD2, upozornenie_6VK;

        public Vescon()
        {
            InitializeComponent();

            Timer Timer1 = new Timer();
            Timer Timer2 = new Timer();
            Timer Timer3 = new Timer();
            Timer2.Interval = 10000;
            Timer1.Interval = 1000;
            Timer3.Interval = 500;
            //Timer2.Tick += new EventHandler(Timer2_Tick);
            Timer2.Enabled = true;
            Timer1.Tick += new EventHandler(Timer1_Tick);
            Timer1.Enabled = true;
            //Timer3.Tick += new EventHandler(Timer3_Tick);
            Timer3.Enabled = true;



        }

        
        private void Timer1_Tick(object Sender, EventArgs e)
        {

            //Plc plc = new Plc(CpuType.S7300, "192.168.0.10", 0, 2);
            //plc.Open();
            //    OK_L = (ushort)plc.Read("DB616.DBX0.0");
            //    NOK_L = (ushort)plc.Read("DB616.DBX2.0");
            //    OK_P = (ushort)plc.Read("DB616.DBX4.0");
            //    NOK_P= (ushort)plc.Read("DB616.DBX6.0");
            //    plan_L = (ushort)plc.Read("DB616.DBX8.0");
            //    plan_P= (ushort)plc.Read("DB616.DBX10.0");

            //    chyba_1RB1 = (bool)plc.Read("DB616.DBX28.0");
            //    chyba_2KT = (bool)plc.Read("DB616.DBX28.1");
            //    chyba_3RP1 = (bool)plc.Read("DB616.DBX28.2");
            //    chyba_3LD1 = (bool)plc.Read("DB616.DBX28.3");
            //    chyba_4RB2 = (bool)plc.Read("DB616.DBX28.4");
            //    chyba_5RP24 = (bool)plc.Read("DB616.DBX28.5");
            //    chyba_5RP23 = (bool)plc.Read("DB616.DBX28.6");
            //    chyba_5RP22 = (bool)plc.Read("DB616.DBX28.7");
            //    chyba_5RP21 = (bool)plc.Read("DB616.DBX29.0");
            //    chyba_5LD2 = (bool)plc.Read("DB616.DBX29.1");
            //    chyba_6VK = (bool)plc.Read("DB616.DBX29.2");

            //    upozornenie_1RB1 = (bool)plc.Read("DB616.DBX29.3");
            //    upozornenie_2KT = (bool)plc.Read("DB616.DBX29.4");
            //    upozornenie_3RP1 = (bool)plc.Read("DB616.DBX29.5");
            //    upozornenie_3LD1 = (bool)plc.Read("DB616.DBX29.6");
            //    upozornenie_4RB2 = (bool)plc.Read("DB616.DBX29.7");
            //    upozornenie_5RP24 = (bool)plc.Read("DB616.DBX30.0");
            //    upozornenie_5RP23 = (bool)plc.Read("DB616.DBX30.1");
            //    upozornenie_5RP22 = (bool)plc.Read("DB616.DBX30.2");
            //    upozornenie_5RP21 = (bool)plc.Read("DB616.DBX30.3");
            //    upozornenie_5LD2 = (bool)plc.Read("DB616.DBX30.4");
            //    upozornenie_6VK = (bool)plc.Read("DB616.DBX30.5");
            //plc.Close();

            time.Text = DateTime.Now.ToString("HH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            date.Text = DateTime.Now.ToShortDateString();
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\VesconSettings");
            String display = key.GetValue("DISPLAY").ToString();
            showOnScreen(display, true);

           
        }
        //private void Timer2_Tick(object Sender, EventArgs e)
        //{
        //    if(panel1.Visible == false)
        //    {
        //        panel1.Visible = true; 
        //    }
        //    else
        //    {
        //        panel1.Visible = false;
        //    }
           

        //}

        //private void Timer3_Tick(object Sender, EventArgs e)
        //{
        //    if (panel1.Visible == true)
        //    {
        //        blikanie(RB1_ERROR,RB1_WARNING, false, false);
        //    }

        //}




        void showOnScreen(string screenName, bool maximised = false)
        {
            try
            {
                Screen res = Screen.AllScreens.FirstOrDefault(s => s.DeviceName == screenName);
                Location = res.WorkingArea.Location;
                if (maximised)
                {
                    FormBorderStyle = FormBorderStyle.None;
                    WindowState = FormWindowState.Maximized;
                    TopMost = true;
                }
                else
                {
                    FormBorderStyle = FormBorderStyle.FixedSingle;
                    WindowState = FormWindowState.Normal;
                    TopMost = false;
                }
            }
            catch
            {
                FormBorderStyle = FormBorderStyle.FixedSingle;
                WindowState = FormWindowState.Normal;
                TopMost = false;
                MessageBox.Show("DISPLAY NIE JE PRIPOJENY");
            }
               
            
        }



        void blikanie( Label blikanie_error,Label blikanie_warning , bool error ,bool warning )
        {
            if ( (blikanie_error.Visible == false) && (blikanie_warning.Visible == false))
            {
                if (error)
                {
                    
                    
                    blikanie_error.Visible = true;
                }
                else if (warning)
                {
                    
                    
                    blikanie_warning .Visible = true;
                }
                else
                {

                }
               
            }
            else
            {
                blikanie_error.Visible = false;
                blikanie_warning.Visible = false; 
            }

        }


    }
}

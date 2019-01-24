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
        
        private void RB1_ERROR_Paint(object sender, PaintEventArgs e)
        {
            Pen skyBluePen = new Pen(Brushes.Red);

            // Set the pen's width.
            skyBluePen.Width = 10.0F;

            // Set the LineJoin property.
            skyBluePen.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel;

            // Draw a rectangle.
            e.Graphics.DrawRectangle(skyBluePen,
                new Rectangle(0, 0, RB1_ERROR.Width, RB1_ERROR.Height));

            //Dispose of the pen.
            skyBluePen.Dispose();
        }

        private bool OK_L,NOK_L,OK_P, NOK_P ,plan_L,plan_P,chyba_1RB1,chyba_2KT,chyba_3RP1,chyba_3LD1,chyba_4RB2,chyba_5RP24,
                       chyba_5RP23, chyba_5RP22, chyba_5RP21, chyba_5LD2,chyba_6VK;


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
            Timer2.Tick += new EventHandler(Timer2_Tick);
            Timer2.Enabled = true;
            Timer1.Tick += new EventHandler(Timer1_Tick);
            Timer1.Enabled = true;
            Timer3.Tick += new EventHandler(Timer3_Tick);
            Timer3.Enabled = true;



        }

        
        private void Timer1_Tick(object Sender, EventArgs e)
        {

            //Plc plc = new Plc(CpuType.S7300, "192.168.0.10", 0, 2);
            //plc.Open();
            //    OK_L = (bool)plc.Read("DB616.DBX0.0");
            //    NOK_L = (bool)plc.Read("DB616.DBX0.1");
            //    OK_P = (bool)plc.Read("DB616.DBX0.2");
            //    NOK_P= (bool)plc.Read("DB616.DBX0.3");
            //    plan_L = (bool)plc.Read("DB616.DBX0.4");
            //    plan_P= (bool)plc.Read("DB616.DBX0.5");

            //    chyba_1RB1 = (bool)plc.Read("DB616.DBX18.0");
            //    chyba_2KT = (bool)plc.Read("DB616.DBX18.1");
            //    chyba_3RP1 = (bool)plc.Read("DB616.DBX18.2");
            //    chyba_3LD1 = (bool)plc.Read("DB616.DBX18.3");
            //    chyba_4RB2 = (bool)plc.Read("DB616.DBX18.4");
            //    chyba_5RP24 = (bool)plc.Read("DB616.DBX18.5");
            //    chyba_5RP23 = (bool)plc.Read("DB616.DBX18.6");
            //    chyba_5RP22 = (bool)plc.Read("DB616.DBX18.7");
            //    chyba_5RP21 = (bool)plc.Read("DB616.DBX19.0");
            //    chyba_5LD2 = (bool)plc.Read("DB616.DBX19.1");
            //    chyba_6VK = (bool)plc.Read("DB616.DBX19.2");

            //    upozornenie_1RB1 = (bool)plc.Read("DB616.DBX19.3");
            //    upozornenie_2KT = (bool)plc.Read("DB616.DBX19.4");
            //    upozornenie_3RP1 = (bool)plc.Read("DB616.DBX19.5");
            //    upozornenie_3LD1 = (bool)plc.Read("DB616.DBX19.6");
            //    upozornenie_4RB2 = (bool)plc.Read("DB616.DBX19.7");
            //    upozornenie_5RP24 = (bool)plc.Read("DB616.DBX20.0");
            //    upozornenie_5RP23 = (bool)plc.Read("DB616.DBX20.1");
            //    upozornenie_5RP22 = (bool)plc.Read("DB616.DBX20.2");
            //    upozornenie_5RP21 = (bool)plc.Read("DB616.DBX20.3");
            //    upozornenie_5LD2 = (bool)plc.Read("DB616.DBX20.4");
            //    upozornenie_6VK = (bool)plc.Read("DB616.DBX20.5");

                //ushort pomocna_int = (ushort)PLC.Read(okna[i]);
                //ushort pomocna_int = (ushort)PLC.Read(okna[i]);
                //ushort pomocna_int = (ushort)PLC.Read(okna[i]);
                //ushort pomocna_int = (ushort)PLC.Read(okna[i]);
                //ushort pomocna_int = (ushort)PLC.Read(okna[i]);
            //plc.Close();

            time.Text = DateTime.Now.ToString("HH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            date.Text = DateTime.Now.ToShortDateString();
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\VesconSettings");
            String display = key.GetValue("DISPLAY").ToString();
            showOnScreen(display, true);

           
        }
        private void Timer2_Tick(object Sender, EventArgs e)
        {
            if(panel1.Visible == false)
            {
                panel1.Visible = true; 
            }
            else
            {
                panel1.Visible = false;
            }
           

        }

        private void Timer3_Tick(object Sender, EventArgs e)
        {
            
           
            if (panel1.Visible == true)
            {
                blikanie(RB1_ERROR, false, true);
            }

        }




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

        void blikanie( Label blikanie , bool error ,bool warning )
        {
            if (blikanie.Visible == false)
            {
                if (error)
                {
                    
                    //blikanie.BackColor = Color.Red;
                    blikanie.Visible = true;
                }
                else if (warning)
                {
                    
                    //blikanie.BackColor = Color.Yellow;
                    blikanie.Visible = true;
                }
                else
                {

                }
               
            }
            else
            {
                blikanie.Visible = false;
            }

        }


    }
}

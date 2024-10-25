using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//===========================
using System.Collections;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Btn_Spot_Click_1(object sender, EventArgs e)
        {
            Button Bu = (Button)sender;
            if (Proc || Txt_ShowResult.Text=="0")
                Txt_ShowResult.Text = string.Empty;
            Txt_ShowResult.Text += Bu.Text;
            Proc = false;
            Btn_Result.Focus();
        }
        
        public static void Calc(ref double ResultNum,ref List<string> Cal)
        {
            if (Result)
            {
                string[] par = Cal.ToArray();
                Mod(ref par);
                Mul(ref par);
                Div(ref par);
                Sum(ref par);
              //  Min(ref par);
                ResultNum= double.Parse(par[0]);
                 
            }
            Result = false;
            
        }
        public static void Mod(ref string[] par)
        {
            int Count;
            while (true)
            {
                if ((Count = Array.LastIndexOf(par, "Mod")) > 0)
                {
                    par[Count - 1] = (double.Parse(par[Count - 1]) % double.Parse(par[Count + 1])).ToString();
                    var Remove = new List<string>(par);
                    Remove.RemoveAt(Count);
                    Remove.RemoveAt(Count);
                    Count = -1;
                    par = Remove.ToArray();
                }
                else
                {
                    return;
                }

            }
        }
        //=========================================
        public static void Mul(ref string[] par)
        {
            int Count;
            while (true)
            {
                if ((Count = Array.LastIndexOf(par, "×")) > 0)
                {
                    par[Count - 1] = (double.Parse(par[Count - 1]) * double.Parse(par[Count + 1])).ToString();
                    var Remove = new List<string>(par);
                    Remove.RemoveAt(Count);
                    Remove.RemoveAt(Count);
                    Count = -1;
                    par = Remove.ToArray();
                }
                else
                {
                    return;
                }

            }
        }
        //==================================================
        public static void Div(ref string[] par)
        {
            int Count;
            while (true)
            {
                if ((Count = Array.LastIndexOf(par, "÷")) > 0)
                {
                    par[Count - 1] = (double.Parse(par[Count - 1]) / double.Parse(par[Count + 1])).ToString();
                    var Remove = new List<string>(par);
                    Remove.RemoveAt(Count);
                    Remove.RemoveAt(Count );
                    Count = -1;
                    par = Remove.ToArray();
                }
                else
                {
                    return;
                }

            }
        }
        //=====================================================
        public static void Sum(ref string[] par)
        {
            int Count;
            while (true)
            {
                if ((Count = Array.LastIndexOf(par, "+")) > 0)
                {
                    par[Count - 1] = (double.Parse(par[Count - 1]) + double.Parse(par[Count + 1])).ToString();
                    var Remove = new List<string>(par);
                    Remove.RemoveAt(Count);
                    Remove.RemoveAt(Count );
                    Count = -1;
                    par = Remove.ToArray();
                }
                else
                {
                    return;
                }

            }
        }
        //=======================================================
        public static void Min(ref string[] par)
        {
            int Count;
            while (true)
            {
                if ((Count = Array.LastIndexOf(par, "-")) > 0)
                {
                    par[Count - 1] = (double.Parse(par[Count - 1]) / double.Parse(par[Count + 1])).ToString();
                    var Remove = new List<string>(par);
                    Remove.RemoveAt(Count);
                    Remove.RemoveAt(Count );
                    Count = -1;
                    par = Remove.ToArray();
                }
                else
                {
                    return;
                }

            }
        }
        private void button4_Click(object sender, EventArgs e)
        {

        }
        double Jav;
        private void Btn_Result_Click(object sender, EventArgs e)
        {
            Result = true;
            if (NowSign == "-")
                GetNumber.Add("-" + Txt_ShowResult.Text);
            else
                GetNumber.Add(Txt_ShowResult.Text);
            Calc(ref Jav,ref GetNumber);
            Txt_ShowResult.Text = Jav.ToString();
            Proc = true;
            GetNumber = new List<string>();
            Txt_Show.Text = string.Empty;
            Btn_Result.Focus();
            NowSign = string.Empty;

        }

        public static bool Result = false;
        private void Btn_Sum_Click(object sender, EventArgs e)
        {
            
        }

        private void Btn_Zarb_Click(object sender, EventArgs e)
        {

        }
        public static string[] Collection;
        public static void CollecrionForCalc(string[] Pricess)
        {

        }
        private void Btn_Taghsim_Click(object sender, EventArgs e)
        {

        }

        private void Txt_ShowResult_TextChanged(object sender, EventArgs e)
        {
            //برای زیبایی
            //if (Txt_ShowResult.Text==string.Empty)
            
            //    Txt_ShowResult.Text = "0";
            
        }
        bool Proc = false;
        private void Btn_Menha_Click(object sender, EventArgs e)
        {
            Proc = true;

        }
        public static List<string> GetNumber;
        private void Form1_Load(object sender, EventArgs e)
        {
            GetNumber = new List<string>();
            Collection = new string[3];
        }

        private void Btn_Taghsim_Click_1(object sender, EventArgs e)
        {
             if (Proc && GetNumber.Any(x=>x=="+"||x== "÷" || x== "×" || x == "Mod"))
            {
                //if (NowSign == "-")
                //    GetNumber.Add("-" + Txt_ShowResult.Text);
                //else
                //    GetNumber.Add(Txt_ShowResult.Text);
                GetNumber.RemoveAt(GetNumber.Count-1);
                GetNumber.Add("÷");
                Txt_Show.Text = Txt_Show.Text.Remove(Txt_Show.Text.LastIndexOf(NowSign) - 1);

                Txt_Show.Text += " ÷ ";

            }
            else
            {
                Txt_Show.Text +=    Txt_ShowResult.Text+ " ÷ ";
                if (NowSign == "-")
                    GetNumber.Add("-" + Txt_ShowResult.Text);
                else
                    GetNumber.Add(Txt_ShowResult.Text);
                GetNumber.Add("÷");

            }
            NowSign = "÷";
            Proc = true;
            Btn_Result.Focus();


        }

        private void Btn_Zarb_Click_1(object sender, EventArgs e)
        {
             if (Proc && GetNumber.Any(x => x == "+" || x == "÷" || x == "×" || x == "Mod"))
            {
                //if (NowSign == "-")
                //    GetNumber.Add("-" + Txt_ShowResult.Text);
                //else
                //    GetNumber.Add(Txt_ShowResult.Text);
                GetNumber.RemoveAt(GetNumber.Count-1);
                GetNumber.Add("×");
                Txt_Show.Text = Txt_Show.Text.Remove(Txt_Show.Text.LastIndexOf(NowSign) - 1);
                Txt_Show.Text += " × ";

            }
            else
            {
                Txt_Show.Text +=  Txt_ShowResult.Text+ " × ";
                if (NowSign == "-")
                    GetNumber.Add("-" + Txt_ShowResult.Text);
                else
                    GetNumber.Add(Txt_ShowResult.Text);
                GetNumber.Add("×");

            }
            NowSign = "×";
            Proc = true;
            Btn_Result.Focus();


        }
        string NowSign=string.Empty;
        private void Btn_Sum_Click_1(object sender, EventArgs e)
        {
             if (Proc && GetNumber.Any(x => x == "+" || x == "÷" || x == "×" || x == "Mod"))
            {
                //if (NowSign == "-")
                //    GetNumber.Add("-" + Txt_ShowResult.Text);
                //else
                    //GetNumber.Add(Txt_ShowResult.Text);
                GetNumber.RemoveAt(GetNumber.Count-1);
                GetNumber.Add("+");
                
               Txt_Show.Text= Txt_Show.Text.Remove(Txt_Show.Text.LastIndexOf(NowSign) - 1 );
                Txt_Show.Text += " + ";

            }
            else
            {
                Txt_Show.Text += Txt_ShowResult.Text+ " + ";
                if (NowSign == "-")
                    GetNumber.Add("-" + Txt_ShowResult.Text);
                else
                    GetNumber.Add(Txt_ShowResult.Text);
                GetNumber.Add("+");

            }
            NowSign = "+";
            Proc = true;
            Btn_Result.Focus();


        }

        private void Btn_Menha_Click_1(object sender, EventArgs e)
        {
            if (Proc && GetNumber.Any(x => x == "+" || x == "÷" || x == "×" || x == "Mod"))
            {
                //if(NowSign=="-")
                //GetNumber.Add("-"+Txt_ShowResult.Text);
                //else
                    //GetNumber.Add( Txt_ShowResult.Text);

                GetNumber.RemoveAt(GetNumber.Count - 1);
                GetNumber.Add("+");

                Txt_Show.Text = Txt_Show.Text.Remove(Txt_Show.Text.LastIndexOf(NowSign) - 1);
                Txt_Show.Text += " - ";

            }
            else
            {
                Txt_Show.Text += Txt_ShowResult.Text + " - ";
                if (NowSign == "-")
                    GetNumber.Add("-" + Txt_ShowResult.Text);
                else
                    GetNumber.Add(Txt_ShowResult.Text);
                GetNumber.Add("+");

            }
            NowSign = "-";
            Proc = true;
            Btn_Result.Focus();


        }

        private void Btn_Backspase_Click(object sender, EventArgs e)
        {
            if(Txt_ShowResult.Text!=string.Empty && !Proc)
            Txt_ShowResult.Text = Txt_ShowResult.Text.Remove(Txt_ShowResult.Text.Count() - 1,1);
            if (Txt_ShowResult.Text == string.Empty)
                Txt_ShowResult.Text = "0";
            Btn_Result.Focus();


        }

        private void Btn_Clear_Click(object sender, EventArgs e)
        {
            Txt_ShowResult.Text = "0";
            Btn_Result.Focus();

        }

        private void Btn_AllClear_Click(object sender, EventArgs e)
        {
            GetNumber = new List<string>();
            Txt_Show.Text = string.Empty;
            Txt_ShowResult.Text = "0";
            Btn_Result.Focus();

        }

        private void Btn_Radical_Click(object sender, EventArgs e)
        {
            if (double.Parse(Txt_ShowResult.Text)>=0 && Txt_Show.Text==string.Empty)
            {
                Txt_ShowResult.Text= Math.Sqrt(double.Parse(Txt_ShowResult.Text)).ToString();
            }
            Btn_Result.Focus();

        }

        private void Btn_Spot_Click(object sender, EventArgs e)
        {
            if (!Txt_ShowResult.Text.Any(x => x == '.'))
            {
                Button Bu = (Button)sender;
                if (Proc || Txt_ShowResult.Text == "0")
                    Txt_ShowResult.Text = string.Empty;
                Txt_ShowResult.Text += Bu.Text;
                Proc = false;
            }
        }

        private void Btn_ChangeAlamat_Click(object sender, EventArgs e)
        {
            double Do;
            if ((Do=double.Parse(Txt_ShowResult.Text))!=0)
            {
                Do *= -1;
                Txt_ShowResult.Text = Do.ToString();
            }
            Btn_Result.Focus();

        }

        private void Btn_Divisor_Click(object sender, EventArgs e)
        {
            if (Txt_Show.Text==string.Empty)
            {
                try
                {
                    int Number = int.Parse(Txt_ShowResult.Text);
                    if (Number<0)
                    {
                       
                        Number = Number * (-1);
                    }
                    string Res=string.Empty;
                    for (int i = 1; i <= Number; i++)
                    {
                        
                        if(Number % i == 0)
                        {
                            if (i==Number)
                            {
                                
                                Res += i.ToString();
                            }
                            else
                            {
                                Res += i.ToString()+",";

                            }
                        }
                        
                    }
                    Txt_ShowResult.Text = Res;
                }
                catch 
                {

                    
                }
                
            }
            Proc = true;
            Btn_Result.Focus();

        }
        bool numno = false;
        private void Txt_ShowResult_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void Txt_ShowResult_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        { 
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void Btn_Nine_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            
        }
        
        private void Btn_Nine_KeyDown_1(object sender, KeyEventArgs e)
        {
           
        }

        private void Btn_Result_KeyDown(object sender, KeyEventArgs e)
        {
            System.EventArgs arg = new EventArgs();
            if (!(e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9 || e.KeyCode == Keys.Back))
            {
                numno = true;
                switch (e.KeyValue)
                {
                    case 107:
                        Btn_Sum_Click_1("", arg);
                        break;
                    case 109:
                        Btn_Menha_Click_1("", arg);
                        break;
                    case 106:
                        Btn_Zarb_Click_1("", arg);
                        break;
                    case 111:
                        Btn_Taghsim_Click_1("", arg);
                        break;
                    case 13:
                        Btn_Result_Click("", arg);
                        break;
                    case 110:
                        Btn_Spot_Click_1(Btn_Spot, arg);
                        break;
                }
              
            }
            else
            {
                if (Proc || Txt_ShowResult.Text == "0")
                {
                    Txt_ShowResult.Text = string.Empty;
                    Proc = false;
                }

                numno = false;
            }
        }

        private void Btn_Result_KeyPress(object sender, KeyPressEventArgs e)
        {
            System.EventArgs arg = new EventArgs();

            if (!numno)
            {
                if (Proc)
                    Txt_ShowResult.Text = string.Empty;
                if (e.KeyChar == (char)Keys.Back)
                {
                    Btn_Backspase_Click("", arg);
                }
                else
                    Txt_ShowResult.Text += e.KeyChar.ToString();
            }
        }

        private void Txt_ShowResult_Click(object sender, EventArgs e)
        {
            Btn_Result.Focus();
        }

        private void Txt_ShowResult_Move(object sender, EventArgs e)
        {

        }

        private void Txt_ShowResult_MouseMove(object sender, MouseEventArgs e)
        {
            Btn_Result.Focus();

        }

        private void Txt_Show_MouseMove(object sender, MouseEventArgs e)
        {
            Btn_Result.Focus();
        }

        private void Btn_Mod_Click(object sender, EventArgs e)
        {
            if (Proc && GetNumber.Any(x => x == "+" || x == "÷" || x == "×" || x=="Mod"))
            {
                if (NowSign == "-")
                    GetNumber.Add("-" + Txt_ShowResult.Text);
                else
                    GetNumber.Add(Txt_ShowResult.Text);
                GetNumber.RemoveAt(GetNumber.Count - 1);
                GetNumber.Add("Mod");
                Txt_Show.Text = Txt_Show.Text.Remove(Txt_Show.Text.LastIndexOf(NowSign) - 1);

                Txt_Show.Text += " Mod ";

            }
            else
            {
                Txt_Show.Text += Txt_ShowResult.Text + " Mod ";
                if (NowSign == "-")
                    GetNumber.Add("-" + Txt_ShowResult.Text);
                else
                    GetNumber.Add(Txt_ShowResult.Text);
                GetNumber.Add("Mod");

            }
            NowSign = "Mod";
            Proc = true;
            Btn_Result.Focus();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {

           
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_MouseMove_1(object sender, MouseEventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox4.Visible = true;
        }

        private void pictureBox2_MouseMove_1(object sender, MouseEventArgs e)
        {
            pictureBox2.Visible = false;
            pictureBox3.Visible = true;
        }

        private void pictureBox4_MouseLeave_1(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            pictureBox4.Visible = false;
        }

        private void pictureBox3_MouseLeave_1(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
            pictureBox3.Visible = false;
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }
    }
}

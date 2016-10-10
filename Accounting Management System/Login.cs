using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accounting_Management_System
{
    public partial class Login : Form
    {
        AccountingDataClassesDataContext sdb = new AccountingDataClassesDataContext(); 
        public Login()
        {     
            InitializeComponent();       
        }
        private void button13_Click(object sender, EventArgs e)
        {
           Authentication obj = sdb.Authentications.SingleOrDefault(x => x.username == usr_txt.Text);
           if (obj.password == pass_txt.Text)
           {
               if (obj.username == "guest")
               {
                  
                   this.Visible = false;
                   Form1 form1 = new Form1();
                   form1.hide_button();
                   form1.Visible = true;
                   
               }
               else
               {
                   this.Visible = false;
                   Form1 form1 = new Form1();
                   form1.Visible = true;

               }
           }
           else
           {
               DialogResult result = MessageBox.Show("Wrong Username or Password!!! Try Again?", "caption", MessageBoxButtons.YesNo);
               if (result == DialogResult.Yes)
               {
                   usr_txt.Text = "";
                   pass_txt.Text = "";

               }
               else if (result == DialogResult.No)
               {
                   Application.Exit();
               }
           }
        }
    }
}

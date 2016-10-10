using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Accounting_Management_System
{
  
    public partial class Form1 : Form
    {
        private class Item {
      public string Name;
      public int Value;
      public Item(string name, int value) {
        Name = name; Value = value;
      }
      public override string ToString()
      {
          // Generates the text shown in the combo box
          return Name;
      }
        }
        
        BindingSource bs = new BindingSource();
        public Form1()
        {
            
            InitializeComponent();
            
        }
       public void hide_button()
        {
           emp_save.Hide();
           emp_update.Hide();
           emp_delete.Hide();

           trans_save.Hide();
           trans_update.Hide();
           trans_delete.Hide();

           accnt_save.Hide();
           accnt_update.Hide();
           accnt_delete.Hide();

           prjct_save.Hide();
           prjct_update.Hide();
           prjct_delete.Hide();

           clnt_save.Hide();
           clnt_update.Hide();
           clnt_delete.Hide();

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'accountingDBDataSet5.Client' table. You can move, or remove it, as needed.
            this.clientTableAdapter2.Fill(this.accountingDBDataSet5.Client);
            // TODO: This line of code loads data into the 'accountingDBDataSet5.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter3.Fill(this.accountingDBDataSet5.Employee);
            // TODO: This line of code loads data into the 'accountingDBDataSet4.Employee' table. You can move, or remove it, as needed.
          //  this.employeeTableAdapter2.Fill(this.accountingDBDataSet4.Employee);
          
            // TODO: This line of code loads data into the 'accountingDBDataSet1.Client' table. You can move, or remove it, as needed.
         //   this.clientTableAdapter1.Fill(this.accountingDBDataSet1.Client);
            // TODO: This line of code loads data into the 'accountingDBDataSet1.Employee' table. You can move, or remove it, as needed.
          //  this.employeeTableAdapter1.Fill(this.accountingDBDataSet1.Employee);
            // TODO: This line of code loads data into the 'accountingDBDataSet.Departments' table. You can move, or remove it, as needed.
            // TODO: This line of code loads data into the 'accountingDBDataSet.Client' table. You can move, or remove it, as needed.
          //  this.clientTableAdapter.Fill(this.accountingDBDataSet.Client);
            // TODO: This line of code loads data into the 'accountingDBDataSet.Transactions' table. You can move, or remove it, as needed.
            this.transactionsTableAdapter.Fill(this.accountingDBDataSet.Transactions);
            // TODO: This line of code loads data into the 'accountingDBDataSet.Accounts' table. You can move, or remove it, as needed.
            this.accountsTableAdapter.Fill(this.accountingDBDataSet.Accounts);
            // TODO: This line of code loads data into the 'accountingDBDataSet.Project' table. You can move, or remove it, as needed.
            this.projectTableAdapter.Fill(this.accountingDBDataSet.Project);
            // TODO: This line of code loads data into the 'accountingDBDataSet.Employee' table. You can move, or remove it, as needed.
           // this.employeeTableAdapter.Fill(this.accountingDBDataSet.Employee);
            // TODO: This line of code loads data into the 'accountingDBDataSet.Employee' table. You can move, or remove it, as needed.
        //    this.employeeTableAdapter.Fill(this.accountingDBDataSet.Employee);
         }

        private void search_Click(object sender, EventArgs e)
        {
            using (AccountingDataClassesDataContext sdb = new AccountingDataClassesDataContext())
            {
                string nameString = search_combo.GetItemText(this.search_combo.SelectedItem);

               
                if (!string.IsNullOrEmpty(nameString))
                {
                    if (search_by.GetItemText(this.search_by.SelectedItem) == "ID")
                        
                    {
                        int searchedId;
                        Int32.TryParse(searchBox.Text, out searchedId);
                        if (nameString == "Accounts")
                        {
                            if (!string.IsNullOrWhiteSpace(searchBox.Text))
                            {
                                if (sdb.Accounts.SingleOrDefault(x => x.acc_id == searchedId) != null)
                                {
                                    searchresult.Text = "Found!!!";
                                    searchresult.Show();
                                    search_grid.Show();
                                    Account a = sdb.Accounts.SingleOrDefault(x => x.acc_id == searchedId);
                                    bs.DataSource = a;
                                    search_grid.DataSource = bs;
                                }
                                else
                                {
                                    searchresult.Text = "Not Found!!!!";
                                    searchresult.Show();
                                    search_grid.Hide();
                                }
                            }
                        }
                        else if (nameString == "Client")
                        {
                            if (sdb.Clients.SingleOrDefault(x => x.client_id == searchedId) != null)
                            {
                                searchresult.Text = "Found!!!";
                                searchresult.Show();
                                search_grid.Show();
                                Client a = sdb.Clients.SingleOrDefault(x => x.client_id == searchedId);
                                bs.DataSource = a;
                                search_grid.DataSource = bs;
                                
                                search_pictureBox.Image = Image.FromFile(search_grid.Rows[0].Cells[5].Value.ToString());
                            }
                            else
                            {
                                searchresult.Text = "Not Found!!!!";
                                searchresult.Show();
                                search_grid.Hide();
                            }
                        }

                        else if (nameString == "Employee")
                        {
                            if (sdb.Employees.SingleOrDefault(x => x.emp_id == searchedId) != null)
                            {
                                searchresult.Text = "Found!!!";
                                searchresult.Show();
                                search_grid.Show();
                                Employee a = sdb.Employees.SingleOrDefault(x => x.emp_id == searchedId);
                                bs.DataSource = a;
                                search_grid.DataSource = bs;
                                
                                search_pictureBox.Image = Image.FromFile(search_grid.Rows[0].Cells[9].Value.ToString());
                            }
                            else
                            {
                                searchresult.Text = "Not Found!!!!";
                                searchresult.Show();
                                search_grid.Hide();
                            }
                        }
                        else if (nameString == "Project")
                        {
                            if (sdb.Projects.SingleOrDefault(x => x.prjct_id == searchedId) != null)
                            {
                                searchresult.Text = "Found!!!";
                                searchresult.Show();
                                search_grid.Show();
                                Project a = sdb.Projects.SingleOrDefault(x => x.prjct_id == searchedId);
                                bs.DataSource = a;
                                search_grid.DataSource = bs;
                            }
                            else
                            {
                                searchresult.Text = "Not Found!!!!";
                                searchresult.Show();
                                search_grid.Hide();
                            }
                        }
                        else if (nameString == "Transactions")
                        {

                            if (sdb.Transactions.SingleOrDefault(x => x.trans_id == searchedId) != null)
                            {
                                searchresult.Text = "Found!!!";
                                searchresult.Show();
                                search_grid.Show();
                                Transaction a = sdb.Transactions.SingleOrDefault(x => x.trans_id == searchedId);
                                bs.DataSource = a;
                                search_grid.DataSource = bs;
                            }
                            else
                            {
                                searchresult.Text = "Not Found!!!!";
                                searchresult.Show();
                                search_grid.Hide();
                            }
                        }
                    }
                    else if (search_by.GetItemText(this.search_by.SelectedItem) == "Name")
                    {
                        string searchedName = searchBox.Text;
                        if (nameString == "Accounts")
                        {
                            if (!string.IsNullOrWhiteSpace(searchBox.Text))
                            {
                                
                                if (sdb.Accounts.SingleOrDefault(x => x.acc_hd == searchedName) != null)
                                {
                                    searchresult.Text = "Found!!!";
                                    searchresult.Show();
                                    search_grid.Show();
                                    Account a = sdb.Accounts.SingleOrDefault(x => x.acc_hd == searchedName);
                                    bs.DataSource = a;
                                    search_grid.DataSource = bs;
                                }
                                else
                                {
                                    searchresult.Text = "Not Found!!!!";
                                    searchresult.Show();
                                    search_grid.Hide();
                                }
                            }
                        }
                        else if (nameString == "Client")
                        {
                            if (sdb.Clients.SingleOrDefault(x => x.clent_name == searchedName) != null)
                            {
                                searchresult.Text = "Found!!!";
                                searchresult.Show();
                                search_grid.Show();
                                Client a = sdb.Clients.SingleOrDefault(x => x.clent_name == searchedName);
                                bs.DataSource = a;
                                search_grid.DataSource = bs;
                                search_pictureBox.Image = Image.FromFile(search_grid.Rows[0].Cells[5].Value.ToString());
                            }
                            else
                            {
                                searchresult.Text = "Not Found!!!!";
                                searchresult.Show();
                                search_grid.Hide();
                            }
                        }

                        else if (nameString == "Employee")
                        {
                            if (sdb.Employees.SingleOrDefault(x => x.emp_name == searchedName) != null)
                            {
                                searchresult.Text = "Found!!!";
                                searchresult.Show();
                                search_grid.Show();
                                Employee a = sdb.Employees.SingleOrDefault(x => x.emp_name == searchedName);
                                bs.DataSource = a;
                                search_grid.DataSource = bs;
                                search_pictureBox.Image = Image.FromFile(search_grid.Rows[0].Cells[9].Value.ToString());
                            }
                            else
                            {
                                searchresult.Text = "Not Found!!!!";
                                searchresult.Show();
                                search_grid.Hide();
                            }
                        }
                        else if (nameString == "Project")
                        {
                            if (sdb.Projects.SingleOrDefault(x => x.prjct_name == searchedName) != null)
                            {
                                searchresult.Text = "Found!!!";
                                searchresult.Show();
                                search_grid.Show();
                                Project a = sdb.Projects.SingleOrDefault(x => x.prjct_name == searchedName);
                                bs.DataSource = a;
                                search_grid.DataSource = bs;
                            }
                            else
                            {
                                searchresult.Text = "Not Found!!!!";
                                searchresult.Show();
                                search_grid.Hide();
                            }
                        }
                        else if (nameString == "Transactions")
                        {

                            if (sdb.Transactions.SingleOrDefault(x => x.trans_date == DateTime.Parse(searchedName)) != null)
                            {
                                searchresult.Text = "Found!!!";
                                searchresult.Show();
                                search_grid.Show();
                                Transaction a = sdb.Transactions.SingleOrDefault(x => x.trans_date == DateTime.Parse(searchedName));
                                bs.DataSource = a;
                                search_grid.DataSource = bs;
                            }
                            else
                            {
                                searchresult.Text = "Not Found!!!!";
                                searchresult.Show();
                                search_grid.Hide();
                            }
                        }
                    }
                    else
                    {
                        searchresult.Text = "Lack of Information!!!";
                        searchresult.Show();
                    }
                }
            }  

        }
        private void emp_grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int i = e.RowIndex;
            DataGridViewRow row = emp_grid.Rows[i];
            emp_id.Text = row.Cells[0].Value.ToString();
            emp_name.Text = row.Cells[1].Value.ToString();
            design.Text = row.Cells[2].Value.ToString();
            joindate.Text = row.Cells[3].Value.ToString();
            basic.Text = row.Cells[4].Value.ToString();
            rcvbl.Text = row.Cells[5].Value.ToString();
            address.Text = row.Cells[6].Value.ToString();
            phn_no.Text = row.Cells[7].Value.ToString();
            emp_mail.Text = row.Cells[8].Value.ToString();
            try
            {
                emp_pictureBox.Image = Image.FromFile(row.Cells[9].Value.ToString());
            }
            catch(Exception)
            {
                MessageBox.Show("You didnt enter an image!");
            }
            dept_name.Text = row.Cells[10].Value.ToString();
            
        }


        private void accnt_grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int i = e.RowIndex;
            DataGridViewRow row = accnt_grid.Rows[i];
            acc_id.Text = row.Cells[0].Value.ToString();
            acc_hd.Text = row.Cells[1].Value.ToString();
            rept_hd.Text = row.Cells[2].Value.ToString();
            vchr_hd.Text = row.Cells[3].Value.ToString();
            bill_amnt.Text = row.Cells[4].Value.ToString();
            
        }
        private void trans_grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int i = e.RowIndex;
            DataGridViewRow row = trans_grid.Rows[i];
            trans_id.Text = row.Cells[0].Value.ToString();
            trans_date.Text = row.Cells[1].Value.ToString();
            donor_id.Text = row.Cells[2].Value.ToString();
            rcvr_id.Text = row.Cells[3].Value.ToString();
            amount.Text = row.Cells[4].Value.ToString();
            
        }
        private void prjct_grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int i = e.RowIndex;
            DataGridViewRow row = prjct_grid.Rows[i];
            prjct_id.Text = row.Cells[0].Value.ToString();
            prjct_name.Text = row.Cells[1].Value.ToString();
            prjct_status.Text = row.Cells[2].Value.ToString();
            curr_amount.Text = row.Cells[3].Value.ToString();
            prjct_exp1.Text = row.Cells[4].Value.ToString();
            rc_able.Text = row.Cells[5].Value.ToString();
            client.Text = row.Cells[6].Value.ToString();
            
        }
        private void client_grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int i = e.RowIndex;
            DataGridViewRow row = client_grid.Rows[i];
            client_id.Text = row.Cells[0].Value.ToString();
            clent_name.Text = row.Cells[1].Value.ToString();
            client_address.Text = row.Cells[2].Value.ToString();
            phone_no.Text = row.Cells[3].Value.ToString();
            cl_mail.Text = row.Cells[4].Value.ToString();
            try { 
            client_pictureBox.Image = Image.FromFile(row.Cells[5].Value.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("You didnt enter an image!");
            }
        }
        

        private void emp_update_Click(object sender, EventArgs e)
        {
            using (AccountingDataClassesDataContext sdb = new AccountingDataClassesDataContext())
            {
               
                    int id = Int32.Parse(emp_id.Text);
                    Employee emp = sdb.Employees.SingleOrDefault(x => x.emp_id == id);
                    int emp_id1, basic_sal1;
                    Int32.TryParse(emp_id.Text, out emp_id1);
                    emp.emp_id = emp_id1;
                    emp.emp_name = emp_name.Text;
                    emp.designation = design.Text;
                    emp.joindate = DateTime.Parse(joindate.Text);
                    Int32.TryParse(basic.Text, out basic_sal1);
                    emp.basic_sal = basic_sal1;
                    emp.receivable = float.Parse(rcvbl.Text);
                    emp.address = address.Text;
                    emp.phone_no = phn_no.Text;
                    emp.mail = emp_mail.Text;
                    emp.emp_picture = emp_pictureBox.ImageLocation;
                    emp.dept_name = dept_name.Text;
                    sdb.SubmitChanges();
                    this.employeeTableAdapter3.Fill(this.accountingDBDataSet5.Employee);
                
            }
        }

        private void accnt_update_Click(object sender, EventArgs e)
        {
            using (AccountingDataClassesDataContext sdb = new AccountingDataClassesDataContext())
            {
                    int id = Int32.Parse(acc_id.Text);
                    Account accnt = sdb.Accounts.SingleOrDefault(x => x.acc_id == id);
                    accnt.acc_id = Int32.Parse(acc_id.Text);
                    accnt.acc_hd = acc_hd.Text;
                    accnt.rept_hd = rept_hd.Text;
                    accnt.vchr_hd = vchr_hd.Text;
                    accnt.bill_amnt = float.Parse(bill_amnt.Text);
                    sdb.SubmitChanges();
                    this.accountsTableAdapter.Fill(this.accountingDBDataSet.Accounts);
           }
        }

        private void trans_update_Click(object sender, EventArgs e)
        {
            using (AccountingDataClassesDataContext sdb = new AccountingDataClassesDataContext())
            {
                
                    int id = Int32.Parse(trans_id.Text);
                    Transaction trans = sdb.Transactions.SingleOrDefault(x => x.trans_id == id);
                    trans.trans_id = Int32.Parse(trans_id.Text);
                    trans.trans_date = DateTime.Parse(trans_date.Text);
                    trans.donor_id = Int32.Parse(donor_id.Text);
                    trans.rcvr_id = Int32.Parse(rcvr_id.Text);
                    trans.amount = Int32.Parse(amount.Text);
                    sdb.SubmitChanges();
                    this.transactionsTableAdapter.Fill(this.accountingDBDataSet.Transactions);
                
            }
        }

        private void prjct_update_Click(object sender, EventArgs e)
        {
            using (AccountingDataClassesDataContext sdb = new AccountingDataClassesDataContext())
            {

                try
                {
                    int id = Int32.Parse(prjct_id.Text);
                    Project prjct = sdb.Projects.SingleOrDefault(x => x.prjct_id == id);
                    prjct.prjct_id = Int32.Parse(prjct_id.Text);
                    prjct.prjct_name = prjct_name.Text;
                    prjct.prjct_status = prjct_status.Text;
                    prjct.curr_amount = float.Parse(curr_amount.Text);
                    prjct.prjct_exp = float.Parse(prjct_exp1.Text);
                    prjct.rc_able = float.Parse(rc_able.Text);
                    prjct.client = Int32.Parse(client.Text);
                    sdb.SubmitChanges();
                    this.projectTableAdapter.Fill(this.accountingDBDataSet.Project);
                }
                catch (SqlException)
                {
                    MessageBox.Show("Client ID not present!");
                }
              
            }
        }

        private void clnt_update_Click(object sender, EventArgs e)
        {
            using (AccountingDataClassesDataContext sdb = new AccountingDataClassesDataContext())
            {
                
                    int id = Int32.Parse(client_id.Text);
                    Client clnt = sdb.Clients.SingleOrDefault(x => x.client_id == id); ;
                    clnt.client_id = Int32.Parse(client_id.Text);
                    clnt.clent_name = clent_name.Text;
                    clnt.client_address = client_address.Text;
                    clnt.phone_no = phn_no.Text;
                    clnt.mail = emp_mail.Text;
                    clnt.client_picture = client_pictureBox.ImageLocation;
                    sdb.SubmitChanges();
                    this.clientTableAdapter2.Fill(this.accountingDBDataSet5.Client);

            }
        }

        private void emp_delete_Click(object sender, EventArgs e)
        {
            
                using (AccountingDataClassesDataContext sdb = new AccountingDataClassesDataContext())
                {
                    int emp_id1 = Int32.Parse(emp_id.Text);
                    Employee emp_del = sdb.Employees.Single(x => x.emp_id == emp_id1);
                    sdb.Employees.DeleteOnSubmit(emp_del);
                    sdb.SubmitChanges();
                    this.employeeTableAdapter3.Fill(this.accountingDBDataSet5.Employee);
                }
            
        }

        private void accnt_delete_Click(object sender, EventArgs e)
        {
           
            using (AccountingDataClassesDataContext sdb = new AccountingDataClassesDataContext())
            {
                int accnt_id1 = Int32.Parse(acc_id.Text);
                Account accnt_del = sdb.Accounts.Single(x => x.acc_id == accnt_id1);
                sdb.Accounts.DeleteOnSubmit(accnt_del);
                sdb.SubmitChanges();
                this.accountsTableAdapter.Fill(this.accountingDBDataSet.Accounts);
            }
           
        }

        private void trans_delete_Click(object sender, EventArgs e)
        {
            try { 
            using (AccountingDataClassesDataContext sdb = new AccountingDataClassesDataContext())
            {
                int trans_id1 = Int32.Parse(trans_id.Text);
                Transaction trans_del = sdb.Transactions.Single(x => x.trans_id == trans_id1);
                sdb.Transactions.DeleteOnSubmit(trans_del);
                sdb.SubmitChanges();
                this.transactionsTableAdapter.Fill(this.accountingDBDataSet.Transactions);
            }
            }
            catch (SqlException)
            {
                MessageBox.Show("SQL Exception. Maybe you are trying to delete a primary key value that references another tables foreign key!!!");
            }
        }

        private void prjct_delete_Click(object sender, EventArgs e)
        {
            try { 
            using (AccountingDataClassesDataContext sdb = new AccountingDataClassesDataContext())
            {
                int prjct_id1 = Int32.Parse(prjct_id.Text);
                Project prjct_del = sdb.Projects.Single(x => x.prjct_id == prjct_id1);
                sdb.Projects.DeleteOnSubmit(prjct_del);
                sdb.SubmitChanges();
                this.projectTableAdapter.Fill(this.accountingDBDataSet.Project);
            }
            }
            catch (SqlException)
            {
                MessageBox.Show("SQL Exception. Maybe you are trying to delete a primary key value that references another tables foreign key!!!");
            }
        }

        private void clnt_delete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("This option can remove a some rows from another table. Are you sure?", "caption", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                using (AccountingDataClassesDataContext sdb = new AccountingDataClassesDataContext())
                {
                    int clnt_id1 = Int32.Parse(client_id.Text);
                    Client clnt_del = sdb.Clients.Single(x => x.client_id == clnt_id1);
                    while (sdb.Projects.SingleOrDefault(x => x.client == clnt_id1) != null)
                    {
                        Project prjct = sdb.Projects.Single(x => x.client == clnt_id1);
                        sdb.Projects.DeleteOnSubmit(prjct);
                        sdb.SubmitChanges();
                        this.projectTableAdapter.Fill(this.accountingDBDataSet.Project);
                    }
                    sdb.Clients.DeleteOnSubmit(clnt_del);
                    sdb.SubmitChanges();
                    this.clientTableAdapter2.Fill(this.accountingDBDataSet5.Client);
                }
            }
            else if (result == DialogResult.No)
            {
                
            }
        }

        private void clnt_save_Click(object sender, EventArgs e)
        {
            try
            {

                using (AccountingDataClassesDataContext sdb = new AccountingDataClassesDataContext())
                {
                    Client clnt = new Client();
                    clnt.client_id = Int32.Parse(client_id.Text);
                    clnt.clent_name = clent_name.Text;
                    clnt.client_address = client_address.Text;
                    clnt.phone_no = phone_no.Text;
                    clnt.mail = cl_mail.Text;
                    clnt.client_picture = client_pictureBox.ImageLocation;
                    sdb.Clients.InsertOnSubmit(clnt);
                    sdb.SubmitChanges();
                    this.clientTableAdapter2.Fill(this.accountingDBDataSet5.Client);
                    MessageBox.Show("Data Inserted!");
                }
            }catch(SqlException){
                MessageBox.Show("SQL Exception");
            }
        }

        private void emp_save_Click(object sender, EventArgs e)
        {
           
                using (AccountingDataClassesDataContext sdb = new AccountingDataClassesDataContext())
                {
                    Employee emp = new Employee();
                    emp.emp_id = Int32.Parse(emp_id.Text);
                    emp.emp_name = emp_name.Text;
                    emp.designation = design.Text;
                    emp.joindate = DateTime.Parse(joindate.Text);
                    emp.basic_sal = float.Parse(basic.Text);
                    emp.receivable = float.Parse(rcvbl.Text);
                    emp.address = address.Text;
                    emp.phone_no = phn_no.Text;
                    emp.mail = emp_mail.Text;
                    emp.emp_picture = emp_pictureBox.ImageLocation;
                    emp.dept_name=dept_name.Text;
                    sdb.Employees.InsertOnSubmit(emp);
                    sdb.SubmitChanges();
                    this.employeeTableAdapter3.Fill(this.accountingDBDataSet5.Employee);
                    MessageBox.Show("Data Inserted!");
                }
            
            
        }

        private void accnt_save_Click(object sender, EventArgs e)
        {
           
                using (AccountingDataClassesDataContext sdb = new AccountingDataClassesDataContext())
                {
                    Account accnt = new Account();
                    accnt.acc_id = Int32.Parse(acc_id.Text);
                    accnt.acc_hd = acc_hd.Text;
                    accnt.rept_hd = rept_hd.Text;
                    accnt.vchr_hd = vchr_hd.Text;
                    accnt.bill_amnt = float.Parse(bill_amnt.Text);
                    sdb.Accounts.InsertOnSubmit(accnt);
                    sdb.SubmitChanges();
                    this.accountsTableAdapter.Fill(this.accountingDBDataSet.Accounts);
                    MessageBox.Show("Data Inserted!");
                }
          
            
        }

        private void trans_save_Click(object sender, EventArgs e)
        {
            
                using (AccountingDataClassesDataContext sdb = new AccountingDataClassesDataContext())
                {
                    Transaction trans = new Transaction();
                    trans.trans_id = Int32.Parse(trans_id.Text);
                    trans.trans_date = DateTime.Parse(trans_date.Text);
                    trans.donor_id = Int32.Parse(donor_id.Text);
                    trans.rcvr_id = Int32.Parse(rcvr_id.Text);
                    trans.amount = float.Parse(amount.Text);
                    sdb.Transactions.InsertOnSubmit(trans);
                    sdb.SubmitChanges();
                    this.transactionsTableAdapter.Fill(this.accountingDBDataSet.Transactions);
                    MessageBox.Show("Data Inserted!");
                }
           
            
        }

        private void prjct_save_Click(object sender, EventArgs e)
        {
            try{   
                using (AccountingDataClassesDataContext sdb = new AccountingDataClassesDataContext())
                {
                    Project prjct = new Project();
                    prjct.prjct_id = Int32.Parse(prjct_id.Text);
                    prjct.prjct_name = prjct_name.Text;
                    prjct.prjct_status = prjct_status.Text;
                    prjct.curr_amount = float.Parse(curr_amount.Text);
                    prjct.prjct_exp = float.Parse(prjct_exp1.Text);
                    prjct.rc_able = float.Parse(rc_able.Text);
                    prjct.client = Int32.Parse(client.Text);
                    sdb.Projects.InsertOnSubmit(prjct);
                    sdb.SubmitChanges();
                    this.projectTableAdapter.Fill(this.accountingDBDataSet.Project);
                    MessageBox.Show("Data Inserted!");
                }
            }
            catch(SqlException)
            {
                MessageBox.Show("Client ID Not present!");
            }
            
            
        }

       

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void category_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            search_combo_name.SelectedIndex = -1;
            string nameString = category_combo.GetItemText(this.category_combo.SelectedItem);

             if (nameString == "Client")
            {
                search_combo_name.Items.Clear();
                int rows = client_grid.Rows.Count;
                for (int i = 0; i < rows; i++)
                {
                    int id = Int32.Parse(client_grid.Rows[i].Cells[0].Value.ToString());
                    string value = client_grid.Rows[i].Cells[1].Value.ToString();
                    search_combo_name.Items.Add(new Item(value, id));
                }
            }
            
            else if (nameString == "Employee")
            {
                search_combo_name.Items.Clear();
                int rows = emp_grid.Rows.Count;
                for (int i = 0; i < rows; i++)
                {
                    int id = Int32.Parse(emp_grid.Rows[i].Cells[0].Value.ToString());
                    string value = emp_grid.Rows[i].Cells[1].Value.ToString();
                    search_combo_name.Items.Add(new Item(value, id));
                }
            }
            else if (nameString == "Project")
            {
                search_combo_name.Items.Clear();
                int rows = prjct_grid.Rows.Count;
                for (int i = 0; i < rows; i++)
                {
                    int id = Int32.Parse(prjct_grid.Rows[i].Cells[0].Value.ToString());
                    string value = prjct_grid.Rows[i].Cells[1].Value.ToString();
                    search_combo_name.Items.Add(new Item(value, id));
                }
            }
            
         }

        

        

        private void emp_browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "C# Corner Open File Dialog";
            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "Image Files (*.bmp, *.jpg, *.jpeg, *.png)|*.bmp;*.jpg;*.jpeg;*.png";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                emp_pictureBox.ImageLocation = fdlg.FileName;
            }
        }

        private void client_browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "C# Corner Open File Dialog";
            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "Image Files (*.bmp, *.jpg, *.jpeg, *.png)|*.bmp;*.jpg;*.jpeg;*.png";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                client_pictureBox.ImageLocation = fdlg.FileName;
            }
        }

        private void search_by_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (search_by.GetItemText(this.search_by.SelectedItem)=="ID")
            {
                searchLabel.Show();
                searchLabel.Text="Search By ID :";
                searchBox.Show();
            }
            else if (search_by.GetItemText(this.search_by.SelectedItem)=="Name")
            {
                searchLabel.Show();
                searchLabel.Text = "Search By Name :";
                searchBox.Show();
            }
            

        }

        private void search_combo_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
                string select = category_combo.GetItemText(this.category_combo.SelectedItem);
            string nameString = search_combo_name.GetItemText(this.search_combo_name.SelectedItem);
                        
                        if (select == "Client")
                        {
                            using (AccountingDataClassesDataContext sdb = new AccountingDataClassesDataContext())
                            {

                                if (sdb.Clients.SingleOrDefault(x => x.clent_name == nameString) != null)
                                {
                                    searchresult.Text = "Found!!!";
                                    searchresult.Show();
                                    search_grid.Show();
                                    Client a = sdb.Clients.SingleOrDefault(x => x.clent_name == nameString);
                                    bs.DataSource = a;
                                    search_grid.DataSource = bs;
                                    search_pictureBox.Image = Image.FromFile(search_grid.Rows[0].Cells[5].Value.ToString());
                                }
                                else
                                {
                                    searchresult.Text = "Not Found!!!!";
                                    searchresult.Show();
                                    search_grid.Hide();
                                }
                            }
                        }

                        else if (select == "Employee")
                        {
                            using (AccountingDataClassesDataContext sdb = new AccountingDataClassesDataContext())
                            {

                                if (sdb.Employees.SingleOrDefault(x => x.emp_name == nameString) != null)
                                {
                                    searchresult.Text = "Found!!!";
                                    searchresult.Show();
                                    search_grid.Show();
                                    Employee a = sdb.Employees.SingleOrDefault(x => x.emp_name == nameString);
                                    bs.DataSource = a;
                                    search_grid.DataSource = bs;
                                    search_pictureBox.Image = Image.FromFile(search_grid.Rows[0].Cells[9].Value.ToString());
                                }
                                else
                                {
                                    searchresult.Text = "Not Found!!!!";
                                    searchresult.Show();
                                    search_grid.Hide();
                                }
                            }
                        }
                        else if (select == "Project")
                        {
                            using (AccountingDataClassesDataContext sdb = new AccountingDataClassesDataContext())
                            {
                                if (sdb.Projects.SingleOrDefault(x => x.prjct_name == nameString) != null)
                                {
                                    searchresult.Text = "Found!!!";
                                    searchresult.Show();
                                    search_grid.Show();
                                    Project a = sdb.Projects.SingleOrDefault(x => x.prjct_name == nameString);
                                    bs.DataSource = a;
                                    search_grid.DataSource = bs;
                                }
                                else
                                {
                                    searchresult.Text = "Not Found!!!!";
                                    searchresult.Show();
                                    search_grid.Hide();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Hello");
                        }
                        
                    }
        
        

                
      }
}
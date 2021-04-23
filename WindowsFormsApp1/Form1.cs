using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        SqlConnection connection = new SqlConnection("Data Source=MDT-0136;Initial Catalog=db1;Integrated Security=True ");
        string Customer_Id = String.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            String InsertQuery = "insert into [dbo].[Customer] (CustomerId,Company_Name, Contact_Name, Contact_Title, Addres, City , Postal_code,Phone, Religion,Country, Fax) Values ('"+txtId.Text+"' ,'" + txtCompanyName.Text + "' ,'" + txtContactName.Text + "','" + txtContactTitle.Text + "','" + txtAddress.Text + "','" + txtCity.Text + "','" + txtPostal.Text + "','" + txtPhone.Text + "' ,'" + txtRegion.Text + "','" + txtCountry.Text + "','" + txtFax.Text + "')";
            SqlCommand command = new SqlCommand(InsertQuery, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            BindGrid();
        }
        public void LoadData()
        {
            gvCustomer.Refresh();
            gvCustomer.ClearSelection();
        }
        public void BindGrid()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Customer", connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gvCustomer.DataSource = ds.Tables[0];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindGrid();

        }



        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            String InsertQuery = "Delete from Customer where CustomerId =" + Customer_Id;
            SqlCommand command = new SqlCommand(InsertQuery, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            BindGrid();
        }
        
        private void GvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            string Company_Name = gvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
            string Contact_Name = gvCustomer.Rows[e.RowIndex].Cells[2].Value.ToString();
            string Contact_Title = gvCustomer.Rows[e.RowIndex].Cells[3].Value.ToString();
            string Address = gvCustomer.Rows[e.RowIndex].Cells[4].Value.ToString();
            string City = gvCustomer.Rows[e.RowIndex].Cells[5].Value.ToString();
            string Postal_Code = gvCustomer.Rows[e.RowIndex].Cells[6].Value.ToString();
            string Phone = gvCustomer.Rows[e.RowIndex].Cells[7].Value.ToString();
            string Region = gvCustomer.Rows[e.RowIndex].Cells[8].Value.ToString();
            string Country = gvCustomer.Rows[e.RowIndex].Cells[9].Value.ToString();
            string Fax = gvCustomer.Rows[e.RowIndex].Cells[10].Value.ToString();

            Customer_Id = gvCustomer.Rows[e.RowIndex].Cells[0].Value.ToString();

            txtCompanyName.Text = Company_Name;
            txtContactName.Text = Contact_Name;
            txtContactTitle.Text = Contact_Title;
            txtAddress.Text = Address;
            txtCity.Text = City;
            txtPostal.Text = Postal_Code;
            txtPhone.Text = Phone;
            txtRegion.Text = Region;
            txtCountry.Text = Country;
            txtFax.Text = Fax;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            String DeleteQuery = "Update Customer set Company_Name = '" + txtCompanyName.Text + "' ,Contact_Name = '" + txtContactName.Text + "',Contact_Title = '" + txtContactTitle.Text + "',Addres = '" + txtAddress.Text + "', City ='" + txtCity.Text + "',Postal_code = '" + txtPostal.Text + "',Phone ='" + txtPhone.Text + "' ,Religion = '" + txtRegion.Text + "',Country = '" + txtCountry.Text + "', Fax ='" + txtFax.Text + "' where CustomerID = " + Customer_Id;
            SqlCommand command = new SqlCommand(DeleteQuery, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            BindGrid();
        }
    }
}

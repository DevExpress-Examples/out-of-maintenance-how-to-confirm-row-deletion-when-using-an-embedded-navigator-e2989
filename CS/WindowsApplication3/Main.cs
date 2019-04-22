using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;


namespace DXSample {
    public partial class Main: XtraForm {
        public Main() {
            InitializeComponent();
        }
        public void InitData() {
            DataSet dataSet11 = new DataSet();
            dataSet11.Tables.Add(GetCustomerDataTable());
            dataSet11.Tables.Add(GetPersonDataTable());
            DataColumn keyColumn = dataSet11.Tables["Customers"].Columns["ID"];
            DataColumn foreignKeyColumn = dataSet11.Tables["Persons"].Columns["ID"];
            dataSet11.Relations.Add("CustomersPersons", keyColumn, foreignKeyColumn);
            gridControl1.DataSource = dataSet11.Tables["Customers"];
        }

        DataTable GetCustomerDataTable()
        {
            DataTable table = new DataTable();
            table.TableName = "Customers";
            table.Columns.Add(new DataColumn("Items", typeof(string)));
            table.Columns.Add(new DataColumn("Money", typeof(double)));
            table.Columns.Add(new DataColumn("ID", typeof(int)));
            for (int i = 0; i < 10; i++)
                table.Rows.Add("Product " + i, 3000 + i * 298.55M, i);
            return table;
        }
        DataTable GetPersonDataTable()
        {
            DataTable table = new DataTable();
            table.TableName = "Persons";
            table.Columns.Add(new DataColumn("FirstName", typeof(string)));
            table.Columns.Add(new DataColumn("SecondName", typeof(string)));
            table.Columns.Add(new DataColumn("Age", typeof(int)));
            table.Columns.Add(new DataColumn("ID", typeof(int)));
            for (int i = 0; i < 50; i++)
            {
                string name = "Adam";
                string secondName = "Smith";
                if (i % 2 == 0)
                {
                    name = "Ben";
                    secondName = "Black";
                }
                table.Rows.Add(name, secondName, 20 + i / 2, i % 10);
            }
            return table;
        }

        private void Form1_Load(object sender, EventArgs e) {
            InitData();
        }

        private void OnEmbeddedNavigaotrButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == NavigatorButtonType.Remove)
            {
                if (MessageBox.Show("Do you want to delete the current row?", "Confirm deletion",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != DialogResult.Yes)
                    e.Handled = true;
            }

        }
    }
}

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
            for(int i = 0;i < 5;i++) {
                dataSet11.Tables[0].Rows.Add(new object[] { i, string.Format("FirstName {0}", i), i, null, DateTime.Today.AddDays(i), true });
                dataSet11.Tables[1].Rows.Add(new object[] { i, i, i });
            }
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

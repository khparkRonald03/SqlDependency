using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Security.Permissions;
namespace NotiTest
{
    public partial class NotiTest2 : Form
    {
        string connectionString = "server=localhost; database=Dentop_Test; user id =sa; pwd=ecnad";

        string queueName = "Test";

        SqlConnection connection;

        SqlCommand command;

        public NotiTest2()
        {
            InitializeComponent();

            connection = new SqlConnection(connectionString);
            SqlDependency.Start(connectionString);
            SomeMethod();
        }

        void SomeMethod()
        {
            if (command != null)
                command.Dispose();

            command = new SqlCommand("SELECT Seq, Data FROM dbo.[NotiTest]", connection);
            
            command.NotificationAutoEnlist = true;
            SqlDependency dependency = new SqlDependency(command);
                
            dependency.OnChange += new OnChangeEventHandler(OnDependencyChange);

            if (command.Connection.State != ConnectionState.Open)
                command.Connection.Open();

            using (SqlDataReader reader = command.ExecuteReader())
            {
            }
            
        }

        void OnDependencyChange(object sender, SqlNotificationEventArgs e)
        {
            MessageBox.Show("신호받음!!");
            SomeMethod();
        }

        private void NotiTest2_FormClosing(object sender, FormClosingEventArgs e)
        {
            SqlDependency.Stop(connectionString);
        }

        
    }
}

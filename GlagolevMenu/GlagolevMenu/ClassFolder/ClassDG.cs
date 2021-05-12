using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GlagolevMenu.ClassFolder
{
    class ClassDG
    {
        SqlConnection sqlConnection = new
            SqlConnection(@"Data Source=K306PC11\SQLEXPRESS;
                          Initial Catalog=GlagolevMenu;
                          Integrated Security=True");
        DataGrid dataGrid;
        SqlDataAdapter dataAdapter;
        DataTable dataTable;

        public ClassDG(DataGrid dataGrid)
        {
            this.dataGrid = dataGrid;
        }
        public void LoadDB(string sqlCommand)
        {
            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(sqlCommand, sqlConnection);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGrid.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}

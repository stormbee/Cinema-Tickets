using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;

namespace CinemaTickets
{
    internal class DatabaseConnection
    {

        private static string ServerName = "server=localhost;database=cinema;user=root;password=q1w2e3r4;";
        public static MySqlDataAdapter mySqlDataAdapter { get; set; }
        private static DataTable dataTable;
        public static MySqlConnection connection = new MySqlConnection(ServerName);



        public static DataTable Select(string selectSQL)
        {
            dataTable = new DataTable("database");
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(selectSQL, connection);
                mySqlDataAdapter = new MySqlDataAdapter(command);
                mySqlDataAdapter.Fill(dataTable);

                connection.Close();
                return dataTable;
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                connection.Close();
            }
            return dataTable; // можно удалить
        }

    }
}
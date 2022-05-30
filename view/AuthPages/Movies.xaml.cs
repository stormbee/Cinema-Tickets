using CinemaTickets.Classes;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace CinemaTickets.view.AuthPages
{
    /// <summary>
    /// Логика взаимодействия для Movies.xaml
    /// </summary>
    public partial class Movies : Page
    {
        public CinemaWindow cinemaWindow;

        public Movies(CinemaWindow _cinemaWindow)
        {
            InitializeComponent();
            cinemaWindow = _cinemaWindow;
            FillComboBoxMovies();
            if(DataUsers.status)
            {
                button_add_movie.Visibility = Visibility.Hidden;
                button_load_movies.Visibility = Visibility.Hidden;
                comboBox_movies.Visibility = Visibility.Hidden;
                button_add_new_movie.Visibility = Visibility.Visible;
                button_edit_movie.Visibility = Visibility.Visible;
                button_delete_movie.Visibility = Visibility.Visible;
                dataGrid.IsReadOnly = false;

                MySqlCommand command = new MySqlCommand($"SELECT * FROM cinema.movies ", DatabaseConnection.connection);
                DatabaseConnection.mySqlDataAdapter = new MySqlDataAdapter(command);
                DatabaseConnection.connection.Open();
                MySqlCommandBuilder mySqlCommandBuilder = new MySqlCommandBuilder(DatabaseConnection.mySqlDataAdapter);
                DatabaseConnection.mySqlDataAdapter.UpdateCommand = mySqlCommandBuilder.GetUpdateCommand();
                DatabaseConnection.mySqlDataAdapter.InsertCommand = mySqlCommandBuilder.GetInsertCommand();
                DatabaseConnection.mySqlDataAdapter.DeleteCommand = mySqlCommandBuilder.GetDeleteCommand();
                DatabaseConnection.mySqlDataAdapter.Fill(DataUsers.dt_movies);
                DatabaseConnection.connection.Close();
                dataGrid.ItemsSource = DataUsers.dt_movies.DefaultView;
            }
            LoadAllMoviesFunction();
        }

        private void LoadAllMoviesFunction()
        {
            if(!DataUsers.status)
            {
                DataUsers.dt_movies = DatabaseConnection.Select($"SELECT cinemaname,name,date,time,duration FROM cinema.movies ");
                if(DataUsers.dt_movies.Rows.Count > 0)
                {
                    dataGrid.ItemsSource = DataUsers.dt_movies.DefaultView;
                }
            }
        }

        private void FillComboBoxMovies()
        {
            DataUsers.dt_movies = DatabaseConnection.Select($"SELECT DISTINCT cinemaname FROM cinema.movies ");
            if(DataUsers.dt_movies.Rows.Count > 0)
            {
                comboBox_movies.ItemsSource = DataUsers.dt_movies.DefaultView;
                comboBox_movies.DisplayMemberPath = "cinemaname";
                comboBox_movies.SelectedValuePath = "cinemaname";
            }
            else
                MessageBox.Show($"Movie not found");
        }

        private void button_load_movies_Click(object sender, RoutedEventArgs e)
        {
            LoadAllMoviesFunction();
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(!DataUsers.status)
            {
                if(dataGrid.SelectedItem != null)
                {
                    label_choised_movie.Content = "";
                    DataRowView row = (DataRowView)dataGrid.SelectedItem;
                    string a = "";
                    foreach(var item in row.Row.ItemArray)
                    {
                        a += item + "\n";
                    }
                    for(int i = 1; i < 4; i++)
                        label_choised_movie.Content += $"{row.Row.ItemArray[i],-20}\n";
                    SeatsHolder.Seat = label_choised_movie.Content.ToString().Split("\n")[0].Trim();
                }
            }
        }

        private void comboBox_movies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(!DataUsers.status)
            {
                DataUsers.dt_movies = DatabaseConnection.Select($"SELECT cinemaname,name,date,time,duration FROM cinema.movies WHERE  cinemaname = '{((DataRowView)e.AddedItems[0]).Row.ItemArray[0]}'");
                if(DataUsers.dt_movies.Rows.Count > 0)
                {
                    dataGrid.ItemsSource = DataUsers.dt_movies.DefaultView;
                }
            }
        }

        private void dataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if(!DataUsers.status)
            {
                for(int i = 0; i < dataGrid.Columns.Count; i++)
                {
                    if(i == 0 || i == 4)
                        dataGrid.Columns[i].Width = 150;
                    else if(i == 1)
                        dataGrid.Columns[i].Width = 250;
                    else if(i == 2 || i == 3)
                        dataGrid.Columns[i].Width = 75;
                }
            }
        }

        private void button_add_movie_Click(object sender, RoutedEventArgs e)
        {
            if(label_choised_movie.Content.ToString().Length != 0)
                cinemaWindow.OpenPageStart(CinemaWindow.CinemaPages.seats);
            else
                MessageBox.Show("Choose movie");
        }

        private void button_add_movie_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if(!DataUsers.status)
            {
                if(label_choised_movie.Content.ToString().Length != 0)
                    cinemaWindow.OpenPageStart(CinemaWindow.CinemaPages.seats);
                else
                    MessageBox.Show("Choose movie");
            }
        }

        private void button_edit_movie_Click(object sender, RoutedEventArgs e)
        {
            DatabaseConnection.mySqlDataAdapter.Update(DataUsers.dt_movies);
        }
    }
}
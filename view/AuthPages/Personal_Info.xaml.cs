using CinemaTickets.Classes;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace CinemaTickets.view.AuthPages
{
    /// <summary>
    /// Логика взаимодействия для Personal_Info.xaml
    /// </summary>
    public partial class Personal_Info : Page
    {
        public CinemaWindow cinemaWindow;
        public Personal_Info(CinemaWindow _cinemaWindow)
        {
            InitializeComponent();
            cinemaWindow = _cinemaWindow;
            DataTable dt_view_info = DatabaseConnection.Select("SELECT orders.movie,orders.seats,orders.payment, movies.date,movies.time,movies.duration FROM cinema.orders" +
                                                               $" JOIN cinema.movies ON cinema.movies.name = cinema.orders.movie" +
                                                               $" WHERE login = '{DataUsers.dt_user.Rows[0]["login"]}';");
            if(dt_view_info.Rows.Count > 0)
                ordersGrid.ItemsSource = dt_view_info.DefaultView;
            else
                ordersGrid.Visibility = Visibility.Hidden;
        }

        private void ordersGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            for(int i = 0; i < ordersGrid.Columns.Count; i++)
            {
                if(i == 0)
                    ordersGrid.Columns[i].Width = 250;
                else if(i == 1)
                    ordersGrid.Columns[i].Width = 120;
                else if(i == 2)
                    ordersGrid.Columns[i].Width = 60;
            }
        }
    }
}

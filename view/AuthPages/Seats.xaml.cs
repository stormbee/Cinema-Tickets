using CinemaTickets.Classes;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace CinemaTickets.view.AuthPages
{
    /// <summary>
    /// Логика взаимодействия для Seats.xaml
    /// </summary>
    public partial class Seats : Page
    {
        /// TODO: Поменять запрос UPDATE
        ///       Разобраться с обновлением Datausers
        ///       Вывести в класс dt_user
        ///       После брони билетов выключить кнопку.хз как сделать
        ///       Весь фильм не вмещается в верхний лэйбл

        public CinemaWindow cinemaWindow;
        //public static int sumToPayment { get; set; }
        public bool IsChecked { get; set; }
        List<List<object>> movie_seats_names = new List<List<object>>();
        //private int whole_price = 0;
        public Seats(CinemaWindow _cinemaWindow)
        {
            InitializeComponent();
            cinemaWindow = _cinemaWindow;
            label_seats_prices.Content = string.Empty;
            SeatsHolder.movie_seats_name_label.Clear();
            SeatsHolder.sumToPayment.Clear();
            if(SeatsHolder.Seat != null)
                textBlock_movie_name.Text = SeatsHolder.Seat;
            DataUsers.dt_seats = DatabaseConnection.Select($"SELECT seats FROM cinema.orders WHERE movie = '{textBlock_movie_name.Text}'");

            for(int i = 0; i < 13; i++)
            {
                movie_seats_names.Add(new List<object>());

                for(int j = 0; j < 14; j++)
                {
                    if((i > 1 && j > 1) && (j < 12))
                    {
                        if((i > 2 && j > 3) && (i < 11 && j < 10))
                            movie_seats_names[i].Add(new { NumberOfSeat = $"{(char)(i + 65)}{j + 1} 100$", IsAvailable = IsAvailable_Seats(i, j), Color = new SolidColorBrush(Color.FromRgb(71, 207, 8)) });
                        else
                            movie_seats_names[i].Add(new { NumberOfSeat = $"{(char)(i + 65)}{j + 1} 70$", IsAvailable = IsAvailable_Seats(i, j), Color = new SolidColorBrush(Color.FromRgb(255, 0, 0)) });
                    }

                    else
                        movie_seats_names[i].Add(new { NumberOfSeat = $"{(char)(i + 65)}{j + 1} 30$", IsAvailable = IsAvailable_Seats(i, j), Color = new SolidColorBrush(Color.FromRgb(0, 0, 255)) });
                }
            }
            movie_seats.ItemsSource = movie_seats_names;
        }

        private bool IsAvailable_Seats(int i, int j)
        {
            IsChecked = true;
            if(DataUsers.dt_seats.Rows.Count > 0)
            {
                foreach(DataRow row in DataUsers.dt_seats.Rows)
                {
                    if(IsChecked)
                    {
                        foreach(var cell in row.ItemArray)
                        {
                            if(IsChecked)
                            {
                                string[] ArrayOfSeats = cell.ToString().Split();
                                for(int k = 0; k < ArrayOfSeats.Length; k++)
                                {
                                    if(ArrayOfSeats[k] == $"{(char)(i + 65)}{j + 1}")
                                    {
                                        IsChecked = false;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return IsChecked;
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {

            string price = (sender as ToggleButton).Content.ToString();
            int whole_price = int.Parse(price.Split()[1].Trim('$'));
            if(!(bool)(sender as ToggleButton).IsChecked)
            {
                (sender as ToggleButton).Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
                SeatsHolder.sumToPayment.Remove(whole_price);
                if(SeatsHolder.sumToPayment.Count <= 0)
                {
                    label_seats_prices.Content = "";
                    SeatsHolder.movie_seats_name_label.Remove(price.Split()[0]);
                    label_seats_names.Content = string.Join(" ", SeatsHolder.movie_seats_name_label);
                }
                else
                {
                    label_seats_prices.Content = SeatsHolder.sumToPayment.Sum() + "$";
                    SeatsHolder.movie_seats_name_label.Remove(price.Split()[0]);
                    label_seats_names.Content = string.Join(" ", SeatsHolder.movie_seats_name_label);
                }

            }
            else if((bool)(sender as ToggleButton).IsChecked)
            {
                SeatsHolder.sumToPayment.Add(whole_price);
                SeatsHolder.movie_seats_name_label.Add(price.Split()[0]);
                label_seats_prices.Content = SeatsHolder.sumToPayment.Sum() + "$";
                label_seats_names.Content = string.Join(" ", SeatsHolder.movie_seats_name_label);
            }
        }

        private void button_add_seats_Click(object sender, RoutedEventArgs e)
        {

            if(label_seats_names.Content.ToString().Length == 0)
                MessageBox.Show("Choose Seats");
            else
            {
                DataUsers.dt_orders = DatabaseConnection.Select($"SELECT * FROM cinema.orders WHERE login = '{DataUsers.dt_user.Rows[0]["login"]}' AND movie = '{textBlock_movie_name.Text}'");
                if(DataUsers.dt_orders.Rows.Count > 0)
                {
                    DatabaseConnection.Select($"UPDATE cinema.orders SET " +
                       $" seats = '{DataUsers.dt_orders.Rows[0][3] + " " + label_seats_names.Content}'," +
                       $" payment = '{int.Parse(DataUsers.dt_orders.Rows[0][4].ToString()) + SeatsHolder.sumToPayment.Sum()}'" +
                       $" WHERE movie = '{textBlock_movie_name.Text}' AND login = '{DataUsers.dt_user.Rows[0]["login"]}';");
                }
                else
                {
                    DatabaseConnection.Select($"INSERT INTO cinema.orders (login,  movie, seats, payment) VALUES " +
                        $"('{DataUsers.dt_user.Rows[0][1]}'," +
                        $" '{textBlock_movie_name.Text}'," +
                        $" '{label_seats_names.Content}'," +
                        $" '{SeatsHolder.sumToPayment.Sum()}');");
                }
                label_seats_names.Content = string.Empty;
                label_seats_prices.Content = string.Empty;
                SeatsHolder.movie_seats_name_label.Clear();
                cinemaWindow.OpenPageStart(CinemaWindow.CinemaPages.seats);
            }
        }

        private void button_toPay(object sender, RoutedEventArgs e)
        {
            cinemaWindow.OpenPageStart(CinemaWindow.CinemaPages.personal_info);
        }
    }
}
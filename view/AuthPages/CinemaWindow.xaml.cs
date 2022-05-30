using System.Windows;

namespace CinemaTickets.view.AuthPages
{
    /// <summary>
    /// Логика взаимодействия для CinemaWindow.xaml
    /// </summary>
    public partial class CinemaWindow : Window
    {
        public CinemaWindow cinemaWindow;
        public MainWindow mainWindow;

        public CinemaWindow()
        {
            InitializeComponent();
            MainAuth.Content = new Movies(this);
        }
        public CinemaWindow(MainWindow _mainWindow)
        {
            mainWindow = _mainWindow;
            InitializeComponent();
            MainAuth.Content = new Movies(this);
        }
        public enum CinemaPages
        {
            movies,
            seats,
            personal_info,
            setting
        }


        public void OpenPageStart(CinemaPages pages)
        {
            if(pages == CinemaPages.movies)
                MainAuth.Navigate(new Movies(this));
            else if(pages == CinemaPages.seats)
            {
                choose_seats.IsEnabled = true;
                MainAuth.Navigate(new Seats(this));
            }
            else if(pages == CinemaPages.personal_info)
                MainAuth.Navigate(new Personal_Info(this));
            else if(pages == CinemaPages.setting)
                MainAuth.Navigate(new Settings(this));

        }


        private void Log_Out(object sender, RoutedEventArgs e)
        {
            mainWindow.Visibility = Visibility.Visible;
            Close();
        }


        private void Button_Click_Movies_Page(object sender, RoutedEventArgs e)
        {
            MainAuth.Content = new Movies(this);
        }

        private void Button_Click_Seats_Page(object sender, RoutedEventArgs e)
        {
            MainAuth.Content = new Seats(this);
        }

        private void Button_Click_Personal_Info_Page(object sender, RoutedEventArgs e)
        {
            MainAuth.Content = new Personal_Info(this);
        }

        private void Button_Click_Settings_Page(object sender, RoutedEventArgs e)
        {
            MainAuth.Content = new Settings(this);
        }
        //private void okButton_Click(object sender, RoutedEventArgs e) => Application.Current.Shutdown();

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
            if (mainWindow.Visibility != Visibility.Visible)
            {
                Application.Current.Shutdown();
            }
        }
    }
}

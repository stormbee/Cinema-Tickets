using System.Data;

namespace CinemaTickets.Classes
{
    internal class DataUsers
    {
        public static DataTable dt_user { get; set; }
        public static DataTable dt_movies { get; set; }
        public static DataTable dt_orders { get; set; } // можно удалить и поменять по ссылкам
        public static DataTable dt_seats { get; set; } // можно удалить и поменять по ссылкам
        public static bool status { get; set; }


       


    }
}

using System.Collections.Generic;

namespace CinemaTickets.Classes
{
    class SeatsHolder
    {
        private static string seat;
        public static string Seat { get => seat; set => seat = value; }


        public static List<string> movie_seats_name_label = new List<string>();
        public static List<int> sumToPayment = new List<int>();
    }
}

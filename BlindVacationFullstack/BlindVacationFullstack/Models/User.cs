using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlindVacationFullstack.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Color FaveColor { get; set; }
        public enum Color
        {
            Yellow = 1,
            Red,
            Purple,
            Cyan,
            Black,
            Brown,
            Green,
            Turquoise,
            Orange,
            Pink,
            White,
            Ivory,
            Blue,
            Velvet,
            Gold,
            Platinum
        }

        //Nav Properties

        public ICollection<SavedTrip> SavedTrips { get; set; }

    }
}

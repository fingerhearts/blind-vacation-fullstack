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
        public TripItem FaveTripItem
        { get; set; }
        public enum TripItem
        {
            Toothpaste = 1,
            Underwear,
            Volleyball,
            Sunscreen,
            FlipFlops,
            Sunglasses,
            Snowboard,
            Money,
            Camera,
            Charger,
            Headphones,
            Passport,
            Hat,
            Swimsuit,
            Games,
            Snacks
        }

        //Nav Properties

        public ICollection<SavedTrip> SavedTrips { get; set; }

    }
}

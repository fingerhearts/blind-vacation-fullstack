using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlindVacationFullstack.Models
{
    public class Trip
    {
        public int UserID { get; set; }
        public int RecommendationCode { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

        public User User { get; set; }

    }
}

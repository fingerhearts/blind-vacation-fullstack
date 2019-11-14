using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlindVacationFullstack.Models
{
    public class SavedTrip
    {
        public int UserID { get; set; }
        public string CityName { get; set; }
        public string VacationName { get; set; }
        public string AnswerCode { get; set; }
        public bool InUSA { get; set; }
        public bool LikesHot { get; set; }
        public int Price { get; set; }
        public bool HasChildren { get; set; }
        public bool LikesOutdoor { get; set; }

        public User User { get; set; }
    }
}

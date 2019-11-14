using BlindVacationFullstack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlindVacationFullstack.Models.ViewModels
{
    public class EditTripViewModel
    {
        public User User { get; set; }
        public SavedTrip SavedTrip { get; set; }
        public string AnswerCode { get; set; }
        public City City { get; set; }
        public Hotel Hotel {get; set;}
        public Activity Activity { get; set;}
        public string CityName { get; set; }
        public string VacationName { get; set; }
        public int UserID { get; set; }
        
    }
}

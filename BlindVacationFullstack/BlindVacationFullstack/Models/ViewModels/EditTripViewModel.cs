using BlindVacationFullstack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlindVacationFullstack.Views.ViewModels
{
    public class EditTripViewModel
    {
        public string AnswerCode { get; set; }
        public City City { get; set; }
        public IEnumerable<Hotel> Hotels {get; set;}
        public IEnumerable<Activity> Activities {get; set;}
        public string RecommendationCode { get; set; }
        
    }
}

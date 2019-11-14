using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlindVacationFullstack.Models
{
    public class PopularTrip
    {
        public int ID { get; set; }
        public string CityName { get; set; }
        public string VacationName { get; set; }
        public string AnswerCode { get; set; }
        public int Popularity { get; set; } = 0;
    }
}

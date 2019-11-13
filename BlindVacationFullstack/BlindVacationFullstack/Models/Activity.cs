using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlindVacationFullstack.Models
{
    public class Activity
    {
        int ID { get; set; }
        public string Name { get; set; }
        public bool FamilyFriendly { get; set; }
        public bool IsOutdoor { get; set; }
    }
}

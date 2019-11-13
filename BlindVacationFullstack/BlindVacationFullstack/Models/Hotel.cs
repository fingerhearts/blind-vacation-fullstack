using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlindVacationFullstack.Models
{
    public class Hotel
    {
        int ID { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public int Price { get; set; }
    }
}

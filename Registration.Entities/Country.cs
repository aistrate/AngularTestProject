using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Entities
{
    public class Country
    {
        public Country()
        {
            Provinces = new List<Province>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Province> Provinces { get; set; }
    }
}

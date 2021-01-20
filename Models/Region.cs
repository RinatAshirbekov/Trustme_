using System;
using System.Collections.Generic;
using System.Text;

namespace Trustme_.Models
{
    public partial class Region
    {
        public Region()
        {
            Cities = new List<City>();
            Companies = new List<Company>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<City> Cities { get; set; }
        public ICollection<Company> Companies { get; set; }
    }
}

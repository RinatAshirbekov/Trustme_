using System;
using System.Collections.Generic;
using System.Text;

namespace Trustme_.Models
{
    public partial class City
    {
        public City()
        {
            Companies = new List<Company>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int RegionId { get; set; }
        public Region Region { get; set; }
        public ICollection<Company> Companies { get; set; }
    }
}

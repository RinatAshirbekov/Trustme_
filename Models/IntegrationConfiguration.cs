using System;
using System.Collections.Generic;

#nullable disable

namespace Trustme_.Models
{
    public partial class IntegrationConfiguration
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ApiUrl { get; set; }
        public bool IsEnabled { get; set; }
        public string NameService { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace Trustme_.Models
{
    public partial class IntegrationLog
    {
        public Guid Id { get; set; }
        public string ServiceName { get; set; }
        public string Parametres { get; set; }
        public string Values { get; set; }
        public string ResponseBody { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

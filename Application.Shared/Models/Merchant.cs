using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Shared.Models
{
    public class Merchant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TenantId { get; set; }
    }
}

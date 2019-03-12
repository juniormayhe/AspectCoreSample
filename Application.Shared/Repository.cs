using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Shared.Models;
using AspectCore.DynamicProxy;

namespace Application.Shared
{
    public class Repository : IRepository
    {
        public IEnumerable<Merchant> GetMerchants(int tenantId)
        {
            return getAllMerchantsByTenant(tenantId);
        }

        private static IEnumerable<Merchant> getAllMerchantsByTenant(int tenantId)
        {
            // simulate database
            var list = new List<Merchant> {
                new Merchant { Id=1, Name="AMI", TenantId = 10000 },
                new Merchant { Id=2, Name="Browns", TenantId = 12000},
                new Merchant { Id=3, Name="Harrods", TenantId = 10000},
                new Merchant { Id=4, Name="Stefania", TenantId = 12000 }
            };
            return list.Where(x => x.TenantId == tenantId).ToList();
        }
    }
}

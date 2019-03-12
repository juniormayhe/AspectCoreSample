using System.Collections.Generic;
using Application.Shared.Models;

namespace Application.Shared
{
    public interface IRepository
    {
        [TenantInterceptor]
        IEnumerable<Merchant> GetMerchants(int tenantId);
    }
}
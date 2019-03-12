using Application.Shared.Models;
using AspectCore.DynamicProxy;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Application.Shared
{
    public class TenantInterceptor : AbstractInterceptorAttribute
    {
        public async override Task Invoke(AspectContext context, AspectDelegate next)
        {
            // before service call
            int originalTenantId = Convert.ToInt32(context.Parameters[0]);
            int targetTenantId = originalTenantId;

            if (originalTenantId == 51000) { 
                targetTenantId = 10000;
                System.Diagnostics.Trace.WriteLine($"----\ntranslating {context.Parameters[0]} to {targetTenantId}...");
                context.Parameters[0] = targetTenantId;
            }

            // process
            System.Diagnostics.Trace.WriteLine($"processing with {targetTenantId}...");
            await next(context);//return context.Invoke(next);

            // after service call
            System.Diagnostics.Trace.WriteLine("context processed!");

            // if you need to get results and do something
            List<Merchant> merchants = context.ReturnValue as List<Merchant> ?? new List<Merchant>();
            System.Diagnostics.Trace.WriteLine($"Merchants result: {string.Join(", ", merchants.Select(x => x.Name))}\n----");
        }
    }
}

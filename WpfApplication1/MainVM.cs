using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1;
using WpfApplication1.ClientContext;
using WpfApplication1.ClientContext.Interfaces;
using WpfApplication1.ClientContext.Interfaces.Errors;
using WCFAsyncQueryableServices.ClientContext;
using WCFAsyncQueryableServices.ClientContext.Interfaces;
using WCFAsyncQueryableServices.ClientContext.Interfaces.Errors;
using WCFAsyncQueryableServices.ClientContext.Interfaces.Querying;
using WCFAsyncQueryableServices.ComponentModel;

namespace WpfApplication1
{
    public class MainVM : ViewModelBase
    {
        private IWAQSModelClientContext _context;
        public MainVM(IWAQSModelClientContext context): base (context)
        {
            _context = context;
            //FooAsync().ConfigureAwait(true);
            FooAsync().ConfigureAwait(true);
        }

        private async Task FooAsync()
        {
            var test = await _context.Entity1.AsAsyncQueryable().Where(e => e.NameLength > 5).ExecuteAsync();
            test.First().Name += "!";
            await _context.SaveChangesAsync();
        }
    }
}
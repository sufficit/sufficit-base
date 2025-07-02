using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Finance
{
    public interface IElectronicInvoiceController
    {        
        /// <summary>
        ///     Get item by id, with files
        /// </summary>
        Task<ElectronicInvoice?> ById (Guid id, CancellationToken cancellationToken);

        Task<IEnumerable<ElectronicInvoice>> Search(ElectronicInvoiceSearchParameters parameters, CancellationToken cancellationToken);

        /// <summary>
        ///     Add or update an item. If already exists, it will be updated.   
        /// </summary>
        Task<ElectronicInvoice> AddOrUpdate(ElectronicInvoice item, CancellationToken cancellationToken);

        /// <summary>
        ///     Remove an item by id, if exists
        /// </summary>
        Task<int> Remove(Guid id, CancellationToken cancellationToken);
    }
}

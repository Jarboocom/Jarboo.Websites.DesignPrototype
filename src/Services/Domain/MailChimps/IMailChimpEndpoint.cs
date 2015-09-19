using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain.MailChimps
{
    public interface IMailChimpEndpoint<T, in TK> 
        where T : BaseMailChimpResource
        where TK : BaseMailChimpRequest
    {
        /// <summary>
        /// Create a new resource
        /// </summary>
        /// <param name="resource">A resource to be created</param>
        /// <returns>Created resource</returns>
        BaseMailChimpResponse<T> Post(TK request);
        /// <summary>
        /// Create a new resource asynchronously
        /// </summary>
        /// <param name="resource">A resource to be created</param>
        /// <returns>Created resource</returns>
        Task<BaseMailChimpResponse<T>> PostAsync(TK request);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;

namespace VDSoLienLac.Models.Base
{
    public class CustomNegotiatedContentResult<T> : OkNegotiatedContentResult<T>
    {
        public CustomNegotiatedContentResult(T content, ApiController controller)
        : base(content, controller) { }

        public CustomNegotiatedContentResult(T content, IContentNegotiator contentNegotiator, HttpRequestMessage request, IEnumerable<MediaTypeFormatter> formatters)
            : base(content, contentNegotiator, request, formatters) { }

        public string ETagValue { get; set; }

        public override async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpResponseMessage response = await base.ExecuteAsync(cancellationToken);

            response.Headers.ETag = new EntityTagHeaderValue(this.ETagValue);

            return response;
        }
    }
}
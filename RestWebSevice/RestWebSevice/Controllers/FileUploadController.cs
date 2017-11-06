using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using RestWebSevice.Extensions;

namespace RestWebSevice.Controllers
{

    [RoutePrefix("api")]
    public class FileUploadController : ApiController
    {
        [Route("upload")]
        [HttpPost]
        public async Task<HttpResponseMessage> UploadFile(HttpRequestMessage request)
        {
            if (!request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            var data = await Request.Content.ParseMultipartAsync();

            if (data.Files.ContainsKey("file"))
            {
                var file = data.Files["file"].File;
                var fileName = data.Files["file"].Filename;
            }

            if (data.Fields.ContainsKey("description"))
            {
                var description = data.Fields["description"].Value;
            }

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("Thank you for uploading the file...")
            };
        }
    }
}

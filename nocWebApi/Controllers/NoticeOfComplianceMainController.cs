using nocWebApi.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace nocWebApi.Controllers
{
    public class NoticeOfComplianceMainController : ApiController
    {
        static readonly INoticeOfComplianceMainRepository databasePlaceholder = new NoticeOfComplianceMainRepository();

        public IEnumerable<NoticeOfComplianceMain> GetAllNoticeOfComplianceMain(string lang="")
        {

            return databasePlaceholder.GetAll(lang);
        }


        public NoticeOfComplianceMain GetNoticeOfComplianceMainById(int id, string lang="")
        {
            NoticeOfComplianceMain route = databasePlaceholder.Get(id, lang);
            //if (route == null)
            //{
            //    throw new HttpResponseException(HttpStatusCode.NotFound);
            //}
            return route;
        }
    }
}

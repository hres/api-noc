using System.Collections.Generic;

namespace nocWebApi.Models
{
    interface INoticeOfComplianceMainRepository
    {
        IEnumerable<NoticeOfComplianceMain> GetAll(string lang);
        NoticeOfComplianceMain Get(int id, string lang);
    }
}

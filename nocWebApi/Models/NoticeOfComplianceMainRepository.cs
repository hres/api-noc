using notice;
using System.Collections.Generic;

namespace nocWebApi.Models
{
    public class NoticeOfComplianceMainRepository : INoticeOfComplianceMainRepository
    {
       
        private List<NoticeOfComplianceMain> nocs = new List<NoticeOfComplianceMain>();
        private NoticeOfComplianceMain noc = new NoticeOfComplianceMain();
        

    public IEnumerable<NoticeOfComplianceMain> GetAll(string lang)
    {
            DBConnection dbConnection = new DBConnection(lang);
            nocs = dbConnection.GetAllNoticeOfComplianceMain();

        return nocs;
    }


    public NoticeOfComplianceMain Get(int id, string lang)
    {
            DBConnection dbConnection = new DBConnection(lang);
            noc = dbConnection.GetNoticeOfComplianceMainById(id);
        return noc;
    }


    }
}
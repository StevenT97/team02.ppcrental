using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Models.FrameWork;
using PagedList;
using System.IO;
using System.Web;
using System.Data.Common;
using System.Configuration;
using TEDU_MVC.Areas.Admin.Code;

namespace TEDU_MVC.Areas.Admin.Models
{
    
    public class SolveModels
    {
        DemoPPCRentalEntities db = new DemoPPCRentalEntities();
        public IEnumerable<PROPERTy> ListAllPagingAgency(int page, int pageSize)
        {
            var session = (UserSession)HttpContext.Current.Session[TEDU_MVC.Code.CommonConstant.USER_SESSION];
            int idd = (int)session.UserID;
            var list = db.PROPERTies.Where(x => x.UserID == idd).ToPagedList(page,pageSize);
            return list;
        }

    }
}
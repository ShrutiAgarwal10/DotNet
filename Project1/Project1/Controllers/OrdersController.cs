using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project1.Models;
using System.Linq.Dynamic;


namespace Project1.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        // GET: Orders
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {

            int pageNo = Convert.ToInt32(Request["page"]);
            int length = Convert.ToInt32(Request["rows"]);
            string sortColumnName = Request["sidx"];
            string sortDirection = Request["sord"];
            bool _search = Convert.ToBoolean(Request["_search"]);
            string searchColumnName = Request["searchField"];
            string searchKeyword = Request["searchString"];
            string searchOper = Request["searchOper"];


            List<ORDER> ordList = new List<ORDER>();
            using (OrdersDBEntities db = new OrdersDBEntities())
            {
                ordList = db.ORDERS.ToList();

            }

            //sorting
            if(sortColumnName!="")
            {
                ordList = ordList.OrderBy(sortColumnName + " " + sortDirection).ToList();
            }

            //searching
            if(_search)
            {
                switch(searchOper)
                {
                    case "lt":
                        ordList = ordList.Where(searchColumnName + " < " + searchKeyword).ToList();
                        break;
                    case "gt":
                        ordList = ordList.Where(searchColumnName + " > " + searchKeyword).ToList();
                        break;
                    default:
                        break;
                }
            }

            int totalPage = Convert.ToInt32(((float)ordList.Count / (float)length) + 0.5);
            int totalRecordCount = ordList.Count;

            //paging
            ordList = ordList.Skip((pageNo - 1) * length).Take(length).ToList<ORDER>();

            return Json(new {
                rows = ordList,
                page= pageNo,
                rowNum=length,
                records=totalRecordCount,
                total=totalPage
            }, JsonRequestBehavior.AllowGet);

        }

    }
}
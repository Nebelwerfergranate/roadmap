using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Roadmap.Utils;
using Roadmap.Models;
using Roadmap.Models.ViewModels;
using Roadmap.BLL;

namespace Roadmap.Controllers
{
    public class DocumentsController : ManagerControllerBase
    {
        public ActionResult Contracts()
        {
            return View();
        }

        //TODO uncomment
        //[HttpPost]
        public ActionResult Contracts_getItems()
        {
            // fake
            PagingDefinition paging = new PagingDefinition();
            paging.Page = 1;
            paging.PageSize = 10;
            paging.Sort = "Date";
            paging.Direction = SortDirections.down;

            DocumentsManager mng = new DocumentsManager(Db);
            ItemsResult<Contract> res = mng.GetContracts(paging);

            return Json(new
            {
                items = res.Items,
                result = res.IsSuccess,
                message = res.Message,
                total = res.Total,
                page = res.Page,
                itemsPerGape = res.ItemsPerPage
            }, JsonRequestBehavior.AllowGet);            
        }
    }
}
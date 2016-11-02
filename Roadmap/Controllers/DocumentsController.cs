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
        #region Index
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index_getItems()
        {
            // fake
            PagingDefinition paging = new PagingDefinition();
            paging.PageSize = 5;

            ItemsResult<Document> res = DocumentsManager.GetDocuments(paging);

            return Json(new
            {
                items = res.Items,
                result = res.IsSuccess,
                message = res.Message,
                total = res.Total,
                page = res.Page,
                PageSize = res.PageSize
            });
        }
        #endregion

        #region Contracts
            public ActionResult Contracts()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contracts_getItems()
        {
            // fake
            PagingDefinition paging = new PagingDefinition();
            paging.Page = 1;
            paging.PageSize = 10;
            paging.Sort = "Date";
            paging.Direction = SortDirections.down;

            ItemsResult<Contract> res = DocumentsManager.GetContracts(paging);

            return Json(new
            {
                items = res.Items,
                result = res.IsSuccess,
                message = res.Message,
                total = res.Total,
                page = res.Page,
                PageSize = res.PageSize
            });
        }

        #endregion

        #region Acts
        public ActionResult Acts()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Acts_getItems()
        {
            // fake
            PagingDefinition paging = new PagingDefinition();

            ItemsResult<Act> res = DocumentsManager.GetActs(paging);

            return Json(new
            {
                items = res.Items,
                result = res.IsSuccess,
                message = res.Message,
                total = res.Total,
                page = res.Page,
                PageSize = res.PageSize
            });
        }
        #endregion

        #region Agreements
        public ActionResult Agreements()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agreements_getItems()
        {
            // fake
            PagingDefinition paging = new PagingDefinition();

            ItemsResult<Agreement> res = DocumentsManager.GetAgreements(paging);

            return Json(new
            {
                items = res.Items,
                result = res.IsSuccess,
                message = res.Message,
                total = res.Total,
                page = res.Page,
                PageSize = res.PageSize
            });
        }
        #endregion
    }
}
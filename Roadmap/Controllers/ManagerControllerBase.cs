using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Roadmap.DAL.Core;
using Roadmap.BLL;

namespace Roadmap.Controllers
{
    public abstract class ManagerControllerBase : Controller
    {
        private UnitOfWork database;
        private DocumentsManager documentsManager;

        protected UnitOfWork Db
        {
            get
            {
                if (database == null)
                {
                    database = new UnitOfWork();
                }

                return database;
            }
        }        

        protected DocumentsManager DocumentsManager
        {
            get
            {
                if (documentsManager == null)
                {
                    documentsManager = new DocumentsManager(Db);
                }

                return documentsManager;
            }
        }

        protected override void Dispose(bool disposing)
        {
            database.Dispose();
            base.Dispose(disposing);
        }
    }
}
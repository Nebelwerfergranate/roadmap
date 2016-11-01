using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Roadmap.DAL.Core;

namespace Roadmap.Controllers
{
    public abstract class ManagerControllerBase : Controller
    {
        private UnitOfWork db;

        protected UnitOfWork Db
        {
            get
            {
                if (db == null)
                {
                    db = new UnitOfWork();
                }

                return db;
            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
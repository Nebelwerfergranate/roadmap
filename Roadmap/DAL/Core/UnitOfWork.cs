using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Roadmap.DAL;

namespace Roadmap.DAL.Core
{
    public class UnitOfWork : IDisposable
    {
        private RoadmapContext db;
        private RoadmapRepository roadmapRepository;
        private bool disposed = false;

        public UnitOfWork()
        {
            db = new RoadmapContext();
        }

        public RoadmapRepository RoadmapRepository
        {
            get
            {
                if (roadmapRepository == null)
                {
                    roadmapRepository = new RoadmapRepository(db);
                }                    

                return roadmapRepository;
            }
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Save()
        {
            try
            {
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                LogError(ex);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void LogError(Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);

            if (ex.InnerException != null)
            {
                LogError(ex.InnerException);
            }
        }
    }
}
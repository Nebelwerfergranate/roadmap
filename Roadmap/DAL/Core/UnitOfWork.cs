using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Roadmap.DAL;
using Roadmap.Utils;

namespace Roadmap.DAL.Core
{
    public class UnitOfWork : IDisposable
    {
        private RoadmapContext db;
        private RoadmapRepository roadmapRepository;
        private DocumentsRepository documentsRepository;
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

        public DocumentsRepository DocumentsRepository
        {
            get
            {
                if (documentsRepository == null)
                {
                    documentsRepository = new DocumentsRepository(db);
                }

                return documentsRepository;
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
                Debug.LogError(ex);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }        
    }
}
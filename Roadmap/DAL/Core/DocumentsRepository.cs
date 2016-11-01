using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Linq.Expressions;
using Roadmap.Models;
using Roadmap.Utils;

namespace Roadmap.DAL.Core
{
    public class DocumentsRepository
    {
        protected RoadmapContext context;

        public DocumentsRepository(RoadmapContext context)
        {
            this.context = context;
        }

        public ItemsResult<rdm_documentTypes> GetDocumentTypes()
        {
            ItemsResult<rdm_documentTypes> res = new ItemsResult<rdm_documentTypes>();

            try
            {
                // TODO cache
                res.Items = context.rdm_documentTypes.ToList();
                res.IsSuccess = true;
            }
            catch (Exception ex)
            {
                Debug.LogError(ex);
                res.IsSuccess = false;
            }

            return res;
        }

        public int GetDocumentTypeIdByCode(string code)
        {
            rdm_documentTypes documentType = GetDocumentTypes().Items.Where(x => x.code == code).FirstOrDefault();

            if (documentType == null)
            {
                throw new NotImplementedException(String.Format("Can't find document type '{0}'", code));
            }

            return documentType.id;
        }
    }
}
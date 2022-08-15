using BLL.Abstract;
using BLL.Results;
using Blog.Entities;
using Blog.Entities.Messages;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class FirmaManager : ManagerBase<Firma>
    {
        public override int Delete(Firma firma)
        {
            PostManager postManager = new PostManager();

            // Kategori ile ilişkili notların silinmesi gerekiyor.
            foreach (Post post in firma.Posts.ToList())
            {
                postManager.Delete(post);
            }

            return base.Delete(firma);
        }

        public BusinessLayerResult<Firma> InsertFirmaFoto(Firma firma)
        {
            BusinessLayerResult<Firma> res = new BusinessLayerResult<Firma>();

            if (string.IsNullOrEmpty(firma.FirmaImage) == false)
            {
                res.Result.FirmaImage = firma.FirmaImage;
            }

            if (base.Insert(res.Result) == 0)
            {
                res.AddError(ErrorMessageCode.ProfileCouldNotUpdated, "Firma Eklenmedi.");
            }

            return res;
        }

        public BusinessLayerResult<Firma> UpdateFirmaFoto(Firma firma)
        {
            BusinessLayerResult<Firma> res = new BusinessLayerResult<Firma>();
            res.Result = Find(x => x.Id == firma.Id);

            if (string.IsNullOrEmpty(firma.FirmaImage) == false)
            {
                res.Result.FirmaImage = firma.FirmaImage;
            }

            if (base.Update(res.Result) == 0)
            {
                res.AddError(ErrorMessageCode.ProfileCouldNotUpdated, "Post Eklenmedi.");
            }

            return res;
        }
    }
}

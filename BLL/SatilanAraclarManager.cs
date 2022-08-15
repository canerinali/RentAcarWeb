using BLL.Abstract;
using BLL.Results;
using Blog.Entities.Messages;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SatilanAraclarManager : ManagerBase<SatilanAraclar>
    {
        public BusinessLayerResult<SatilanAraclar> InsertPostFoto(SatilanAraclar post)
        {
            BusinessLayerResult<SatilanAraclar> res = new BusinessLayerResult<SatilanAraclar>();

            if (string.IsNullOrEmpty(post.PostImageFilename) == false)
            {
                res.Result.PostImageFilename = post.PostImageFilename;
            }

            if (base.Insert(res.Result) == 0)
            {
                res.AddError(ErrorMessageCode.ProfileCouldNotUpdated, "Post Eklenmedi.");
            }
            return res;
        }

        public BusinessLayerResult<SatilanAraclar> UpdatePostFoto(SatilanAraclar post)
        {
            BusinessLayerResult<SatilanAraclar> res = new BusinessLayerResult<SatilanAraclar>();
            res.Result = Find(x => x.Id == post.Id);
            res.Result.IsDraft = post.IsDraft;
            res.Result.Text = post.Text;
            res.Result.Price = post.Price;
            res.Result.Description = post.Description;
            res.Result.Title = post.Title;
            res.Result.BeygirGücü = post.BeygirGücü;
            res.Result.CekisTipi = post.CekisTipi;
            res.Result.DisRenk = post.DisRenk;
            res.Result.IcRenk = post.IcRenk;
            res.Result.Km = post.Km;
            res.Result.MotorHacmi = post.MotorHacmi;
            res.Result.YakıtTipi = post.YakıtTipi;
            res.Result.Vites = post.Vites;

            if (string.IsNullOrEmpty(post.PostImageFilename) == false)
            {
                res.Result.PostImageFilename = post.PostImageFilename;
            }
            if (string.IsNullOrEmpty(post.ExpertizImage) == false)
            {
                res.Result.ExpertizImage = post.ExpertizImage;
            }
            //if (string.IsNullOrEmpty(post.ExpertizImage) == false)
            //{
            //    res.Result.ExpertizImage = post.ExpertizImage;
            //}

            if (base.Update(res.Result) == 0)
            {
                res.AddError(ErrorMessageCode.ProfileCouldNotUpdated, "Post Eklenmedi.");
            }

            return res;
        }
    }
}

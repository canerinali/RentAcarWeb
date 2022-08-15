using BLL.Abstract;
using BLL.Results;
using Blog.Entities;
using Blog.Entities.Messages;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class PostManager : ManagerBase<Post>
    {

        public BusinessLayerResult<Post> InsertPostFoto(Post post)
        {
            BusinessLayerResult<Post> res = new BusinessLayerResult<Post>();

            if (res.Result == null)
            {
                res.AddError(ErrorMessageCode.ProfileCouldNotUpdated, "Araç Eklenmedi. Boşlukları kontrol ediniz");
                if (string.IsNullOrEmpty(post.Title) == true)
                {
                    res.AddError(ErrorMessageCode.ProfileCouldNotUpdated, "Araç Başlığı kontrol ediniz");
                }
                if (string.IsNullOrEmpty(post.YakıtTipi) == true)
                {
                    res.AddError(ErrorMessageCode.ProfileCouldNotUpdated, "Araç Yakıt Tipini kontrol ediniz");
                }
                if (string.IsNullOrEmpty(post.Vites) == true)
                {
                    res.AddError(ErrorMessageCode.ProfileCouldNotUpdated, "Araç Vites Tipini kontrol ediniz");
                }
                if (string.IsNullOrEmpty(post.Text) == true)
                {
                    res.AddError(ErrorMessageCode.ProfileCouldNotUpdated, "Araç Text kontrol ediniz");
                }
                if (string.IsNullOrEmpty(post.UserNumber) == true)
                {
                    res.AddError(ErrorMessageCode.ProfileCouldNotUpdated, "Araç KM kontrol ediniz");
                }
                if (string.IsNullOrEmpty(post.CarType) == true)
                {
                    res.AddError(ErrorMessageCode.ProfileCouldNotUpdated, "Araç Açıklama kontrol ediniz");
                }

            }

            if (string.IsNullOrEmpty(post.PostImageFilename) == false)
            {
                res.Result.PostImageFilename = post.PostImageFilename;
            }
            return res;
        }

        public BusinessLayerResult<Post> UpdatePostFoto(Post post)
        {
            BusinessLayerResult<Post> res = new BusinessLayerResult<Post>();
            res.Result = Find(x => x.Id == post.Id);
            res.Result.IsDraft = post.IsDraft;
            res.Result.CategoryId = post.CategoryId;
            res.Result.Text = post.Text;
            res.Result.DayPrice = post.DayPrice;
            res.Result.CarType = post.CarType;
            res.Result.Title = post.Title;
            res.Result.UserNumber = post.UserNumber;
            res.Result.MonthlyPrice = post.MonthlyPrice;
            res.Result.YakıtTipi = post.YakıtTipi;
            res.Result.Vites = post.Vites;
            res.Result.FirmaId = post.FirmaId;

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
        public override int Delete(Post post)
        {
            ResimManager resimManager = new ResimManager();

            // Kategori ile ilişkili notların silinmesi gerekiyor.
            foreach (Resim resim in post.Resims.ToList())
            {
                resimManager.Delete(resim);
            }

            return base.Delete(post);
        }
    }
}
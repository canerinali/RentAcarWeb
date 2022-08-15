using BLL.Abstract;
using BLL.Results;
using Blog.Entities;
using Blog.Entities.Messages;
using System.Linq;

namespace BLL
{
    public class ResimManager : ManagerBase<Resim>
    {
        //public override int Delete(Resim category)
        //{
        //    PostManager postManager = new PostManager();

        //    // Kategori ile ilişkili notların silinmesi gerekiyor.
        //    foreach (Post post in category.Posts.ToList())
        //    {
        //        postManager.Delete(post);
        //    }

        //    return base.Delete(category);
        //}
        public BusinessLayerResult<Resim> InsertPostFoto(Resim resim)
        {
            BusinessLayerResult<Resim> res = new BusinessLayerResult<Resim>();

            if (string.IsNullOrEmpty(resim.ResimUrl) == false)
            {
                res.Result.ResimUrl = resim.ResimUrl;
            }

            if (base.Insert(res.Result) == 0)
            {
                res.AddError(ErrorMessageCode.ProfileCouldNotUpdated, "Resim Eklenmedi.");
            }

            return res;
        }
        public BusinessLayerResult<Resim> UpdatePostFoto(Resim resim)
        {
            BusinessLayerResult<Resim> res = new BusinessLayerResult<Resim>();
            res.Result = Find(x => x.PostID == resim.PostID);
            res.Result.Id = resim.Id;

            if (string.IsNullOrEmpty(resim.ResimUrl) == false)
            {
                res.Result.ResimUrl = resim.ResimUrl;
            }

            if (base.Update(res.Result) == 0)
            {
                res.AddError(ErrorMessageCode.ProfileCouldNotUpdated, "Post Eklenmedi.");
            }

            return res;
        }
    }
}
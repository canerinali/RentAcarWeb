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
    public class BlogManager: ManagerBase<GaleriBlog>
    {
        public BusinessLayerResult<GaleriBlog> InsertBlogFoto(GaleriBlog blog)
        {
            BusinessLayerResult<GaleriBlog> res = new BusinessLayerResult<GaleriBlog>();

            if (string.IsNullOrEmpty(blog.BlogImageFilename) == false)
            {
                res.Result.BlogImageFilename = blog.BlogImageFilename;
            }
            if (base.Insert(res.Result) == 0)
            {
                res.AddError(ErrorMessageCode.ProfileCouldNotUpdated, "Eksik veya hatalı veri giriş sebebiyle araç eklenmedi lütfen bilgileri kontrol edip tekrar deneyiniz");
            }
         
            return res;
        }
        public BusinessLayerResult<GaleriBlog> UpdatePostFoto(GaleriBlog post)
        {
            BusinessLayerResult<GaleriBlog> res = new BusinessLayerResult<GaleriBlog>();
            res.Result = Find(x => x.Id == post.Id);
            res.Result.Text = post.Text;
            res.Result.Title = post.Title;

            if (string.IsNullOrEmpty(post.BlogImageFilename) == false)
            {
                res.Result.BlogImageFilename = post.BlogImageFilename;
            }

            if (base.Update(res.Result) == 0)
            {
                res.AddError(ErrorMessageCode.ProfileCouldNotUpdated, "Blog Eklenmedi.");
            }

            return res;
        }
    }
}

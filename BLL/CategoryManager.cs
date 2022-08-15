using BLL.Abstract;
using BLL.Results;
using Blog.Entities;
using Blog.Entities.Messages;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BLL
{
    public class CategoryManager : ManagerBase<Category>
    {
        public override int Delete(Category category)
        {
            PostManager postManager = new PostManager();

            // Kategori ile ilişkili notların silinmesi gerekiyor.
            foreach (Post post in category.Posts.ToList())
            {
                postManager.Delete(post);
            }

            return base.Delete(category);
        }

        public BusinessLayerResult<Category> InsertCategoryFoto(Category category)
        {
            BusinessLayerResult<Category> res = new BusinessLayerResult<Category>();

            if (string.IsNullOrEmpty(category.CategoryImageFilename) == false)
            {
                res.Result.CategoryImageFilename = category.CategoryImageFilename;
            }

            //if (string.IsNullOrEmpty(category.Title) == false)
            //{ 
            //    category.CategoryLink = ToSeoFriendly(category.Title, category.Title.Length);
            //}
            if (base.Insert(res.Result) == 0)
            {
                res.AddError(ErrorMessageCode.ProfileCouldNotUpdated, "Kategory Eklenmedi.");
            }

            return res;
        }

        //private string ToSeoFriendly(string title, int maxLength)
        //{
        //    var match = Regex.Match(title.ToLower(), "[\\w]+");
        //    StringBuilder result = new StringBuilder("");
        //    bool maxLengthHit = false;
        //    while (match.Success && !maxLengthHit)
        //    {
        //        if (result.Length + match.Value.Length <= maxLength)
        //        {
        //            result.Append(match.Value + "-");
        //        }
        //        else
        //        {
        //            maxLengthHit = true;
        //            // Handle a situation where there is only one word and it is greater than the max length.
        //            if (result.Length == 0) result.Append(match.Value.Substring(0, maxLength));
        //        }
        //        match = match.NextMatch();
        //    }
        //    // Remove trailing '-'
        //    if (result[result.Length - 1] == '-') result.Remove(result.Length - 1, 1);
        //    return result.ToString();
        //}

        public BusinessLayerResult<Category> UpdateCategoryFoto(Category category)
        {
            BusinessLayerResult<Category> res = new BusinessLayerResult<Category>();
            res.Result = Find(x => x.Id == category.Id);

            if (string.IsNullOrEmpty(category.CategoryImageFilename) == false)
            {
                res.Result.CategoryImageFilename = category.CategoryImageFilename;
            }

            if (base.Update(res.Result) == 0)
            {
                res.AddError(ErrorMessageCode.ProfileCouldNotUpdated, "Post Eklenmedi.");
            }

            return res;
        }
    }
}
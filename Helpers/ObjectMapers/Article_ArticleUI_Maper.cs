using Interfaces;
using Models;
using Models.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.ObjectMapers
{
    public class Article_ArticleUI_Maper : IMaper<Article, ArticleUI>
    {
        public ArticleUI Map(Article articleRepo)
        {
            if (articleRepo == null)
                return null;
            var articleUI = new ArticleUI();
            //articleUI.MaterialTypeId = articleRepo.Material.MaterialTypeId;
            articleUI.MaterialId = articleRepo.MaterialId;
            articleUI.Id = articleRepo.Id;
            articleUI.PublishDate = articleRepo.PublishDate;
            articleUI.URL = articleRepo.URL;
            return articleUI;
        }
    }
}

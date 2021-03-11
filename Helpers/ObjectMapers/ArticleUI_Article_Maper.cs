using Interfaces;
using Models;
using Models.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.ObjectMapers
{
    public class ArticleUI_Article_Maper : IMaper<ArticleUI, Article>
    {
        public Article Map(ArticleUI articleUI)
        {
            var articleRepo = new Article();
            articleRepo.MaterialId = Convert.ToInt32(articleUI.MaterialId);
            articleRepo.Id = Convert.ToInt32(articleUI.Id);
            articleRepo.URL = articleUI.URL;
            articleRepo.PublishDate = articleUI.PublishDate;
            return articleRepo;
        }
    }
}

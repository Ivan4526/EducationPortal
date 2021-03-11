using Interfaces;
using Models;
using Models.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.ObjectMapers
{
   public class ListMaterial_ListArticleUI_Maper : IMaper<List<Material>, List<ArticleUI>>
    {
        IMaper<Article, ArticleUI> articleMaper;
        public ListMaterial_ListArticleUI_Maper(IMaper<Article, ArticleUI> articleMaper)
        {
            this.articleMaper = articleMaper;
        }
        public List<ArticleUI> Map(List<Material> materials)
        {
            var articles = new List<ArticleUI>();
            foreach (var material in materials)
            {
                articles.Add(articleMaper.Map(material.Article));
            }
            return articles;
        }
    }
}

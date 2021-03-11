using Interfaces;
using Models;
using Models.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.ObjectMapers
{
    public class ListAuthorUI_ListAuthor_Maper : IMaper<List<AuthorUI>, List<Author>>
    {
        public List<Author> Map(List<AuthorUI> authorsUI)
        {
            var authors = new List<Author>();
            foreach (var authorUI in authorsUI)
            {
                authors.Add(new Author { Id = Convert.ToInt32(authorUI.Id), Name = authorUI.Name });
            }
            return authors;
        }
    }
}

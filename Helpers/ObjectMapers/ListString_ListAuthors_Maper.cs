using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.ObjectMapers
{
    public class ListString_ListAuthors_Maper : IMaper<List<string>, List<Author>>
    {
        public List<Author> Map(List<string> authorsString)
        {
            var authors = new List<Author>();
            foreach(var author in authorsString)
            {
                authors.Add(new Author { Name = author });
            }
            return authors;
        }
    }
}

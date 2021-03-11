using Interfaces;
using Models;
using Models.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.ObjectMapers
{
    public class ListMaterial_ListBookUI_Maper : IMaper<List<Material>, List<BookUI>>
    {
        IMaper<Book, BookUI> bookMaper;
        public ListMaterial_ListBookUI_Maper(IMaper<Book, BookUI> bookMaper)
        {
            this.bookMaper = bookMaper;
        }
        public List<BookUI> Map(List<Material> materials)
        {
            var books = new List<BookUI>();
            foreach (var material in materials) 
            {
                books.Add(bookMaper.Map(material.Book));
            }
            return books;
        }
    }
}

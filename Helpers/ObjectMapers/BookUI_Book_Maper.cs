using Interfaces;
using Models;
using Models.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helpers.ObjectMapers
{
    public class BookUI_Book_Maper : IMaper<BookUI, Book>
    {
        private readonly IMaper<List<AuthorUI>, List<Author>> authorsMaper;
           public BookUI_Book_Maper(IMaper<List<AuthorUI>, List<Author>> authorsMaper)
           {
            this.authorsMaper = authorsMaper;
           }
        public Book Map(BookUI bookUI)
        {
           var bookRepo = new Book();
           bookRepo.MaterialId = Convert.ToInt32(bookUI.MaterialId);
           bookRepo.Id = Convert.ToInt32(bookUI.Id);
           bookRepo.Authors = authorsMaper.Map(bookUI.Authors);
           bookRepo.Name = bookUI.Name;
           bookRepo.Pages = bookUI.Pages;
           return bookRepo;
        }
    }
}

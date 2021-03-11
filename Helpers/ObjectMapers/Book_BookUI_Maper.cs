using Interfaces;
using Models;
using Models.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.ObjectMapers
{
    public class Book_BookUI_Maper : IMaper<Book, BookUI>
    {
        public BookUI Map(Book bookRepo)
        {
            if (bookRepo == null)
                return null;
            var bookUI = new BookUI();
            if (bookRepo.Authors != null)
            {
                foreach (var authorRepo in bookRepo.Authors)
                {
                    bookUI.Authors.Add(new AuthorUI { Id = authorRepo.Id, Name = authorRepo.Name });
                }
            }
           // bookUI.MaterialTypeId = bookRepo.Material.MaterialTypeId;
            bookUI.Id = bookRepo.Id;
            bookUI.MaterialId = bookRepo.MaterialId;
            bookUI.Name = bookRepo.Name;
            bookUI.Pages = bookRepo.Pages;
            bookUI.PublishDate = bookRepo.PublishDate;
            return bookUI;
        }
    }
}

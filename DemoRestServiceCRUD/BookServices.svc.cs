using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DemoRestServiceCRUD
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BookServices" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select BookServices.svc or BookServices.svc.cs at the Solution Explorer and start debugging.
    public class BookServices : IBookServices
    {
        static IBookRepository repository = new BookRepository();
        public List<Book> GetBookList()
        {
            return repository.GetAllBooks();
        }

        public Book GetBookById(string id)
        {
            return repository.GetBookById(int.Parse(id));
        }

        public string AddBook(Book book)
        {
            Book newBook = repository.AddNewBook(book);
            return "id=" + newBook.BookId;
        }

        public string UpdateBook(Book book, string id)
        {
            var updated = repository.UpdateABook(book);
            if (updated)
                return "Book with id = " + id + " updated succesfully";
            else
                return "Unable to update book with id = " + id;
        }

        public string DeleteBook(string id)
        {
            var deleted = repository.DeleteABook(int.Parse(id));
            if (deleted)
            {
                return "book with id = " + id + " deleted succesfully";
            }
            else
            {
                return "unable to delete book with id = " + id;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoRestServiceCRUD
{
    interface IBookRepository
    {
        List<Book> GetAllBooks();
        Book GetBookById(int id);
        Book AddNewBook(Book book);
        bool DeleteABook(int id);
        bool UpdateABook(Book item);
    }

    public class BookRepository : IBookRepository
    {
        private List<Book> books = new List<Book>();
        private int counter = 1;

        public BookRepository ()
        {
            AddNewBook(new Book { Title = "C# Program", ISBN = "123" });
            AddNewBook(new Book { Title = "Java Program", ISBN = "124" });
            AddNewBook(new Book { Title = "WCF Program", ISBN = "125" });

        }

        public List<Book> GetAllBooks()
        {
            return books;
        }

        public Book GetBookById(int id)
        {
            return books.Find(b => b.BookId == id);
        }

        public Book AddNewBook(Book book)
        {

            if (book == null)
                throw new ArgumentNullException("book");
            book.BookId = counter++;
            books.Add(book);
            return book;
        }

        public bool DeleteABook(int id)
        {
            var index = books.FindIndex(b => b.BookId == id);
            if (index == -1)
                return false;
            books.Remove(books[index]);
            return true;
        }

        public bool UpdateABook(Book updatedBook)
        {
            if (updatedBook == null)
            {
                throw new ArgumentNullException("Updated Book");
            }

            var index = books.FindIndex(b => b.BookId == updatedBook.BookId);
            if (index == -1)
                return false;
            books.RemoveAt(index);
            books.Add(updatedBook);
            return true;
        }
    }
}

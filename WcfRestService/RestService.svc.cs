using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfRestService
{
    [ServiceBehavior(InstanceContextMode =InstanceContextMode.Single)]
    public class RestService : IRestService
    {
        private static List<BookEntity> books;

        public RestService()
        {
            books = new List<BookEntity>()
            {
                new BookEntity(1, "Książka 1", 2017),
                new BookEntity(2, "Książka 2", 2018),
                new BookEntity(3, "Książka 3", 2019)
            };
        }

        public List<BookEntity> getAll()
        {
            return books;
        }

        public List<BookEntity> getAllXML()
        {
            return getAll();
        }

        public BookEntity getById(string id)
        {
            long BookID = long.Parse(id);
            return books.Find(b => b.BookID == BookID);
        }

        public BookEntity getByIdXML(string id)
        {
            return getById(id);
        }

        public string update(string id, BookEntity book)
        {
            long BookID = long.Parse(id);

            if (book == null)
                throw new ArgumentNullException("Invalid argument: book");

            int bookIndex = books.FindIndex(b => b.BookID == BookID);

            if (bookIndex < 0)
                return "Could not find book with BookID=" + BookID;

            books.RemoveAt(bookIndex);
            books.Add(book);

            return "Updated book with BookID=" + BookID;
        }

        public string updateXML(string id, BookEntity book)
        {
            return update(id, book);
        }
    }
}

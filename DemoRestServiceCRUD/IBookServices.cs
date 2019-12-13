using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace DemoRestServiceCRUD
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBookServices" in both code and config file together.
    [ServiceContract]
    public interface IBookServices
    {
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "Books/")]
        List<Book> GetBookList();

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "Book/{id}")]
        Book GetBookById(string id);

        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "AddBook/")]
        string AddBook(Book book);

        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "UpdateBook/{id}")]
        string UpdateBook(Book book, string id);

        [OperationContract]
        [WebInvoke(Method = "DELETE", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "Delete/{id}")]
        string DeleteBook(string id);
    }
}

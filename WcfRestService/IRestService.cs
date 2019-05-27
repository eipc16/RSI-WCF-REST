using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfRestService
{
    [ServiceContract]
    public interface IRestService
    {
        [OperationContract]
        [WebGet(
            UriTemplate = "/books",
            ResponseFormat = WebMessageFormat.Json)]
        List<BookEntity> getAll();

        [OperationContract]
        [WebGet(
            UriTemplate = "/books/xml",
            ResponseFormat = WebMessageFormat.Xml)]
        List<BookEntity> getAllXML();

        [OperationContract]
        [WebGet(
            UriTemplate = "/books/{id}",
            ResponseFormat = WebMessageFormat.Json)]
        BookEntity getById(string id);

        [OperationContract]
        [WebGet(
            UriTemplate = "/books/{id}/xml",
            ResponseFormat = WebMessageFormat.Xml)]
        BookEntity getByIdXML(string id);

        [OperationContract]
        [WebInvoke(
            UriTemplate = "/books/{id}",
            Method = "PUT",
            ResponseFormat = WebMessageFormat.Json)]
        string update(string id, BookEntity book);

        [OperationContract]
        [WebInvoke(
        UriTemplate = "/books/{id}/xml",
        Method = "PUT",
        ResponseFormat = WebMessageFormat.Xml)]
        string updateXML(string id, BookEntity book);
    }


    [DataContract(IsReference = false)]
    public class BookEntity
    {
        [DataMember]
        public long BookID;

        [DataMember]
        public string BookTitle;

        [DataMember]
        public int PublishYear;

        public BookEntity(long BookID, string BookTitle, int PublishYear)
        {
            this.BookID = BookID;
            this.BookTitle = BookTitle;
            this.PublishYear = PublishYear;
        }
    }
}

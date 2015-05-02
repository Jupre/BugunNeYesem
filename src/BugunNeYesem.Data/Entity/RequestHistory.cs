using System;
using System.Xml;
using System.Xml.Linq;

namespace BugunNeYesem.Data.Entity
{
    public class RequestHistory : BaseEntity
    {
        public string Query { get; set; }
        public string QueryResult { get; set; }
        public XElement XmlValueWrapper
        {
            get { return XElement.Parse(QueryResult); }
            set { QueryResult = value.ToString(); }
        }

        public DateTime QueryDate { get; set; }

    }
}

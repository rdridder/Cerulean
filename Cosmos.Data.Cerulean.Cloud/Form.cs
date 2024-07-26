using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Cosmos.Data.Cerulean.Cloud
{
    public class Form
    {
        public string id { get; set; }
        public string FormId { get; set; }
        public List<FormElement> Elements { get; set; }
        public string _rid { get; set; }
        public string _self { get; set; }
        public string _etag { get; set; }
        public string _attachments { get; set; }
        public int _ts { get; set; }
    }
}

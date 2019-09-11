using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocApp.Models
{
    public class Medhistory
    {
        public string ailment { get; set; }
        public string treatment { get; set; }
        public string test { get; set; }
        public string recommendation { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public string testresult { get; set; }
        public string docname { get; set; }      
        public string hospital { get; set; }

    }
}
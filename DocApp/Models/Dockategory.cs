using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocApp.Models
{
    public class Dockategory
    {
       public List<DocRegistraton> AllDoc { get; set; }
       public List<string> AllCat { get; set; }
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DocApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserAppoint
    {
        public int id { get; set; }
        public Nullable<int> userid { get; set; }
        public string username { get; set; }
        public string docname { get; set; }
        public string dochos { get; set; }
        public string docaddress { get; set; }
        public string ailment { get; set; }
        public Nullable<System.DateTime> dateofappoint { get; set; }
        public string timeofvisit { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<int> docid { get; set; }
        public string booktype { get; set; }
        public Nullable<int> approve { get; set; }
        public Nullable<System.DateTime> docdate { get; set; }
        public string doctime { get; set; }
        public Nullable<int> treatapprove { get; set; }
        public string otherfee { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AppUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Nullable<long> Mobile { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public Nullable<int> Statusid { get; set; }
        public Nullable<int> roleid { get; set; }
        public Nullable<int> addedby { get; set; }
        public Nullable<System.DateTime> Doc { get; set; }
        public string Role { get; set; }
    }
}

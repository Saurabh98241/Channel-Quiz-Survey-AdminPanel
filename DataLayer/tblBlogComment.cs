//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblBlogComment
    {
        public long BlogCommentId { get; set; }
        public Nullable<long> BlogId { get; set; }
        public Nullable<long> BlogCommentByUserId { get; set; }
        public string Comment { get; set; }
    
        public virtual tblBlog tblBlog { get; set; }
        public virtual tblUser tblUser { get; set; }
    }
}

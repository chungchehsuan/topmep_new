
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace topmeperp.Models
{

using System;
    using System.Collections.Generic;
    
public partial class SYS_USER
{

    public string USER_ID { get; set; }

    public string ROLE_ID { get; set; }

    public string USER_NAME { get; set; }

    public string EMAIL { get; set; }

    public string TEL { get; set; }

    public string TEL_EXT { get; set; }

    public string PASSWORD { get; set; }

    public string FAX { get; set; }

    public string MOBILE { get; set; }

    public Nullable<System.DateTime> CREATE_DATE { get; set; }

    public string CREATE_ID { get; set; }

    public Nullable<System.DateTime> MODIFY_DATE { get; set; }

    public string MODIFY_ID { get; set; }

    public string DEP_CODE { get; set; }



    public virtual SYS_ROLE SYS_ROLE { get; set; }

}

}

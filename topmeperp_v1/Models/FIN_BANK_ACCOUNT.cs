
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
    
public partial class FIN_BANK_ACCOUNT
{

    public long BANK_ACCOUNT_ID { get; set; }

    public string BANK_ID { get; set; }

    public string BANK_NAME { get; set; }

    public string BRANCH_NAME { get; set; }

    public string ACCOUNT_NO { get; set; }

    public string ACCOUNT_NAME { get; set; }

    public string REF_ACCOUNT_CODE { get; set; }

    public Nullable<decimal> CUR_AMOUNT { get; set; }

    public Nullable<System.DateTime> CUR_DATE { get; set; }

    public string CREATE_ID { get; set; }

    public Nullable<System.DateTime> CREATE_DATE { get; set; }

    public string MODIFY_ID { get; set; }

    public Nullable<System.DateTime> MODIFY_DATE { get; set; }

}

}
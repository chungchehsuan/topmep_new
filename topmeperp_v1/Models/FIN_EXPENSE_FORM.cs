
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
    
public partial class FIN_EXPENSE_FORM
{

    public string EXP_FORM_ID { get; set; }

    public string PROJECT_ID { get; set; }

    public Nullable<int> OCCURRED_YEAR { get; set; }

    public Nullable<int> OCCURRED_MONTH { get; set; }

    public Nullable<System.DateTime> PAYMENT_DATE { get; set; }

    public Nullable<int> STATUS { get; set; }

    public string CREATE_ID { get; set; }

    public Nullable<System.DateTime> CREATE_DATE { get; set; }

    public Nullable<System.DateTime> MODIFY_DATE { get; set; }

    public string REMARK { get; set; }

    public string PASS_CREATE_ID { get; set; }

    public Nullable<System.DateTime> PASS_CREATE_DATE { get; set; }

    public string APPROVE_CREATE_ID { get; set; }

    public Nullable<System.DateTime> APPROVE_CREATE_DATE { get; set; }

    public string JOURNAL_CREATE_ID { get; set; }

    public Nullable<System.DateTime> JOURNAL_CREATE_DATE { get; set; }

    public string REJECT_DESC { get; set; }

    public string PAYEE { get; set; }

}

}


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
    
public partial class PLAN_OTHER_PAYMENT
{

    public long OTHER_PAYMENT_ID { get; set; }

    public string EST_FORM_ID { get; set; }

    public string CONTRACT_ID { get; set; }

    public Nullable<decimal> AMOUNT { get; set; }

    public string REASON { get; set; }

    public string TYPE { get; set; }

    public Nullable<System.DateTime> CREATE_DATE { get; set; }

    public string CONTRACT_ID_FOR_REFUND { get; set; }

    public string EST_FORM_ID_REFUND { get; set; }

    public Nullable<int> EST_COUNT_REFUND { get; set; }

}

}

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
    
public partial class SYS_ROLE
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public SYS_ROLE()
    {

        this.SYS_PRIVILEGE = new HashSet<SYS_PRIVILEGE>();

        this.SYS_USER = new HashSet<SYS_USER>();

    }


    public string ROLE_ID { get; set; }

    public string ROLE_NAME { get; set; }

    public Nullable<System.DateTime> CREATE_DATE { get; set; }

    public string CREATE_ID { get; set; }

    public Nullable<System.DateTime> MODIFY_DATE { get; set; }

    public string MODIFY_ID { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<SYS_PRIVILEGE> SYS_PRIVILEGE { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<SYS_USER> SYS_USER { get; set; }

}

}
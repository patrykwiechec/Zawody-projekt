//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Zawody_projekt
{
    using System;
    using System.Collections.Generic;
    
    public partial class uczestnictwo
    {
        public int id_uczestnictwa { get; set; }
        public Nullable<int> id_zawodnika { get; set; }
        public Nullable<int> id_zawodow { get; set; }
    
        public virtual zawodnicy zawodnicy { get; set; }
        public virtual zawody zawody { get; set; }
    }
}

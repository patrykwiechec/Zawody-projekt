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
    using System.Collections.ObjectModel;
    
    public partial class zawodnicy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public zawodnicy()
        {
            this.uczestnictwo = new ObservableCollection<uczestnictwo>();
        }
    
        public int id_zawodnika { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string kraj { get; set; }
        public System.DateTime data_ur { get; set; }
        public Nullable<int> id_trenera { get; set; }
    
        public virtual trenerzy trenerzy { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<uczestnictwo> uczestnictwo { get; set; }
    }
}

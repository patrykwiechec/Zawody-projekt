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
    
    public partial class trenerzy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public trenerzy()
        {
            this.zawodnicy = new ObservableCollection<zawodnicy>();
        }
    
        public int id_trenera { get; set; }
        public string imie_t { get; set; }
        public string nazwisko_t { get; set; }
        public System.DateTime data_ur_t { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<zawodnicy> zawodnicy { get; set; }
    }
}

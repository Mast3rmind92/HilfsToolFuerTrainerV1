//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HilfsToolFuerTrainerV1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_Absenzen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_Absenzen()
        {
            this.T_Spieler = new HashSet<T_Spieler>();
        }
    
        public int ID { get; set; }
        public string Bezeichnung { get; set; }
        public Nullable<System.DateTime> VonDatum { get; set; }
        public Nullable<System.DateTime> BisDatum { get; set; }
        public Nullable<int> FK_Spieler { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Spieler> T_Spieler { get; set; }
    }
}
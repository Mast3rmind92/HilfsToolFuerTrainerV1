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
    
    public partial class T_Spieler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_Spieler()
        {
            this.T_Absenzen = new HashSet<T_Absenzen>();
            this.T_Bussen = new HashSet<T_Bussen>();
            this.T_Mannschaft = new HashSet<T_Mannschaft>();
            this.T_SpielerAnwesenheit = new HashSet<T_SpielerAnwesenheit>();
        }
    
        public int ID { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string TelefonNr { get; set; }
        public Nullable<int> FK_Absenzen { get; set; }
        public Nullable<int> FK_Bussen { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Absenzen> T_Absenzen { get; set; }
        public virtual T_Absenzen T_Absenzen1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Bussen> T_Bussen { get; set; }
        public virtual T_Bussen T_Bussen1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Mannschaft> T_Mannschaft { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_SpielerAnwesenheit> T_SpielerAnwesenheit { get; set; }
    }
}

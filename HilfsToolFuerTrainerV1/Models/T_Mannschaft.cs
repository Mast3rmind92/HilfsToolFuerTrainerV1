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
    
    public partial class T_Mannschaft
    {
        public int ID { get; set; }
        public Nullable<int> FK_Spieler { get; set; }
        public Nullable<int> FK_Inventar { get; set; }
        public Nullable<int> FK_Event { get; set; }
    
        public virtual T_Event T_Event { get; set; }
        public virtual T_Inventar T_Inventar { get; set; }
        public virtual T_Spieler T_Spieler { get; set; }
    }
}

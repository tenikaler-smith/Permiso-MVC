//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PersimosMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CatCorregimientos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CatCorregimientos()
        {
            this.Cliente = new HashSet<Cliente>();
        }
    
        public int IdCorregimiento { get; set; }
        public string NombreCorregimiento { get; set; }
        public int IdDistrito { get; set; }
    
        public virtual CatDistritos CatDistritos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cliente> Cliente { get; set; }
    }
}

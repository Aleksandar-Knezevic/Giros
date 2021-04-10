namespace Giros.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("staff")]
    public partial class staff
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public staff()
        {
            orders = new HashSet<order>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(45)]
        public string username { get; set; }

        [Required]
        [StringLength(45)]
        public string password { get; set; }

        public bool isAdmin { get; set; }

        [Required]
        [StringLength(45)]
        public string ime { get; set; }

        [Required]
        [StringLength(45)]
        public string prezime { get; set; }

        [Column(TypeName = "date")]
        public DateTime zaposlenOd { get; set; }

        [Required]
        [StringLength(45)]
        public string brojTelefona { get; set; }

        public decimal plata { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order> orders { get; set; }
    }
}

namespace Giros.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("order")]
    public partial class order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public order()
        {
            drinks = new HashSet<drink>();
            sides = new HashSet<side>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(45)]
        public string size { get; set; }

        [Required]
        [StringLength(45)]
        public string type { get; set; }

        public int staffId { get; set; }

        [StringLength(45)]
        public string location { get; set; }

        public sbyte? isActive { get; set; }

        public virtual staff staff { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<drink> drinks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<side> sides { get; set; }
    }
}

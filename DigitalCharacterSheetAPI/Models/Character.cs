using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalCharacterSheetAPI.Models   
{
    [Table("Characters")]
    public class Character
    {
        [Key]
        public int id { get; set; }

        [StringLength(30)]
        public string character_name { get; set; }

        [StringLength(100)]
        public string campaign { get; set; }

        public int? advancement_points { get; set; }

        public int? plot_points { get; set; }

        

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Attribute> attributes { get; set; }
    }
}

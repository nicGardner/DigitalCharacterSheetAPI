using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalCharacterSheetAPI.Models
{
    [Table("attributes")]
    public class AttributeModel
    {

        [StringLength(30)]
        public string characterName { get; set; }


        [StringLength(20)]
        public string attributeName { get; set; }

        public int? attributeValue { get; set; }

        //public virtual Character character { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH_gyakorlas2
{
    [Table("Caterings")]
    public class Catering
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(60)]
        [Required]
        public string Name { get; set; }

        public int PricePerPerson { get; set; }
    }
}

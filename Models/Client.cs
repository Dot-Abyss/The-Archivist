using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace The_Archivist.Models
{
    [Table("Clients", Schema = "dbo")]
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "معرف العميل")]
        public int Id { get; set; } 

        [Required]
        [Display(Name = "اسم العميل")]
        public string? clientName { get; set; }    
    }
}

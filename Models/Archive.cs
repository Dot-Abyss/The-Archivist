using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace The_Archivist.Models
{
    [Table("Archives",Schema = "dbo")]
    public class Archive
    {
        public Archive()
        {
            employees = new List<Employee>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "معرف الأرشيف")]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "العنوان")]
        public string? title { get; set; }

        [Required]
        [Display(Name = "المحتوى")]
        public string? content { get; set; }

        [ForeignKey("ArchiveTypes")]
        [Display(Name = "نوع الأرشيف")]
        public int archiveTypeId { get; set; }
        public virtual ArchiveType? archiveType { get; set; }

        [ForeignKey("Departments")]
        [Display(Name = "القسم")]
        public int departmentId { get; set; }
        
        public virtual Department? department { get; set; }

        
        [Display(Name = "الصورة")]
        public string? imageSrc { get; set; }

        [NotMapped]
        [Required]
        [Display(Name = "صورة الأرشيف")]
        public IFormFile imageFile { get; set; }

        
        [Display(Name = "الملف")]
        public string? fileSrc { get; set; }

        [NotMapped]
        [Required]
        [Display(Name = "ملف الأرشيف")]
        public IFormFile archFile { get; set; }
        
        [Required]
        [Display(Name = "تاريخ الإضافة")] //fluent
        public DateTime? addDateTime { get; set; }

        [Required]
        [Display(Name = "تاريخ النشر")]
        public DateTime? publishDateTime { get; set; }

        [ForeignKey("Clients")]
        [Display(Name = "العملاء")]
        public int clientId { get; set; }
        public virtual Client? client { get; set; }

        public virtual ICollection<Employee> employees { get; set; }


    }
}

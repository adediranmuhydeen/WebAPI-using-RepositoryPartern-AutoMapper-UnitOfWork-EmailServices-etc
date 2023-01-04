using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TodoApi.Core.Enums;

namespace TodoApi.Core.Domain
{
    public class Todo
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(25)]
        public string Title { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        [Required]
        [DisplayName("Created Date")]
        public DateTime CreatedDate { get; set; }
        [Required]
        [DisplayName("Updated Date")]
        public DateTime UpdatedDate { get; set; }
        [Required]
        [DisplayName("To Do Status")]
        public Status TodoStatus { get; set; }

    }
}

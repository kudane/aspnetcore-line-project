using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.Sqllite
{
    [Table("LineUser")]
    public class LineUser
    {
        [Key]
        public string? UserId { get; set; }
        public string? DisplayName { get; set; }
        public string? PictureUrl { get; set; }
        public string? StatusMessage { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace PasswordManagement.Client.Data
{
    public class PasswordCard
    {
        public int Id { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

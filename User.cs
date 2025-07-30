using System.ComponentModel.DataAnnotations;

namespace UserManagement.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthData { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }


    }
}

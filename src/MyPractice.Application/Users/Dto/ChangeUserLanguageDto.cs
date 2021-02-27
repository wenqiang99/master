using System.ComponentModel.DataAnnotations;

namespace MyPractice.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}
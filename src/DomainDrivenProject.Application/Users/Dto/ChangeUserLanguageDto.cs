using System.ComponentModel.DataAnnotations;

namespace DomainDrivenProject.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}
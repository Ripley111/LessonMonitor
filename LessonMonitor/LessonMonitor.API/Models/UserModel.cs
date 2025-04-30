using LessonMonitor.API.Attributes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LessonMonitor.API.Models
{
    public class UserModel
    {
        public int UserId { get; set; }

        [Description("Имя")]
        public string FirstName { get; set; }

        [Description("Фамилия")]
        public string SecondName { get; set; }

        [Description("Электронный адрес")]
        public string Email { get; set; }

        [AgeValidation(18, 100)]
        public int Age { get; set; }
    }
}

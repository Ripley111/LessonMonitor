using System.ComponentModel;

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
    }
}

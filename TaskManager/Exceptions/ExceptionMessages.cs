using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Exceptions
{
    public class ExceptionMessages
    {
        public const string USER_NOT_FOUND = "Пользователь c id {0} не найден";
        public const string USER_WITH_EMAIL_NOT_FOUND = "Пользователь c email {0} не найден";
        public const string USER_EXIST_BY_EMAIL = "Пользователь c email {0} уже существует";

        public const string TASK_NOT_FOUND = "Задача c id {0} не найдена";

        public const string PASSWORD_NOT_MATCH = "Пароли не совападают";
    }
}

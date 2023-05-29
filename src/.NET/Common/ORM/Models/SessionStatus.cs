using System.ComponentModel.DataAnnotations;

namespace Common.ORM.Models;

public enum SessionStatus
{
    [Display(Name = "В процессе")]
    Processing = 0,

    [Display(Name = "Завершено без ошибок")]
    Completed = 1,

    [Display(Name = "Завершено с ошибкой")]
    Error = 2
}

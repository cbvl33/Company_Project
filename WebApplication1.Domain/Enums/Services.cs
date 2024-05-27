using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Domain.Enums
{
    public enum Services
    {
        [Description("Создание логотипа")]
        СозданиеЛоготипа,
        [Description("Создание обложки")]
        СозданиеОбложки,
        [Description("Создание страницы")]
        СозданиеСтраницы,
        [Description("Полноценный сайт")]
        ПолноценныйСайт
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetOOP_v2
{
    interface ICourses
    {
        string NameCourse { get; set; }
        string DateCourse { get; set; }
        int HourCourse { get; set; }
    }
}

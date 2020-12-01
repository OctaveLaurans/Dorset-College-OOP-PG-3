using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetOOP_v2
{
    class Course
    {
        public string NameCourse { get; set; }
        public string DayCourse { get; set; }
        public int HourCourse { get; set; }
        public double Duration { get; set; }

        public void DisplaySchedule()
        {
            Console.WriteLine($"Day : {DayCourse}\nHour : {HourCourse}\nDuration : {Duration}\n");
        }
    }
}

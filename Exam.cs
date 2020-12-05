using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetOOP_v2
{
    class Exam
    {
        public string CourseConcerned { get; set; }
        public string DayExam { get; set; }
        public string HourExam { get; set; }
        public double DurationExam { get; set; }

        public void DisplayInformation()
        {
            Console.WriteLine($"Course : {CourseConcerned}\nDate : {DayExam}\nHour : {HourExam}\nDuration : {DurationExam}\n");
        }
    }
}

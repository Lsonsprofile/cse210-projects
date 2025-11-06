using System;

namespace Resumes
{
    public class Job
    {
        public string _jobTitle = "";
        public string _company = "";
        public int _startYear = 0;
        public int _endYear = 0;

        // displays the format of the job in the console
        public void Display()
        {
            Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
        }
    }
}
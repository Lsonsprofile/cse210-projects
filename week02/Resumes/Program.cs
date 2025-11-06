using System;
// uses the namespace of the class to track where the class is located in the project structure
namespace Resumes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create first job data object
            Job job1 = new Job();
            job1._jobTitle = "Software Engineer";
            job1._company = "Microsoft";
            job1._startYear = 2019;
            job1._endYear = 2022;

            // Create second job data object
            Job job2 = new Job();
            job2._jobTitle = "Manager";
            job2._company = "Apple";
            job2._startYear = 2022;
            job2._endYear = 2023;

            // create name from resume class
            Resume myResume = new Resume();
            myResume._name = "Alison rose";

            // job displays according to the format in the Job class
            // added job to resume class
            myResume._jobs.Add(job1);
            myResume._jobs.Add(job2);

            myResume.Display();

            
        }
    }
}
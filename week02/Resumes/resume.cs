using System;

namespace Resumes
{
    public class Resume
    {
        public string _name = "";
        public List<Job> _jobs = new List<Job>();

        public void Display()
        {
            Console.Write($"Name: {_name}\n");// i can also use a .WriteLine to write to next line
            Console.WriteLine("jobs:");
            foreach (Job job in _jobs)
            {
                job.Display();
            }
        }

            
    }
}
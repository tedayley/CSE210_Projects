using System;

public class Job
{
    public string _company;
    public string _jobTitle;
    public int _startYear;
    public int _endYear;

    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}


public class Resume
{
    public string _name;
    public List<Job> _jobs = new List<Job>();

    public void Display()
    {
        Console.WriteLine($"Resume of {_name}");
        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create first job
        Job job1 = new Job();
        job1._jobTitle = "Hobo";
        job1._company = "Employment center";
        job1._startYear = 2021;
        job1._endYear = 2023;

        // Create second job
        Job job2 = new Job();
        job2._jobTitle = "goofball";
        job2._company = "Bishop storehousee";
        job2._startYear = 2021;
        job2._endYear = 2023;

        // Create a resume and assign jobs
        Resume myResume = new Resume();
        myResume._name = "Taeg Dayley";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        // Display the resume
        myResume.Display();
    }
}

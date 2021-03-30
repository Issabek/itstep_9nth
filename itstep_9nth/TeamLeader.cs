using System;
namespace itstep_9nth
{
    public class TeamLeader:IWorker
    {
        public TeamLeader()
        {
        }

        public string Name { get ; set ; }
        public double Salary { get; set; }
        public double EmploymentPeriod { get; set; }

        public int Age { get ; set ; }

        public void ShowState(IPart part=null)
        {
            Console.WriteLine("Team work now!");
        }
    }
}

using System;
namespace itstep_9nth
{
    public class Worker:IWorker
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public int Age { get; set; }
        public double EmploymentPeriod { get; set; }

        public void ShowState(IPart part)
        {
            Console.WriteLine(part==null?string.Format("{} works over {1}",Name,part.GetType().Name):"{0} is working over this project",Name);
        }
        public Worker()
        {
        }
    }
}

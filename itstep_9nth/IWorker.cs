using System;
namespace itstep_9nth
{
    public interface IWorker
    {
        string Name { get; set; }
        double Salary { get; set; }
        double EmploymentPeriod { get; set; }
        int Age { get; set; }
        void ShowState(IPart part=null);
    }
}

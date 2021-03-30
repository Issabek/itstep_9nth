using System;
namespace itstep_9nth
{
    public interface IPart
    {
        TypeMaterial TypeMaterial { get; set; }
        int Count { get; set; }
        double TimeToCreate { get; set; }
        bool Status { get; set; }
        IWorker worker { get; set; }



        void PrintInfo();

    }
}

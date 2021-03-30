using System;
namespace itstep_9nth
{
    public class Window : IPart
    {
        public TypeMaterial TypeMaterial { get; set; }
        public int Count { get; set; }
        public double TimeToCreate { get; set; }
        public bool Status { get; set; }
        public IWorker worker { get; set; }
        public void PrintInfo()
        {
            Console.WriteLine("{0} окон материала {1} ", Count, TypeMaterial);
        }
    
        public Window()
        {
        }
    }
}

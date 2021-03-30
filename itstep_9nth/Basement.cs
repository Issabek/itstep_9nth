using System;
namespace itstep_9nth
{
    public class Basement : IPart
    {
        public TypeMaterial TypeMaterial { get; set; }
        public int Count { get; set; }
        public double TimeToCreate { get; set; }
        public bool Status { get; set; }
        public IWorker worker { get; set; }
        public void PrintInfo()
        {
            Console.WriteLine("{0} фундаментов материала {1} ", Count, TypeMaterial);
        }
    
        public Basement()
        {
        }
    }
}

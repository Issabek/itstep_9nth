using System;
using System.Collections.Generic;
using NameGenerator;
using System.Linq;
namespace itstep_9nth
{
    public class Team
    {
        public List<IWorker> workers = new List<IWorker>();
        public void CreateWorkers(int count)
        {
            
            Random rnd = new Random();
            for(int i = 0; i < count; i++)
            {
                IWorker worker = new Worker();
                string Name = "Worker: ".GenerateName();
                while (workers.Any(p => p.Name == Name))
                {
                    Name = "Worker: ".GenerateName();
                }
                worker.Name = Name;
                worker.Age = rnd.Next(18, 45);
                worker.Salary = rnd.Next(45000, 200000);
                this.workers.Add(worker);
            }
            IWorker team = new TeamLeader();
            team.Name = "Name TL";
            team.Age = 55;
            team.Salary = 120000;
            this.workers.Add(team);
        }
        public IWorker GetTL()
        {
            return workers.Where(w => w is TeamLeader).FirstOrDefault();
        }

        public IWorker GetWorker()
        {
            Random rnd = new Random();
            return workers[rnd.Next(0, workers.Count - 1)];
        }
        public Team()
        {
        }
    }
}

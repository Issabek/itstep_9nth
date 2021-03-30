using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;

namespace itstep_9nth
{
    public enum TypeMaterial
    {
        CONCRETE,
        METAL,
        NONE,
        BRICK
    }
    public class House
    {
        public List<Basement> Basement { get; set; }
        public List<Walls> Walls { get; set; }
        public List<Roof> Roof { get; set; }
        public List<Door> Door { get; set; }
        public List<Window> Window { get; set; }
        public double TotalCost { get; set; }


        public double GetTotalCost(TeamLeader tl)
        {
            List<IPart> parts = new List<IPart>();
            parts.AddRange(this.Basement);
            parts.AddRange(this.Walls);
            parts.AddRange(this.Roof);
            return parts.Select(part => part.worker.Salary * part.worker.EmploymentPeriod).Sum()+(tl.Salary*tl.EmploymentPeriod);
        }

        public void PrintReport()
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("рабочие принимавшие участие: ");
            Console.WriteLine("----------------------------------");

            foreach (var item in Basement)
                Console.WriteLine(item.GetType().Name+": "+item.worker?.Name);
            foreach (var item in Walls)
                Console.WriteLine(item.GetType().Name + ": " + item.worker?.Name);
            foreach (var item in Window)
                Console.WriteLine(item.GetType().Name + ": " + item?.worker?.Name);
            foreach (var item in Door)
                Console.WriteLine(item.GetType().Name + ": " + item?.worker?.Name);
            foreach (var item in Roof)
                Console.WriteLine(item.GetType().Name + ": " + item?.worker?.Name);
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Общая стоимость всех работ: "+TotalCost);
            Console.WriteLine("----------------------------------");

        }

        public House()
        {

        }
    }
    public class ServiceHouse
    {
        Random rnd = new Random();
        public House CreateHouse()
        {
            House house = new House();
            house.Basement = Init_basement(1);
            house.Walls = Init_walls(16);
            house.Window = Init_window(8);
            house.Door = Init_doors(4);
            house.Roof = Init_roof(1);

            return house;
        }
        public List<Basement> Init_basement(int count)
        {
            List<Basement> basements = new List<Basement>();
            for(int i = 0; i < count; i++)
            {
                Basement basement = new Basement();
                basement.Count = i;
                basement.TimeToCreate = rnd.Next(1, 30);
                basement.TypeMaterial = TypeMaterial.CONCRETE;
                basements.Add(basement);
            }
            return basements;
        }
        public List<Walls> Init_walls(int count)
        {
            List<Walls> walls = new List<Walls>();
            for (int i = 0; i < count; i++)
            {
                Walls wall = new Walls();
                wall.Count = i;
                wall.TypeMaterial = TypeMaterial.BRICK;
                wall.TimeToCreate = rnd.Next(1, 30);
                walls.Add(wall);
            }
            return walls;
        }
        public List<Roof> Init_roof(int count)
        {
            List<Roof> roofs = new List<Roof>();
            for (int i = 0; i < count; i++)
            {
                Roof roof = new Roof();
                roof.Count = i;
                roof.TypeMaterial = TypeMaterial.BRICK;
                roof.TimeToCreate = rnd.Next(1, 30);
                roofs.Add(roof);
            }
            return roofs;
        }
        public List<Window> Init_window(int count)
        {
            List<Window> windows = new List<Window>();
            for (int i = 0; i < count; i++)
            {
                Window window = new Window();
                window.Count = i;
                window.TypeMaterial = TypeMaterial.BRICK;
                window.TimeToCreate = rnd.Next(1, 30);
                windows.Add(window);
            }
            return windows;
        }
        public List<Door> Init_doors(int count)
        {
            List<Door> doors = new List<Door>();
            for (int i = 0; i < count; i++)
            {
                Door door = new Door();
                door.Count = i;
                door.TypeMaterial = TypeMaterial.BRICK;
                door.TimeToCreate = rnd.Next(1, 30);
                doors.Add(door);
            }
            return doors;
        }


        public List<IPart> GetUndone(House house)
        {
            List<IPart> parts = new List<IPart>();
            parts.AddRange(house.Basement);
            parts.AddRange(house.Walls);
            parts.AddRange(house.Window);
            parts.AddRange(house.Door);
            parts.AddRange(house.Roof);
            return parts.ToList();
            
        }

        public void StartBuild()
        {
            House house = CreateHouse();
            Team team = new Team();
            team.CreateWorkers(5);

            foreach (IPart part in GetUndone(house))
            {
                var worker = team.GetWorker();
                if (worker is TeamLeader)
                    house.PrintReport();
                else
                {
                    part.worker = worker;
                    part.Status = true;
                    worker.EmploymentPeriod += part.TimeToCreate;
                    worker.ShowState(part);
                    for (int i = 0; i < part.TimeToCreate; i++)
                    {
                        Console.Write(".");
                        Thread.Sleep(100);
                    }

                    Console.WriteLine("");
                }

            }
            double temp = team.workers.Where(p => p is Worker).Max(w => w.EmploymentPeriod);
            TeamLeader templ = team.GetTL() as TeamLeader;
            templ.EmploymentPeriod = temp;
            house.TotalCost = house.GetTotalCost(templ);
            house.PrintReport();
        }
    }
}

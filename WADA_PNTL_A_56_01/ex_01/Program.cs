using ex_01.CLASSES;
using ex_01.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ex_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t*********** BLOOD BANK REPOSITORY PROJECT ***********");

            entryPoint();

            Console.ReadKey();
        }

        public static void entryPoint()
        {

            Console.Write($"1. Show All Donetor\n2. Insert Donetor\n3. Update Donetor\n4. Delete Donetor\nEnter SL Number : ");
            //Console.WriteLine("1. Show All Donetor");
            //Console.WriteLine("2. Insert Donetor");
            //Console.WriteLine("3. Update Donetor");
            //Console.WriteLine("4. Delete Donetor");

            var index = int.Parse(Console.ReadLine());
            actualization(index);

        }
        public static void actualization(int index)
        { 
            DonetorRepo dRepo = new DonetorRepo();
            if (index == 1)
            {
                var dList = dRepo.getAll();
                if (dList.Count() == 0)
                {
                    Console.WriteLine("********************************");
                    Console.WriteLine("No data found in this list !!");
                    Console.WriteLine("********************************");
                    entryPoint();
                }
                else
                {
                    foreach (var dl in dList)
                    {
                        Console.WriteLine("********************************");

                        Console.WriteLine($"Donetor ID\t: {dl.donetorId}\nDonetor Name\t: {dl.donetorName}\nDonetor Age\t: {dl.donetorAge}\nDonetor Blood Group : {dl.donetorBloodGroup}");

                        Console.WriteLine("********************************");
                    }
                    entryPoint();
                }
            }

            else if (index == 2)
            {
                Console.WriteLine("********************************");

                int maxId = dRepo.getAll().Any() ? dRepo.getAll().Max(d => d.donetorId) : 0;

                Console.Write("Enter Donetor Name : ");
                string dName = Console.ReadLine();

                Console.Write("Enter Donetor Age : ");
                int dAge = int.Parse(Console.ReadLine());

                Console.Write("Enter Donetor Blood Group : ");
                string dBloodg = Console.ReadLine();

                Donetor _donetor = new Donetor
                {
                    donetorId = maxId + 1,
                    donetorName = dName,
                    donetorAge = dAge,
                    donetorBloodGroup = dBloodg
                };

                dRepo.insert(_donetor);
                Console.WriteLine("Data Insert Successfull...");
                Console.WriteLine("********************************");
                entryPoint();
            }

            else if (index == 3)
            {
                Console.WriteLine("********************************");

                Console.Write("Enter Donetor Id for update data : ");
                int upId = int.Parse(Console.ReadLine());

                var getId = dRepo.getById(upId);

                if (getId == null)
                {
                    Console.WriteLine("********************************");
                    Console.WriteLine("No ID found !!");
                    Console.WriteLine("********************************");
                    entryPoint();
                }
                else
                {
                    Console.WriteLine($"\nEnter Update Info For This Id : {upId}");
                    Console.WriteLine("********************************");

                    Console.Write("Enter Donetor Name : ");
                    string dName = Console.ReadLine();

                    Console.Write("Enter Donetor Age : ");
                    int dAge = int.Parse(Console.ReadLine());

                    Console.Write("Enter Donetor Blood Group : ");
                    string dBloodg = Console.ReadLine();

                    Donetor _donetor = new Donetor
                    {
                        donetorId = upId,
                        donetorName = dName,
                        donetorAge = dAge,
                        donetorBloodGroup = dBloodg
                    };

                    dRepo.update(_donetor);
                    Console.WriteLine("Data Update Successfull...");
                    Console.WriteLine("********************************");
                    entryPoint();
                }
            }

            else if (index == 4)
            {
                Console.WriteLine("********************************");
                Console.Write("Enter Donetor ID for Delete Data : ");
                int delID = int.Parse(Console.ReadLine());

                var getID = dRepo.getById(delID);
                if (getID == null)
                {
                    Console.WriteLine("********************************");
                    Console.WriteLine("No ID found this time !!");
                    Console.WriteLine("********************************");
                    entryPoint();
                }
                else
                {
                    dRepo.deleteById(delID);
                    Console.WriteLine("Data Delete Successfull...");
                    Console.WriteLine("********************************");
                    entryPoint();
                }
            }
        }

    }
}

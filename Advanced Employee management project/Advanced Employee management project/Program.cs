using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Employee_management_project
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> myWorkers = new List<Employee>();

                bool mainLoop = true;
                while (mainLoop)
                {
                       Methods.ReadInFile("file", myWorkers);
                       Methods.MenuDisplay();

                string userValue = Methods.UserInput();

                    if (userValue == "1")
                    {
                        Methods.CreateNewEmployee(myWorkers);
                    }
                    else if (userValue == "2")
                    {
                        Methods.GiveEmployeeRaise(myWorkers);
                    }
                    else if (userValue == "3")
                    {
                        Methods.PayAllEmployees(myWorkers);
                    }
                    else if (userValue == "4")
                    {
                        Methods.DisplayAllEmployees(myWorkers);
                    }
                    else if (userValue == "5")
                    {
                        Methods.TerminateEmployee(myWorkers);
                    }
                    else if (userValue == "6")
                    {
                        Methods.WriteFile(myWorkers);
                        mainLoop = false;
                    }
                    else
                    {
                        Methods.InvalidEntry();
                    }
                }
                Console.ReadKey();
            }
        }
    }


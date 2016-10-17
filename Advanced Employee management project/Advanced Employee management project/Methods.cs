using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Advanced_Employee_management_project
{
    public static class Methods
    {
        public static void ReadInFile(string file,List<Employee> myWorkers)
        {
            file = ("C:\\Users\\iykef\\OneDrive\\Documents\\workforce.xml");
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(file);
            XmlNode employeeCat = doc.DocumentElement.SelectSingleNode("/Business");

            foreach (XmlNode child in employeeCat.ChildNodes)
            {
                string employeeId = "";
                string employeeName = "";
                double employeePayRate = 0;

                foreach (XmlNode grandChild in child.ChildNodes)
                {
                    switch (grandChild.Name)
                    {
                        case "ID":
                            {
                                employeeId = grandChild.InnerText;
                                Console.WriteLine(employeeName);
                                break;
                            }
                        case "Name":
                            {
                                employeeName = grandChild.InnerText;
                                Console.WriteLine(employeeName);
                                break;
                            }

                        case "PayRate":
                            {
                                employeePayRate = Convert.ToDouble(grandChild.InnerText);
                                Console.WriteLine(employeePayRate);
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                    Employee emp2 = new Employee(employeeId, employeeName, employeePayRate);
                    myWorkers.Add(emp2);
                }
            }
        }
        }

        public static void MenuDisplay()
        {
            Console.Title = ("Advanced Employee Management Portal V1");
            Console.Clear();
            Console.WriteLine("Welcome To Your Employee Management Portal");
            Console.WriteLine("\n");
            Console.WriteLine("Press 1, To Create an Employee");
            Console.WriteLine("Press 2, To Raise Employee Pay");
            Console.WriteLine("Press 3, To Pay Employees");
            Console.WriteLine("press 4, To Display all Employees");
            Console.WriteLine("press 5, To Terminate an Employee");
            Console.WriteLine("Press 6, To, Exit App");
            Console.WriteLine("\n");
            Console.Write("Select a task:");
        }

        public static string UserInput()
        {
            return Console.ReadLine();
        }

        public static void CreateNewEmployee(List<Employee> allWorkers)
        {
           // List<Employee> myWorkers = new List<Employee>();
            string userValue = UserInput();
            {
                bool addNewEmployee = true;
                while (addNewEmployee)
                {
                    Console.WriteLine("\n");
                    Console.Write("Enter Employee ID\n");
                    string employeeId = UserInput();
                    Console.Clear();

                    Console.WriteLine("\n");
                    Console.Write("Enter Employee's Full Name\n");
                    string employeeName = UserInput();
                    Console.Clear();

                    Console.WriteLine("\n");
                    Console.Write("Enter Employee Pay\n");
                    double employeePayRate = Convert.ToDouble(UserInput());
                    Console.Clear();

                    Console.WriteLine("\n");
                    Employee emp1 = new Employee(employeeId, employeeName, employeePayRate);
                    allWorkers.Add(emp1);
                    addNewEmployee = true;
                    Console.WriteLine("Do you Wish to Add A New Employee? (y/n)");
                    userValue = UserInput();
                    Console.Clear();

                    if (userValue == "y")
                    {
                        addNewEmployee = true;
                    }
                    else
                    {
                        addNewEmployee = false;
                    }
                    for (int i = 0; i < allWorkers.Count; i++)
                    {
                        if (userValue == "n")
                        {
                            Methods.MenuDisplay();
                        }
                    }
                }
            }
        }

        public static void TerminateEmployee(List<Employee> myWorkers)
        {
            bool itemFound = false;
            foreach (Employee worker in myWorkers)
            {
                Console.WriteLine("To Terminate an Employee\n");
                Console.Write("Enter an Employee ID");
                string userValue = UserInput();
                if (worker.EmployeeId == userValue)
                {
                    itemFound = true;
                    worker.TerminateEmp();
                    Console.WriteLine(worker.EmployeeName + "Has Been Terminated");
                }
                if (itemFound == false)
                {
                    Console.WriteLine("Sorry we couldn't find this Employee ");
                }
            }
        }

        public static void GiveEmployeeRaise(List<Employee> myWorkers)
        {
            {
                bool itemFound = false;

                foreach (Employee worker in myWorkers)
                {
                    Console.WriteLine("To Promote an Employee, Enter the Employee ID\n");
                    Console.Write("Enter an Employee ID");
                    string userValue = UserInput();
                    if (worker.EmployeeId == UserInput())
                    {
                        itemFound = true;
                        worker.GiveEmployeeRaise1();
                        Console.WriteLine
                            (worker.EmployeeName + 
                            "Has Been Promoted with a new pay of" + worker.EmployeePayRate);
                    }
                    if (itemFound == false)
                    {
                        Console.WriteLine("Sorry we couldn't find this Employee ");
                    }
                }

            }
        }

        public static void PayAllEmployees(List<Employee> myWorkers)
        {
            foreach (Employee worker in myWorkers)
            {
                if (DateTime.Today == null)
                {
                    Console.WriteLine(worker.EmployeeName + " Got paid");
                    Console.WriteLine(" ");
                }
            }
        }

        public static void DisplayAllEmployees(List<Employee> myWorkers)
        {
            Methods.ReadInFile("file",myWorkers);
            bool itemFound = false;
            foreach (Employee worker in myWorkers)
            {
                    if(itemFound == true)
                    Console.WriteLine(string.Format("ID: {0}","Full Name: {1}", "Wage: {2}",
                    worker.EmployeeId, worker.EmployeeName, worker.EmployeePayRate));
                else if (itemFound == false)
                {
                    Console.WriteLine("Sorry we couldn't find your list of Employees ");
                }
            }
        }

        public static void WriteFile(List<Employee> myWorkers)
        {
                using (XmlWriter writer = XmlWriter.Create("C:\\Users\\iykef\\OneDrive\\Documents\\workforce.xml"))
               {
                        writer.WriteStartDocument();
                        writer.WriteStartElement("Business");
                foreach (Employee theWorkers in myWorkers)
                    {
                        writer.WriteStartElement("Employee");
                        writer.WriteElementString("ID", theWorkers.EmployeeId.ToString());
                        writer.WriteElementString("Name", theWorkers.EmployeeName.ToString());
                        writer.WriteElementString("PayRate", theWorkers.EmployeePayRate.ToString());
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();

                    writer.WriteEndDocument();

                }

            }

    public static void InvalidEntry()
    {
        Console.WriteLine("Sorry that was an invalid entry");
        Console.Clear();
    }

    public static void BeginTask()
    {
        Console.WriteLine("Press The Enter Key to begin Task");
    }

    public static void BeginExit()
    {
        Console.WriteLine("Press Enter to Close Application");
    }
}
}
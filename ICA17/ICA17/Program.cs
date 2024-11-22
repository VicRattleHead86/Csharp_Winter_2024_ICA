/*
 * Giezar Panaligan ICA17
 * 
 * Apr 9, 2024
 * CMPE1300 - ICA 17
 * 
 * Pseudo Code
 *      Display titles and Prompt the user to enter the following values
 *      Initialize arrays with employee details
 *      Set Arrays for Employee ID, Salary, and Age
 *      Define minimum and maximum values for menu selection
 *      Declare variable for selected task
 *      Create array of Employee structs and populate with employee details
 *      Call method to Display all employees
 *      Declare and reset variables for menu choices and input validation
 *      Display Show menu options to the user
 *      Get user choice with validation
 *      Menu option 1: Display employees with salary above a threshold
 *      Get threshold from user with validation
 *      Display filtered list
 *      Menu options 2 and 3: Display employees based on ID or age filter
 *      Get filter value from user with validation
 *      Display filtered list based on selected task while user chooses not to exit 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ICA17
{
    internal class Program
    {
        // Define Employee struct with properties for ID, Salary, and Age
        private struct Employee
        {
            public int iEmployee_id;
            public decimal dEmployee_Salary;
            public int iEmployee_Age;

            // Define Employee struct with properties for ID, Salary, and Age
            public Employee(int iEmployeeid, decimal dEmployeeSalary, int iEmployeeAge)
            {
                iEmployee_id = iEmployeeid;
                dEmployee_Salary = dEmployeeSalary;
                iEmployee_Age = iEmployeeAge;
            }

            // Override ToString() to return employee details as a string
            public override string ToString()
            {
                return "Employee id " + iEmployee_id + " : " + iEmployee_Age + " years $" + dEmployee_Salary;
            }
        }

        // Main method: entry point of the program
        static void Main(string[] args)
        {
            int[] iEmpID_Array = { 28, 53, 12, 18, 8, 2, 19, 57, 62, 34, 23, 14, 48, 35, 26 };
            decimal[] dEmpSal_Array = { 4500, 2800, 1900, 3100, 7000, 3500, 2200, 2800, 2850, 3150, 4000, 4500, 6000, 7200, 3800 };
            int[] iEmpAge_Array = { 21, 33, 24, 58, 54, 36, 41, 44, 33, 36, 40, 33, 45, 46, 35 };


            int iMin = 1;
            int iMax = 4;
            int iTask;


            Employee[] employees = new Employee[iEmpID_Array.Length];

            for (int i = 0; i < iEmpID_Array.Length; i++)
            {
                employees[i] = new Employee(iEmpID_Array[i], dEmpSal_Array[i], iEmpAge_Array[i]);
            }

            DisplayEmployees(employees);

            // Main loop: show menu, get user input, and perform actions until exit option is chosen
            do
            {

                decimal iThreshold = 0;
                iTask = 0;
                bool bValid = false;

                Console.Write("\n**********Menu***********\n");
                Console.Write("1. Display All Employee Info Where Salary is higher than the given value\n");
                Console.Write("2. Display All Employee Info Where Employee ID is higher than given value\n");
                Console.Write("3. Display All Employee Info Where Age is lower than given value\n");
                Console.Write("4. Exit Program\n");

                GetValue(out iTask, "Enter your choice (1-4): ", iMin, iMax);

                if (iTask == 1)
                {
                    do
                    {
                        Console.Write("Input the Threshold Salary Value: ");
                        bValid = decimal.TryParse(Console.ReadLine(), out iThreshold);

                        if (!bValid)
                        {
                            Console.Write("You have entered an invalid input \n");
                        }
                        else
                            DisplayEmployees(employees, iThreshold);
                    }
                    while (!bValid);
                }
                else if (iTask == 2 || iTask == 3)
                {
                    int threshold; // For ID or age, use an int
                    do
                    {
                        Console.Write("Input the Filter Value: ");
                        bValid = int.TryParse(Console.ReadLine(), out threshold);

                        if (!bValid)
                        {
                            Console.WriteLine("You have entered an invalid input.");
                        }
                        else if (bValid)
                        {
                            DisplayEmployees(employees, threshold, iTask); // Ensure iTask is correctly mapping to the desired filter logic
                        }
                    }
                    while (!bValid);
                }
            }
            while (iTask != 4);
        }

        // Method to get a valid integer value from user within specified range
        static public int GetValue(out int iiTaskRet, string sPrompt,int iMin, int iMax)
        {
            bool bValid = false;
            // Loop until a valid integer within the specified range is entered by the user
            do
            {
                Console.Write(sPrompt);
                bValid = int.TryParse(Console.ReadLine(), out iiTaskRet);

                if (!bValid)
                {
                    Console.WriteLine("An invalid number was entered. Please try again.");
                    bValid = false;
                }
                else if (bValid == true && (iiTaskRet < iMin || iiTaskRet > iMax))
                {
                    Console.WriteLine("The value entered is outside the range accepted.");
                    bValid = false;
                }
                else
                {
                    bValid = true;
                }
            }
            while (!bValid);

            return iiTaskRet;
        }

        // Method to display all employees without filter
        static void DisplayEmployees(Employee[] employees)
        {
            // Iterate through and print details of each employee
            foreach (var employee in employees)
            {
                Console.WriteLine(employee.ToString());
            }
        }
        // Method to display employees with salary above a specified threshold
        static void DisplayEmployees(Employee[] employees, decimal threshold)
        {
            Console.WriteLine($"\nEmployee info where Salary >= {threshold}");
            
            // Filter employees by salary and print details
            foreach (var employee in employees)
            {
                if (employee.dEmployee_Salary >= threshold)
                {
                    Console.WriteLine(employee.ToString());
                }
            }
        }

        // Method to display employees based on ID or age filter
        static void DisplayEmployees(Employee[] employees, int threshold, int filter)
        {
            string sFilter = filter == 2 ? "ID >=": "Age <=";

            Console.WriteLine($"\nEmployee info with {sFilter} {threshold}" );

            // Determine filter type (ID or age) and print filtered employee details
            foreach (var employee in employees)
            {
                // Filter by Employee ID
                if (filter == 2 && employee.iEmployee_id >= threshold)
                {
                    Console.WriteLine(employee.ToString());
                }
                // Filter by Employee Age
                else if (filter == 3 && employee.iEmployee_Age <= threshold)
                {
                    Console.WriteLine(employee.ToString());
                }
            }
        }
    }
}

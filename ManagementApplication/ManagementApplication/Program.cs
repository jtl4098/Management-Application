using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApplication

{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========================================\n" +
                              "Employees Management Application.\n" +
                              "========================================\n");


            string line = ""; //moved 

            // string line2 = ""; // set a variable to check the line of  
            int lineNumber = 0;

            int lineCount = 0; // To decide length of list 


            /*
             * It is needed to check the number of employees (the number of lines in csv file)
             * 
             */
            try
            {
                StreamReader fileInput2 = new StreamReader("employees.csv"); // To read employees.csv file
                /*
                 * the lineCount variable is increased one when each line is finished to read
                 * Therefore, the application is able to know how many lines are in employees.csv file
                 * And decide length of array(employees)
                 */
                while (!fileInput2.EndOfStream)
                {
                    line = fileInput2.ReadLine();
                    if (lineCount < 101) // maximum length of array is 100
                    {
                        lineCount++;
                    }
                    
                }

            }
            catch (FileNotFoundException ex) // error exception. if there is no file or wrong file name, an error message shows up
            {
                Console.WriteLine("Could not find file employees.csv" + ex.Message);

            }

            // set employees class of array. the length is decided by lines of the file
            Employee[] employees = new Employee[lineCount];

            try
            {
                // To read employees.csv file
                StreamReader fileInput = new StreamReader("employees.csv");

                /*
                 * To read from beginning to end
                 * the object of Employee is created by each line of employees.csv file 
                 */
                while (!fileInput.EndOfStream)
                {
                    line = fileInput.ReadLine();
                    String[] parts = line.Split(','); // split a line into a comma[,] to decide the parameter of the object of Employee 
                    employees[lineNumber] = new Employee(parts[0], int.Parse(parts[1]), decimal.Parse(parts[2]), double.Parse(parts[3]));
                    lineNumber++;

                }
                fileInput.Close();
            }
            catch (FileNotFoundException ex) // error exception. if there is no file or wrong file name, an error message shows up
            {
                Console.WriteLine("Could not find file employees.csv" + ex.Message);

            }
            // error exception. An error message shows up when the format of input variables is wrong
            catch (FormatException ex)
            {
                Console.WriteLine($"Error on Line {lineNumber + 1} reading line {line} - {ex.Message}");

            }
            // set boolean variable to finish the application.
            Boolean running = true;


            while (running) // Keep going  until running variable is false
            {
                try
                {
                    Console.WriteLine("=============== [ MENU ] ===============\n" +
                                      "1 - Display all of the Employees\n" +
                                      "2 - Sort by Employee Name (ascending) \n" +
                                      "3 - Sort by Employee Number (ascending)\n" +
                                      "4 - Sort by Employee Pay Rate (descending)\n" +
                                      "5 - Sort by Employee Hours (descending)\n" +
                                      "6 - Sort by Employee Gross Pay (descending)\n" +
                                      "7 - Exit\n\n" +
                                      "Enter Option: ");
                    int option = int.Parse(Console.ReadLine());

                    // set variables to use as an index
                    int i = 0;
                    int j = 0;
                    Employee key;

                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("ALL Employees");
                            foreach (Employee c in employees)
                                Console.WriteLine(c);

                            break;
                        case 2:
                            int n = employees.Length;
                            for (i = 0; i < n - 1; i++)
                                for (j = 0; j < n - 1 - i; j++)
                                    if (employees[j].GetName().CompareTo(employees[j + 1].GetName()) > 0)
                                    {
                                        Employee tempCar = employees[j + 1];
                                        employees[j + 1] = employees[j];
                                        employees[j] = tempCar;
                                    }
                            break;
                        case 3:
                            for (i = 1; i < employees.Length; i++)
                            {
                                key = employees[i];
                                for (j = i - 1; j >= 0 && employees[j].GetNumber() > key.GetNumber(); j--)
                                {
                                    employees[j + 1] = employees[j];
                                }
                                employees[j + 1] = key;
                            }

                            break;
                        case 4:

                            for (i = 1; i < employees.Length; i++)
                            {
                                key = employees[i];
                                for (j = i - 1; j >= 0 && employees[j].GetRate() < key.GetRate(); j--)
                                {
                                    employees[j + 1] = employees[j];
                                }
                                employees[j + 1] = key;
                            }
                            break;

                        case 5:



                            for (i = 1; i < employees.Length; i++)
                            {
                                key = employees[i];
                                for (j = i - 1; j >= 0 && employees[j].GetHours() < key.GetHours(); j--)
                                {
                                    employees[j + 1] = employees[j];
                                }
                                employees[j + 1] = key;
                            }
                            break;
                        case 6:


                            for (i = 1; i < employees.Length; i++)
                            {
                                key = employees[i];
                                for (j = i - 1; j >= 0 && employees[j].GetGross() < key.GetGross(); j--)
                                {
                                    employees[j + 1] = employees[j];
                                }
                                employees[j + 1] = key;
                            }


                            break;

                        case 7:
                            running = false;
                            break;
                        default:
                            Console.WriteLine("\nInvalid option - please re-enter, the range of option (1-7)\n");
                            break;
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("\nInvalid Input - Please re-enter (1-7)\n", ex.Message);
                }


            }
        }
    }
}

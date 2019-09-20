using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// Program : Program
/// @Author : Taekyung Kil
/// Date : 18/Sep/2019
/// Purpose : To set employee management application

namespace ManagementApplication

{
    class Program
    {


        static void InsertionSort(Employee[] arrayName, int option)
        {
            /*
             * Insertion Sort  
             * Reference
             * Heejeong Kwon,{ What is the insertion sort }, Retrieved from https://gmlwjd9405.github.io/2018/05/06/algorithm-insertion-sort.html.
             * the method of purpose is to sort an array
             * there are five options of sort
             */
            switch (option)
            {
                case 1:  // Sort by name 
                    int j = 0; // set a variable to use as an index

                    for (int i = 1; i < arrayName.Length; i++) //outer loop
                    {
                        Employee key = arrayName[i]; // create temporary object                      
                        for (j = i - 1; j >= 0 && arrayName[j].GetName().CompareTo(key.GetName()) > 0; j--) // inner loop 
                        {
                            arrayName[j + 1] = arrayName[j];
                        }
                        arrayName[j + 1] = key;
                    }

                    break;
                case 2: //Sort by numbers

                    for (int i = 1; i < arrayName.Length; i++) //outer loop
                    {
                        Employee key = arrayName[i]; // create temporary object 

                        for (j = i - 1; j >= 0 && arrayName[j].GetNumber() > key.GetNumber(); j--)
                        {
                            arrayName[j + 1] = arrayName[j];
                        }
                        arrayName[j + 1] = key;
                    }
                    break;
                case 3: // Sort by pay rates

                    for (int i = 1; i < arrayName.Length; i++) //outer loop
                    {
                        Employee key = arrayName[i]; // create temporary object 
                        for (j = i - 1; j >= 0 && arrayName[j].GetRate() < key.GetRate(); j--)
                        {
                            arrayName[j + 1] = arrayName[j];
                        }
                        arrayName[j + 1] = key;
                    }
                    break;
                case 4: // Sort by hours

                    for (int i = 1; i < arrayName.Length; i++) //outer loop
                    {
                        Employee key = arrayName[i]; // create temporary object 
                        for (j = i - 1; j >= 0 && arrayName[j].GetHours() < key.GetHours(); j--)
                        {
                            arrayName[j + 1] = arrayName[j];
                        }
                        arrayName[j + 1] = key;
                    }
                    break;

                case 5: // Sort by pay gross

                    for (int i = 1; i < arrayName.Length; i++) //outer loop
                    {
                        Employee key = arrayName[i];
                        for (j = i - 1; j >= 0 && arrayName[j].GetGross() < key.GetGross(); j--)
                        {
                            arrayName[j + 1] = arrayName[j];
                        }
                        arrayName[j + 1] = key;
                    }
                    break;
                    
            }
            foreach (Employee c in arrayName)  //each object in the array of object
                Console.WriteLine(c);
        }
    
        static void ReadMethod(Employee[] emp, string path)
        {
            int lineNumber = 0;
            string line = "";
            try
            {
                // To read employees.csv file
                StreamReader fileInput = new StreamReader(path);

                /*
                 * To read from beginning to end
                 * the object of Employee is created by each line of employees.csv file 
                 */
                while (!fileInput.EndOfStream)
                {
                    line = fileInput.ReadLine();
                    String[] parts = line.Split(','); // split a line into a comma[,] to decide the parameter of the object of Employee 
                    emp[lineNumber] = new Employee(parts[0], int.Parse(parts[1]), decimal.Parse(parts[2]), double.Parse(parts[3]));
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

        }

        static int AmountOfLines(string path)
        {
            string line = ""; //moved 
            int lineCount = 0; // To decide length of list 


            ///It is needed to check the number of employees (the number of lines in csv file)
            try
            {
                StreamReader fileInput2 = new StreamReader(path); // To read employees.csv file
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
            return lineCount;
        }
    


        static void Main(string[] args)
        {
            Console.WriteLine("========================================\n" +
                              "Employees Management Application.\n" +
                              "========================================\n");


            

            // set employees class of array. the length is decided by lines of the file
            // AmountOfLines method is able to decide amount of lines in the file.
            Employee[] employees = new Employee[AmountOfLines("employees.csv")];

            // Use ReadMethod
            // there is no return value. the first parameter ,which is emloyees, is added objects by each line of the second parameter's file which is employees.csv
            ReadMethod(employees,"employees.csv");
            
            
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
                    int option = int.Parse(Console.ReadLine()); // set a variable to get user's input

                    switch (option) // decide a case by user's input
                    {
                        case 1:
                            Console.WriteLine("ALL Employees");
                            foreach (Employee c in employees)  //each object in the array of object
                                Console.WriteLine(c);
                            break;
                        case 2:
                            InsertionSort(employees, 1); // use the InsertionSort method to sort by name
                            break;
                        case 3:
                            InsertionSort(employees, 2); // use the InsertionSort method to sort by number
                            break;
                        case 4:
                            InsertionSort(employees, 3); // use the InsertionSort method to sort by pay rate
                            break;
                        case 5:
                            InsertionSort(employees, 4); // use the InsertionSort method to sort by hours
                            break;
                        case 6:
                            InsertionSort(employees, 5); // use the InsertionSort method to sort by gross pay
                            break;
                        case 7:
                            running = false; 
                            break;
                        default: // set an error for invalid input (out of range)
                            Console.WriteLine("\nInvalid option - please re-enter, the range of option (1-7)\n");
                            break;
                    }
                }
                catch (FormatException ex) // error exception, the user's input has to be valid input (integer 1-7)
                {
                    Console.WriteLine("\nInvalid Input - Please re-enter (1-7)\n", ex.Message);
                }


            }
        }
    }
}

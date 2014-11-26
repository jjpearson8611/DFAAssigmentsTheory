using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace TuringMachineSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            //first we ask the user what turing machine they would like to use
            bool correctInput = false;
            bool exit = false;

            StreamWriter logWriter = new StreamWriter("log.log");
            TuringMachine NewMachine = new TuringMachine();

            while (!exit)
            {
                while (!correctInput)
                {
                    Console.WriteLine("Which machine would you like to use?\n1) 8.2.1\n2) 8.2.2\n3) quit");
                    string input = Console.ReadLine();
                    int choice;

                    //make sure the user puts in an actual number
                    if (int.TryParse(input, out choice))
                    {
                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("Using 8.2.1");
                                logWriter.WriteLine("Using 8.2.1");
                                if (NewMachine.HandleInput("8.2.1.txt"))
                                {
                                    logWriter.WriteLine("readin success");
                                    Console.WriteLine("readin succeeded");
                                    correctInput = true;
                                }
                                else
                                {
                                    logWriter.WriteLine("readin failed");
                                    Console.WriteLine("File Read Failed\n");
                                }
                                break;

                            case 2:
                                Console.WriteLine("Using 8.2.2");
                                logWriter.WriteLine("Using 8.2.2");
                                if (NewMachine.HandleInput("8.2.2.txt"))
                                {
                                    logWriter.WriteLine("readin success");
                                    Console.WriteLine("readin succeeded");
                                    correctInput = true;
                                }
                                else
                                {
                                    logWriter.WriteLine("readin failed");
                                    Console.WriteLine("File Read Failed\n");
                                }
                                break;
                            case 3:
                                Console.WriteLine("exiting the program");
                                correctInput = true;
                                exit = true;
                                break;
                            default:
                                Console.WriteLine("Please Insert a number choice");
                                break;
                        }
                    }
                }

                //are we exiting? Is the starting state acceptable
                if (NewMachine.StartingState != null && exit == false)
                {
                    Console.WriteLine("What is your input?\nexit for Exit");
                    string inputString = Console.ReadLine();

                    if (string.Compare("exit", inputString.ToLower()) == 0)
                    {
                        exit = true;
                    }
                    else
                    {
                        logWriter.WriteLine(inputString);
                        if (NewMachine.HandleString(inputString))
                        {
                            logWriter.WriteLine("accepted");
                            Console.WriteLine("Accepted String");
                        }
                        else
                        {
                            logWriter.WriteLine("declined");
                            Console.WriteLine("get outta here!");
                        }
                    }
                }

            }
            logWriter.Close();
        }
    }
}

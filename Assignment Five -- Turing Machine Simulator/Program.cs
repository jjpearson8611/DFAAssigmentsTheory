using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            TuringMachine NewMachine = new TuringMachine();

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
                            if (NewMachine.HandleInput("8.2.1.txt"))
                            {
                                Console.WriteLine("readin succeeded");
                                correctInput = true;
                            }
                            else
                            {
                                Console.WriteLine("File Read Failed\n");
                            }
                            break;

                        case 2: 
                            Console.WriteLine("Using 8.2.2");
                            if (NewMachine.HandleInput("8.2.2.txt"))
                            {
                                Console.WriteLine("readin succeeded");
                                correctInput = true;
                            }
                            else
                            {
                                Console.WriteLine("File Read Failed\n");
                            }
                            break;
                        case 3:
                            correctInput = true;
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Please Insert a number choice");
                            break;
                    }
                }
            }
            if (NewMachine.StartingState != null && exit == false) 
            {
                Console.WriteLine("What is your input?\n");
                string inputString = Console.ReadLine();
                if (NewMachine.HandleString(inputString))
                {
                    Console.WriteLine("Accepted String");
                }
                else
                {
                    Console.WriteLine("get outta here!");
                }
            }

            Console.ReadLine();
        }
    }
}

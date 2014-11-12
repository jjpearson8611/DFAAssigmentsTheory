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

            while (!correctInput)
            {
                Console.WriteLine("Which machine would you like to use?");
                string input = Console.ReadLine();
                int choice;

                //make sure the user puts in an actual number
                if (int.TryParse(input, out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Coming Soon");
                            correctInput = true;
                            break;

                        case 2:
                            Console.WriteLine("coming Soon");
                            correctInput = true;
                            break;
                        default:
                            Console.WriteLine("Please Insert a number choice");
                            break;
                    }
                }
            }

            //we load that turing machine in


            //we determine what the language is is for the input alphabet and show it to the user
            // and ask them to create a string based on the input alphabet


        }
    }
}

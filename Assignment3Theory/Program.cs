using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;

namespace Assignment3Theory
{
    class Program
    {

        static void Main(string[] args)
        {
            StreamWriter writer = new StreamWriter("log.log");
            bool keepGoing = true;
            int result;
            List<State> workingList = new List<State>();

            while (keepGoing)
            {
                bool invalid = false;
                Console.WriteLine("What DFA would you like\n(1) Example 1\n(2) Example 2\n(3) Example 3\n(4) Custom\n(5)exit");
                if(int.TryParse(Console.ReadLine(), out result))
                {
                    switch(result)
                    {
                        case 1:
                            workingList = Example1();
                            writer.WriteLine("DFA on Page 152");
                            break;
                        case 2:
                            workingList = Example2();
                            writer.WriteLine("DFA on Page 154");
                            break;
                        case 3:
                            workingList = Example3();
                            writer.WriteLine("DFA on Page 155");
                            break;
                        case 4:
                            workingList = AskForInput();
                            break;
                        case 5:
                            keepGoing = false;
                            invalid = true;
                            break;
                        default:
                            invalid = true;
                            break;
                    }
                    if (!invalid)
                    {
                        Console.WriteLine("What is the string you would like (a's and b's)");
                        string word = Console.ReadLine();
                        writer.WriteLine(word);
                        if (isValid(workingList, word, writer))
                        {
                            Console.WriteLine("Accepted!");
                            writer.WriteLine("Accepted!");
                        }
                        else
                        {
                            Console.WriteLine("Declined!");
                            writer.WriteLine("Declined!");
                        }
                    }
                }

            }
            writer.Close();
        }

        public static void OtherMain()
        {
            string inputstring = string.Empty;
            StreamReader streamReader;

            Console.WriteLine("which example would you like to convert to minimized DFA?");
            Console.WriteLine("1) 3.4.1 input");
            Console.WriteLine("2) 4.4.1 input");
            Console.WriteLine("3) 4.4.2 input");
            Console.WriteLine("4) 4.8   input");
            Console.WriteLine("5) 4.10  input");
            int input = int.Parse(Console.ReadLine());

            switch (input)
            {
                case 1:
                    streamReader = new StreamReader("3.4.1_input.txt");
                    break;
                case 2:
                    streamReader = new StreamReader("4.4.1_input.txt");
                    break;
                case 3:
                    streamReader = new StreamReader("4.4.2_input.txt");
                    break;
                case 4:
                    streamReader = new StreamReader("4.8_input.txt");
                    break;
                case 5:
                    streamReader = new StreamReader("4.10_input.txt");
                    break;
                default:
                    return;
                    break;
            }


            int count = 0;
            int numberOfStates = 0;
            List<string> stateNames = new List<string>();
            List<string> stateInfo = new List<string>();
            List<string> acceptingStates = new List<string>();
            String[][] twoDArray;
            bool doneWithStates = false;
            while (!streamReader.EndOfStream)
            {
                if (doneWithStates)
                {
                    acceptingStates = streamReader.ReadLine().Split(',').ToList<string>();
                }
                else if (count > 1)
                {
                    stateInfo[count - 2] = streamReader.ReadLine();
                    count++;
                    if (count == (numberOfStates + 2))
                    {
                        doneWithStates = true;
                    }
                }
                else if (count == 1)
                {
                    stateNames = streamReader.ReadLine().Split(',').ToList<string>();
                    count++;
                }
                else
                {
                    numberOfStates = int.Parse(streamReader.ReadLine());
                    count++;
                }
            }

            HandleString(numberOfStates, stateNames, stateInfo, acceptingStates);
            PrintTable(stateNames);
        }

        /// <summary>
        /// this method isused to handle all input and output it as the DFA
        /// </summary>
        /// <param name="file">All input from the file</param>
        public static void HandleString(int count, List<string> names, List<string> states, List<string> acceptingStates)
        {
            for (int i = 0; i < count; i++)
            {

            }
        }

        public static void Minimize()
        {
            //first round remove final and non final states
        }

        public static void PrintTable(List<string> States)
        {
            Console.WriteLine('\n');
            for (int i = 1; i < States.Count; i++)
            {
                Console.Write(States[i]);
                for (int j = 0; j < i; j++)
                {

                }
                Console.WriteLine();
            }
            Console.Write(" ");
            for (int k = 0; k < States.Count - 1; k++)
            {
                Console.Write(States[k]);
            }

            Console.WriteLine();
        }

        /// <summary>
        /// this determines if the state is accepting
        /// </summary>
        /// <param name="list"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public static bool isValid(List<State> list, string word, StreamWriter writer)
        {
            State CurrentState = list[0];

            for (int i = 0; i < word.Length; i++)
            {
                writer.WriteLine("current letter " + word[i]);
                writer.WriteLine("current state " + CurrentState.ToString());
                CurrentState = list[CurrentState.nextState(word[i])];
            }

            return CurrentState.Final;
        }

        #region ExampleStates
        public static List<State> Example1()
        {
            List<State> temp = new List<State>();
            
            //0                   a  b  accepting
            temp.Add(new State(0, 1, 2, false));
            //1                   a  b  accepting
            temp.Add(new State(1, 4, 1, true));
            //2                   a  b  accepting
            temp.Add(new State(2, 3, 2, false));
            //3                   a  b  accepting
            temp.Add(new State(3, 4, 2, true));
            //4                   a  b  accepting
            temp.Add(new State(4, 4, 3, false));

            return temp;
        }

        public static List<State> Example2()
        {
            List<State> temp = new List<State>();

            //0                   a  b  accepting
            temp.Add(new State(0, 1, 4, true));
            //1                   a  b  accepting
            temp.Add(new State(1, 2, 4, true));
            //2                   a  b  accepting
            temp.Add(new State(2, 2, 3, false));
            //3                   a  b  accepting
            temp.Add(new State(3, 2, 5, false));
            //4                   a  b  accepting
            temp.Add(new State(4, 1, 5, true));
            //5                   a  b  accepting
            temp.Add(new State(5, 5, 5, true));

            return temp;
        }
        public static List<State> Example3()
        {
            List<State> temp = new List<State>();

            //0                   a  b  accepting
            temp.Add(new State(0, 1, 0, false));
            //1                   a  b  accepting
            temp.Add(new State(1, 2, 0, false));
            //2                   a  b  accepting
            temp.Add(new State(2, 3, 0, false));
            //3                   a  b  accepting
            temp.Add(new State(3, 3, 3, true));

            return temp;
        }
        #endregion


        /// <summary>
        /// this allows for creation of a dfa from the user
        /// </summary>
        /// <returns></returns>
        public static List<State> AskForInput()
        {
            Console.WriteLine("How many states will you have today?");
            int states = int.Parse(Console.ReadLine());

            Console.WriteLine("Okay! we will be using " + states.ToString() + " states");

            List<State> ListStates = new List<State>();

            for (int i = 0; i < states; i++)
            {
                Console.WriteLine("For state " + i + " which state will a result with");
                int tempA = int.Parse(Console.ReadLine());


                Console.WriteLine("For state " + i + " which state will b result with");
                int tempB = int.Parse(Console.ReadLine());

                Console.WriteLine("Is state " + i + " a terminal state? (y/n)");
                string temp = Console.ReadLine();

                bool tempC;

                if (temp.ToUpper().Equals("Y"))
                {
                    tempC = true;
                }
                else
                {
                    tempC = false;
                }

                ListStates.Add(new State(i, tempA, tempB, tempC));
            }

            return ListStates;
        }
    }
}

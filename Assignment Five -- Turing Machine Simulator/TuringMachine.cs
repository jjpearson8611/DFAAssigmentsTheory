using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace TuringMachineSimulator
{
    class TuringMachine
    {

        //constructors
        public TuringMachine()
        {
            //Default Constructor
            this.States = new List<State>();
            this.Alphabet = new List<string>();
            this.AcceptingStates = new List<State>();
        }



        #region Properties

        //properties
        public int NumberOfStates
        {
            get;
            set;
        }


        /// <summary>
        /// Set of States this will also take care of the transition functions
        /// </summary>
        public List<State> States
        {
            get;
            set; 
        }

        /// <summary>
        /// Blank symbol
        /// </summary>
        public string Blank
        {
            get;
            set;
        }

        /// <summary>
        /// tape alphabet symbols
        /// </summary>
        public List<string> Alphabet
        {
            get;
            set;
        }

        /// <summary>
        /// Set of input symbols
        /// </summary>
        public List<string> Input
        {
            get;
            set;
        }

        /// <summary>
        /// Final or accepting states
        /// </summary>
        public List<State> AcceptingStates
        {
            get;
            set;
        }

        /// <summary>
        /// q0
        /// </summary>
        public State StartingState
        {
            get;
            set;
        }

        #endregion

        #region Methods
        public bool HandleInput(string filePath)
        {
            /*
             * Input should be constructed as follows
             * First line should have the number of states
             * Second line should have the statenames comma seperated
             * Third line is the tape alphabet comma seperated
             * Fourth line is the blank symbol that we will be using
             * fifth line is the input symbols comma seperated
             * Sixth line has the initial state name
             * Seventh line has the accepting or final state names comma seperated
             * From there on it will have the transition functions
             * Each state and its transition will follow the following setup rules
             * 
             * It will start with the state name, have read in letter, write out letter, direction, new state
             * it will have as many as it wants trap states are preferred but may or may not be needed
             * I am currently deciding on that.
             * 
             * If input is read correctly it will return true otherwise false and fix your input
             * 
             */
            try
            {
                StreamReader reader = new StreamReader(filePath);
                int loopCounter = 1;

                while (!reader.EndOfStream)
                {
                    switch (loopCounter)
                    {
                        case 1:
                            loopCounter++;
                            int temp;
                            if (int.TryParse(reader.ReadLine(), out temp))
                            {
                                this.NumberOfStates = temp;
                            }
                            else
                            {
                                return false;
                            }
                        break;
                        case 2:
                            loopCounter++;
                            List<string> states = reader.ReadLine().Split(',').ToList<string>();
                            foreach (var state in states)
                            {
                                State anotherTemp = new State(state);
                                this.States.Add(anotherTemp);

                            }
                        break;
                        case 3:
                            loopCounter++;
                            List<string> line = reader.ReadLine().Split(',').ToList<string>();
                            foreach (var a in line)
                            {
                                this.Alphabet.Add(a);
                            }
                        break;
                        case 4:
                            loopCounter++;
                            this.Blank = reader.ReadLine();
                        break;
                        case 5:
                            loopCounter++;
                            this.Input = reader.ReadLine().Split(',').ToList<string>();
                        break;
                        case 6:
                            loopCounter++;
                            var startingStateString = reader.ReadLine();
                            State tempState = new State();
                            foreach (var e in this.States)
                            {
                                if (string.Compare(e.StateName, startingStateString) == 0)
                                {
                                    tempState = e;
                                }
                            }
                            this.StartingState = tempState;
                        break;
                        case 7:
                            loopCounter++;
                            var lineOfData = reader.ReadLine().Split(',').ToList<string>();

                            foreach (var e in lineOfData)
                            {
                                foreach (var a in this.States)
                                {
                                    if (string.Compare(e, a.StateName) == 0)
                                    {
                                        this.AcceptingStates.Add(a);
                                    }
                                }
                            }
                        break;

                        //this is the part that will get the states and all their data
                        case 8:
                            var deltaString = reader.ReadLine().Split(',').ToList<string>();
                            int pointer = -1;

                            for (int i = 0; i < this.States.Count; i++)
                            {
                                if (string.Compare(States[i].StateName, deltaString[0]) == 0)
                                {
                                    pointer = i;
                                }
                            }

                            this.States[pointer].DirectionList.Add(deltaString[3]);
                            this.States[pointer].InputList.Add(deltaString[1]);
                            this.States[pointer].OutPutList.Add(deltaString[2]);

                            for (int i = 0; i < this.States.Count; i++)
                            {
                                if (string.Compare(States[i].StateName, deltaString[4]) == 0)
                                {
                                    this.States[pointer].NextStateList.Add(this.States[i]);
                                }
                            }


                        break;
                    }
                }
                reader.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool HandleString(string input)
        {
            
            State CurrentState = StartingState;

            input = this.Blank + input;

            bool accepted = false;
            
            //points to the start of the tape
            int pointer = 0;
            string CurrentLetter = string.Empty;
            bool KeepGoing = true;
            string NewLetter = string.Empty;

            while (KeepGoing)
            {
                //we are in our current string
                if(pointer < 0 || pointer >= input.Length)
                {
                    //we need to add a blank before it
                    if(pointer < 0)
                    {
                        //add stuff to the beginning and adjust pointer to be 0
                        while(pointer < 0)
                        {
                            pointer++;
                            input = Blank + input;
                        }
                    }
                    else
                    {
                        //add blanks onto the end
                        while(pointer >= input.Length)
                        {
                            input = input + Blank;
                        }
                    }
                }

                //peel off an input
                CurrentLetter = input.Substring(pointer, 1);

                if (CurrentState.TestFullState(CurrentLetter))
                {
                    NewLetter = CurrentState.GetOutput(CurrentLetter);
                }
                else
                {
                    //we have no where to go are we halting on a good accepting final state or not? 
                    if (this.AcceptingStates.Contains(CurrentState))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                
                //does the string a little at a time could be condensed but was split up for easier debugging
                string temp;

                //get the info up to the one we are at
                temp = input.Substring(0, pointer);

                //update the one that we are at
                temp = temp + NewLetter;

                //get the rest
                temp = temp + input.Substring(pointer + 1, input.Length - pointer - 1);
                
                //put it back so we can use it 
                input = temp;
                
                //get the direction we are traveling adjust pointer when done
                if (string.Compare(CurrentState.GetDirection(CurrentLetter), "R") == 0)
                {
                    pointer++;
                }
                else
                {
                    pointer--;
                }

                //change the state to the next state
                CurrentState = States[States.IndexOf(CurrentState.NextState(CurrentLetter))];
            }

            return accepted;
        }
        #endregion
    }
}

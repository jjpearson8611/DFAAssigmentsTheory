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
        }

        //properties
        public int NumberOfStates
        {
            get;
            set;
        }


        #region Properties
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
        public void HandleInput(string filePath)
        {


        }

        public void HandleString(string input)
        {
            State CurrentState = StartingState;
            
            
            //points to the start of the tape
            int pointer = 0;
            string CurrentLetter = string.Empty;
            bool KeepGoing = true;

            while (KeepGoing)
            {
                //we are in our current string
                if(pointer < 0 && pointer > input.Length)
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
                        while(pointer > input.Length)
                        {
                            input = input + Blank;
                        }
                    }
                }

                //peel off an input
                CurrentLetter = input.Substring(pointer, 1);

                string NewLetter = CurrentState.GetOutput(CurrentLetter);

                //this needs to be tested
                input = input.Substring(0, pointer) + NewLetter + input.Substring(pointer, input.Length - pointer);
                
                //get the direction we are traveling adjust pointer when done
                if (string.Compare(CurrentState.GetDirection(CurrentLetter), "R") == 0)
                {
                    pointer++;
                }
                else
                {
                    pointer--;
                }

                CurrentState = States.IndexOf(CurrentState.NextState());
            }
        }
        #endregion
    }
}

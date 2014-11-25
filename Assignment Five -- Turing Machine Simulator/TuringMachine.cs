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
             * It will start with the state name on its own line
             * then it will have read in letter, write out letter, direction, new state
             * it will have as many as it wants trap states are preferred but may or may not be needed
             * I am currently deciding on that.
             * 
             * If input is read correctly it will return true otherwise false and fix your input
             * 
             */



            return false;
        }

        public bool HandleString(string input)
        {
            State CurrentState = StartingState;

            bool accepted = false;
            
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

                CurrentState = States[States.IndexOf(CurrentState.NextState(CurrentLetter))];
            }

            return accepted;
        }
        #endregion
    }
}

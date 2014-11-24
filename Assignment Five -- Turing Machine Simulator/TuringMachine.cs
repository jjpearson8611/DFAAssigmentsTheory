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
            while (input.Length != 0)
            {
                string CurrentLetter = input.Substring(0, 1);


            }
        }

        public void chomp(string letter)
        {


        }

        #endregion
    }
}

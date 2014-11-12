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

        public TuringMachine(string fileLocation)
        {

        }

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
    }
}

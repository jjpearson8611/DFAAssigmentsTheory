using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3Theory
{
    class State
    {
        public State()
        {
        }

        public State(string Name, string aState, string bState, bool accepting)
        {
            stateName = Name;
            StateA = aState;
            StateB = bState;
            Final = accepting;
        }

        public State(string Name, string aState, State ParmA, string bState, State ParmB, bool accepting)
        {
            stateName = Name;
            StateA = aState;
            NextA = ParmA;
            NextB = ParmB;
            StateB = bState;
            Final = accepting;
        }

        /// <summary>
        /// What is my state number
        /// </summary>
        public string stateName
        {
            get;
            set;
        }

        /// <summary>
        /// if an a is next where do we go
        /// </summary>
        public string StateA
        {
            get;
            set;
        }

        /// <summary>
        /// if a b is next where do we go
        /// </summary>
        public string StateB
        {
            get;
            set;
        }

        public State NextA
        {
            get;
            set;
        }

        public State NextB
        {
            get;
            set;
        }

        /// <summary>
        /// is this a final state
        /// </summary>
        public bool Final
        {
            get;
            set;
        }

        /// <summary>
        /// Figures out what the next state is
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string nextState(char input)
        {
            if (input == 'a')
            {
                return StateA;
            }
            else
            {
                return StateB;
            }
        }

        public override string ToString()
        {
            return " State Number: " + stateName + " Next A: " + StateA + " Next B: " + StateB + " Accepting: " + Final;
        }
    }
}

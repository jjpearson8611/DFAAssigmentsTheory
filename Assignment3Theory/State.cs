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

        public State(int Number, int aState, int bState, bool accepting)
        {
            stateNumber = Number;
            StateA = aState;
            StateB = bState;
            Final = accepting;
        }

        /// <summary>
        /// What is my state number
        /// </summary>
        public int stateNumber
        {
            get;
            set;
        }

        /// <summary>
        /// if a b is next where do we go
        /// </summary>
        public int StateA
        {
            get;
            set;
        }

        /// <summary>
        /// if a b is next where do we go
        /// </summary>
        public int StateB
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
        public int nextState(char input)
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
            return " State Number: " + stateNumber + " Next A: " + StateA + " Next B: " + StateB + " Accepting: " + Final;
        }
    }
}

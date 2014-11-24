using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachineSimulator
{
    class State
    {
        public State()
        {
            //default constructor
        }

        /// <summary>
        /// Takes in a list of how it is supposed to react and reacts accordingly
        /// </summary>
        /// <param name="outputList"></param>
        /// <param name="inputList"></param>
        /// <param name="directionList"></param>
        public State(List<string> outputList, List<string>inputList, List<string> directionList)
        {
            OutPutList = outputList;
            InputList = inputList;
            DirectionList = directionList;
        }


        public List<string> OutPutList
        {
            get;
            set;
        }

        public List<string> DirectionList
        {
            get;
            set;
        }
        
        public List<string> InputList
        {
            get;
            set;
        }


        /// <summary>
        /// given an input return the direction the tape is supposed to go
        /// </summary>
        /// <param name="input">input char</param>
        /// <returns></returns>
        public string GetDirection(string input)
        {
            return DirectionList[InputList.IndexOf(input)];
        }

        /// <summary>
        /// using what was on the machine return what we are to write to the old spot
        /// </summary>
        /// <param name="input">input char from the word</param>
        /// <returns></returns>
        public string GetOutput(string input)
        {
            return OutPutList[InputList.IndexOf(input)];
        }

    }
}

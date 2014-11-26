using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachineSimulator
{
    class State
    {
        //outputlist inputlist direction list and nextstate list are parallel arrays
        public State()
        {
            //default constructor
            //initialize the lists to prevent null reference errors
            this.OutPutList = new List<string>();
            this.InputList = new List<string>();
            this.DirectionList = new List<string>();
            this.NextStateList = new List<State>();
        }

        public State(string Name)
        {
            StateName = Name;
         
            //initialize the lists to prevent null reference errors
            this.OutPutList = new List<string>();
            this.InputList = new List<string>();
            this.DirectionList = new List<string>();
            this.NextStateList = new List<State>();
        }

        #region properites
        public List<string> OutPutList
        {
            get;
            set;
        }

        public string StateName
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

        public List<State> NextStateList
        {
            get;
            set;
        }
        #endregion

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
        /// This should return true if there is a state for the input if there isn't we need to trap
        /// </summary>
        /// <param name="input">input character</param>
        /// <returns></returns>
        public bool TestDirection(string input)
        {
            try
            {
                string Temp = DirectionList[InputList.IndexOf(input)];
                return true;
            }
            catch (ArgumentOutOfRangeException e)
            {
                return false;
            }
        }
        
        /// <summary>
        /// tests all three test methods and returns one bool of them anded together
        /// </summary>
        /// <param name="input">input char</param>
        /// <returns></returns>
        public bool TestFullState(string input)
        {
            return (TestState(input) && TestDirection(input) && TestOutput(input));
        }

        /// <summary>
        /// what is the next state of the turing machine
        /// </summary>
        /// <param name="input">input char</param>
        /// <returns></returns>
        public State NextState(string input)
        {
            return NextStateList[InputList.IndexOf(input)];
        }


        /// <summary>
        /// Tests to see if the next state exsists before using it
        /// </summary>
        /// <param name="input">input char</param>
        /// <returns></returns>
        public bool TestState(string input)
        {
            try
            {
                State temp = NextStateList[InputList.IndexOf(input)];
                return true;
            }
            catch(ArgumentOutOfRangeException e)
            {
                return false;
            }
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

        /// <summary>
        /// Tests to see if the state actually has something to write out
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool TestOutput(string input)
        {
            try
            {
                string temp = OutPutList[InputList.IndexOf(input)];
                return true;
            }
            catch (ArgumentOutOfRangeException e)
            {
                return false;
            }
        }

    }
}

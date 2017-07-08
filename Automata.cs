using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomataTheory
{
    public class DeterministicFiniteAutomata
        
    {
        /*
        TODO: Make Generic
        TODO: Implement Pattern Matching
        TODO: Exception Handeling


    */
        static int StateCount = 0;
        public List<State> States { get; private set; }
        public State CurrentState { get; private set; }
        //public void Match(string input)
        //{
        //    var charArr = input.ToCharArray();
        //    for(int i=0;i<charArr.Length;i++)
        //    {
        //        if()
        //    }
        //}
        public void AddState()
        {

            States.Add(new State(StateCount));
            StateCount++;
        }
        public void Run(string input)
        {
            Console.WriteLine(CurrentState.ToString());
            var charArr = input.ToCharArray();
            foreach (var i in charArr)
            {
                CurrentState = Transition(i);

                Console.WriteLine(CurrentState.ToString());
            }
        }
        public DeterministicFiniteAutomata()
        {
            States = new List<State>();
            AddState();
            AddState();
            CurrentState = GetState(0);
            //We'll now try to initiate the bullshit brand-new FunctionMachine
            //TransitionFunction = new FunctionMachine<State, char, State>();
            TransitionFunction = new FunctionMachine<int, char, int>();
            PopulateTransitionRules();//Absolute hardcode ;-)
        }
        State GetState(int queryId)
        {
            var query = (from state in States
                         where state.Id == queryId
                         select state).FirstOrDefault();
            return query;
        }
        State Transition(char input)
        {
            //actually hardcoded!
            if (CurrentState.Id == 0)
            {
                if (input == '0')
                    return GetState(1);
                else if (input == '1')
                    return GetState(0);
                else
                    throw new Exception("input out of alphabet");
            }
            else if (CurrentState.Id == 1)
            {
                if (input == '0')
                    return GetState(0);
                else if (input == '1')
                    return GetState(1);
                else
                    throw new Exception("input out of alphabet");

            }
            else
                throw new Exception("ERROR!");
        }
        // new transition function
        //public FunctionMachine<State, char, State> TransitionFunction { get; private set; }

        //public void PopulateTransitionRules()//a brand-new way for hardcoding :|
        //{
        //    TransitionFunction.AddMap(new State(0), '0', new State(1));
        //    TransitionFunction.AddMap(new State(0), '1', new State(0));
        //    TransitionFunction.AddMap(new State(1), '0', new State(0));
        //    TransitionFunction.AddMap(new State(1), '1', new State(1));

        //}
        public FunctionMachine<int, char, int> TransitionFunction { get; private set; }

        public void PopulateTransitionRules()//a brand-new way for hardcoding :|
        {
            TransitionFunction.AddMap(0, '0', 1);
            TransitionFunction.AddMap(0, '1', 0);
            TransitionFunction.AddMap(1, '0', 0);
            TransitionFunction.AddMap(1, '1', 1);

        }

        public void Run2(string input)
        {
            Console.WriteLine(CurrentState.ToString());
            var charArr = input.ToCharArray();
            foreach (var i in charArr)
            {
                //CurrentState = TransitionFunction.Invoke(CurrentState,i);
                CurrentState =GetState(TransitionFunction.Invoke(CurrentState.Id, i));

                Console.WriteLine(CurrentState.ToString());
            }
        }
    }
    //public class Alphabet
    //{
    //    List<char> Elements;
    //}
    //Binary strings only
    public class State
    {
        
        //static int LastId = -1;
        public int Id { get; set; }
        //public State()
        //{
        //    LastId++;
        //    Id = LastId;
        //}
        public State()
        {

        }
        public State(int id)
        {
            Id = id;
        }
        public override string ToString()
        {
            return "state " + Id.ToString();
        }
    }

}

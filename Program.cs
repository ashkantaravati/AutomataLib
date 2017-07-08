using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomataTheory
{
    class Program
    {
        static void Main(string[] args)
        {
            DeterministicFiniteAutomata m1 = new DeterministicFiniteAutomata();
            //m1.Run("00110101");
            m1.Run2("00110101");
        }
    }
    
}

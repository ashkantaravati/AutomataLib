using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomataTheory
{
   public class FunctionMachine<TInput,TRelation,TOutput>
    {

        public Dictionary<Tuple<TInput, TRelation>, TOutput> FunctionMap { get; private set; }



       public FunctionMachine()
        {
            FunctionMap = new Dictionary<Tuple<TInput, TRelation>, TOutput>();

        }
        public void AddMap(TInput input,TRelation relation,TOutput output)
        {
            Tuple<TInput, TRelation> key = new Tuple<TInput, TRelation>(input, relation);
            FunctionMap.Add(key, output);
        }

        public TOutput Invoke(TInput input,TRelation relation)
        {
            var queryKey= new Tuple<TInput, TRelation>(input, relation);
            var result = (from x in FunctionMap
                          where x.Key.Equals(queryKey)
                          select x).FirstOrDefault();
            return result.Value;
        }

    }
}

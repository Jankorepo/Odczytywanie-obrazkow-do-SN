using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class InputsAndOutputs
    {
        public List<double> Inputs;
        public List<int> Outputs; //musi być lista bo wyjścia mogą być dwa albo więcej
        public InputsAndOutputs(List<double> inputs, List<int> outputs)
        {
            Inputs = inputs;
            Outputs = outputs;
        }
    }
}

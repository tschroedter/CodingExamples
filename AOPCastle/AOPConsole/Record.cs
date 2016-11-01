namespace AOPConsole
{
    public class Record
    {
        internal Record(double n1,
                        double n2,
                        string operation,
                        double result)
        {
            OperandNumberOne = n1;
            OperandNumberTwo = n2;
            Operation = operation;
            Result = result;
        }

        public double OperandNumberOne { get; private set; }
        public double OperandNumberTwo { get; private set; }
        public string Operation { get; private set; }
        public double Result { get; private set; }

        public override string ToString()
        {
            return string.Format("Record: {0} {1} {2} = {3}",
                                 OperandNumberOne,
                                 Operation,
                                 OperandNumberTwo,
                                 Result);
        }
    }
}
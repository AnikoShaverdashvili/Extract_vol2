// See https://aka.ms/new-console-template for more information



static void StartRunnig()
{
    Evaluation("(1+2)");
    Evaluation("5*4/2");
    Evaluation("((3+5)-6)");
}

static void Evaluation(string input)
{
    var ev = Evaluate(input);
    Console.WriteLine(input + "=" + ev);
}

static double Evaluate(String input)
{
    String set = "(" + input + ")";
    Stack<String> operators = new Stack<String>();
    Stack<Double> values = new Stack<Double>();

    for (int i = 0; i < set.Length; i++)
    {
        String op = set.Substring(i,1);
        if (op.Equals("(")) { }
        else if (op.Equals("+")) operators.Push(op);
        else if (op.Equals("-")) operators.Push(op);
        else if (op.Equals(")"))
        {
            int count = operators.Count;
            while (count > 0)
            {
                String oper = operators.Pop();
                double val = values.Pop();
                if (oper.Equals("+")) val = values.Pop() + val;
                else if (oper.Equals("-")) val= values.Pop() - val;
                else if (oper.Equals("*")) val = values.Pop() * val;

                values.Push(val);

                count--;
            }
        }
        else values.Push(Double.Parse(op));
    }
    return values.Pop();
}

StartRunnig();
using System;
using System.Collections.Generic;
using System.Text;

namespace calcTest
{
    public class Calc
    {
       
        public double Calculate(string expression)
        {   
            Stack<int> stack = new Stack<int>();
            double result = 0;

            if (!expression.Contains("("))
                return double.Parse(expression);

            for(int i=0; i< expression.Length; i++)
            {
                var chr = expression[i];
                if (chr == '(')
                {
                    stack.Push(i);
                }

                if (chr==')')
                {
                    var startIndex = stack.Pop();
                    var subExpression = expression.Substring(startIndex, i - startIndex+1);
                    result = CalculateSimple(subExpression);
                    var newexp = expression.Replace(subExpression, result.ToString());
                    return Calculate(newexp);
                }
            }

            return result;
        }

        private double CalculateSimple(string simpleExpression)
        {
            var numBuffer = "";
            int num = 0;
            var result = 0.0;
            var simpleExp = new TrivialExpression();
            bool isLeft = true;

            for (int i =0; i<simpleExpression.Length; i++)
            {
                var chr = simpleExpression[i];
                if (chr == '(')
                    continue;
                if (int.TryParse(chr.ToString(), out num))
                {
                    numBuffer += chr;
                }
                else
                {
                    if (isLeft)
                    {
                        isLeft = false;
                        switch (chr)
                        {
                            case '+':
                                simpleExp.Operator = MathOperator.Plus;
                                break;
                            case '-':
                                simpleExp.Operator = MathOperator.Minus;
                                break;
                            case '*':
                                simpleExp.Operator = MathOperator.Multiply;
                                break;
                            case '/':
                                simpleExp.Operator = MathOperator.Divide;
                                break;
                        }

                        simpleExp.Left = double.Parse(numBuffer);
                        numBuffer = "";
                    }
                    else
                    {
                        simpleExp.Right = int.Parse(numBuffer);
                        result = simpleExp.Calculate();
                        if (i < simpleExpression.Length - 1)
                            return CalculateSimple("("+result + simpleExpression.Substring(i, simpleExpression.Length - i));
                    }
                }
            }
            return result;
        }


    }
}

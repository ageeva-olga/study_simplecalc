namespace calcTest
{
    public class TrivialExpression
    {
        public double Left { get; set; }
        public double Right { get; set; }
        public MathOperator Operator { get; set; }

        public double Calculate()
        {
            switch (Operator)
            {
                case MathOperator.Plus:
                    return Left + Right;

                case MathOperator.Minus:
                    return Left - Right;

                case MathOperator.Multiply:
                    return Left * Right;

                case MathOperator.Divide:
                    return Left / Right;

                default:
                    return 0;
            }
        }
    }
}
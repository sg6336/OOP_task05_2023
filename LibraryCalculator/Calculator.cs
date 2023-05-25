using System;

namespace LibraryCalculator
{
    public class Calculator
    {
        public static string Calculate(string expression)
        {
            try
            {
                expression = expression.Replace(" ", ""); // Remove whitespaces from the expression

                // Evaluate the expression using math priorities
                double result = EvaluateExpression(expression);
                return result.ToString();
            }
            catch (DivideByZeroException)
            {
                return "Exception. Divide by zero.";
            }
            catch
            {
                return "Exception. Wrong input.";
            }
        }

        private static double EvaluateExpression(string expression)
        {
            double result = 0;
            char currentOperator = '+';
            int i = 0;

            while (i < expression.Length)
            {
                char currentChar = expression[i];

                if (currentChar == '*' || currentChar == '/')
                {
                    currentOperator = currentChar;
                }
                else if (currentChar == '+' || currentChar == '-')
                {
                    currentOperator = currentChar;
                }
                else
                {
                    int start = i;
                    while (i < expression.Length && Char.IsDigit(expression[i]))
                    {
                        i++;
                    }

                    int number = Int32.Parse(expression.Substring(start, i - start));

                    switch (currentOperator)
                    {
                        case '*':
                            result *= number;
                            break;
                        case '/':
                            result /= number;
                            break;
                        case '+':
                            result += number;
                            break;
                        case '-':
                            result -= number;
                            break;
                    }

                    continue;
                }

                i++;
            }

            return result;
        }
    }
}
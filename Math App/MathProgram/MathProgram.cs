using System;
using MathTyler;

namespace Math
{
    public class MathProgram
    {
        bool loopRun = true;
        public MathProgram()
        {
            Run();
            
        }

        private void Run()
        {
            int counter = 1;
            while (loopRun)
            {
                if (counter == 1)
                    Console.WriteLine("Welcome to my Math program. \nWhat kind of math do you want to do?\nYou can enter *, /, +, or - to perform operations. Or you can type Done when you are finsihed.");
                else
                    Console.WriteLine("If you would like to continue, just enter another operation you would like to perform, otherwise type \"Done\"."); 
                
                    
                string operation;
                operation = Console.ReadLine();
                bool inputError = inputErrors(operation);
                operation = CheckOperationInput(inputError, operation);
                operationSelectionAndExecution(operation);
                counter++;
            }
            
        }

        private void operationSelectionAndExecution(string operation)
        {
            MathT MT = new MathT();
            double num1, num2;
            switch (operation)
            {
                case "+":
                    Console.WriteLine("Please enter the numbers you would like to find the sum of.");
                    AcceptPairOfOperands(out num1, out num2);
                    Console.WriteLine($"{MT.addition(num1, num2)} is the sum of {num1} and {num2}.");
                    break;

                case "-":
                    Console.WriteLine("Please enter the numbers you would like to find the difference of.");
                    AcceptPairOfOperands(out num1, out num2);
                    Console.WriteLine($"{(float)(MT.subtraction(num1, num2))} is the difference between {num1} and {num2}.");
                    break;

                case "*":
                    Console.WriteLine("Please enter the numbers you would like to find the product of.");
                    AcceptPairOfOperands(out num1, out num2);
                    Console.WriteLine($"{MT.multiplication(num1, num2)} is the product of {num1} and {num2}.");
                    break;

                case "/":
                    Console.WriteLine("Please enter the two operands you would like to get the quotient of.");
                    do
                    {
                        AcceptPairOfOperands(out num1, out num2);
                        if (num2 != 0)
                        {
                            break;
                        }
                        Console.WriteLine("The second number can't be zero.");
                    } while (num2 == 0);

                    Console.WriteLine($"{MT.division(num1, num2)} is the quotient of {num1} and {num2}");
                    break;

                case "Done":
                    
                    Console.WriteLine("Thank you!");
                    loopRun = false;
                    break;

                case "done":

                    Console.WriteLine("Thank you!");
                    loopRun = false;
                    break;
            }
        }

        
        private void checkNumber(string input, out double number)
        {
            while (!(double.TryParse(input, out number)))
            {
                Console.WriteLine("You need to enter a number.");
                input = Console.ReadLine();
            }
        }

        private bool inputErrors(string input)
        {
            if (input == "+" || input == "-" || input == "*" || input == "/" || input == "Done" || input == "done")
                return false;
            
            else
                return true;
        }

        private string CheckOperationInput(bool inputError, string operation)
        {
            while (inputError)
            {
                Console.WriteLine("You need to input +, -, /, *, or Done.");
                operation = Console.ReadLine();
                inputError = inputErrors(operation);
            }
            return operation;

        }

        private double acceptNumericInput()
        {
            string input = Console.ReadLine();
            double doubleOperand;
            checkNumber(input, out doubleOperand);
            return doubleOperand;
        }

        private void AcceptPairOfOperands(out double operand1, out double operand2)
        {
            Console.WriteLine("Please enter the first operand. ");
            operand1 = acceptNumericInput();
            Console.WriteLine("Please enter the second operand. ");
            operand2 = acceptNumericInput();
        }

        
    }
}

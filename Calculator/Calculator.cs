using System.ComponentModel.DataAnnotations;

class Calculator
{
    public static double DoOperation(double num1, double num2, string op)
    {
        double result = double.NaN; // Default value is "not-a-number" if an operation, such as division, could result in an error.

        // Use a switch statement to do the math.
        switch (op)
        {
            case "a":
                result = num1 + num2;
                break;
            case "s":
                result = num1 - num2;
                break;
            case "m":
                result = num1 * num2;
                break;
            case "d":
                // Ask the user to enter a non-zero divisor.
                if (num2 != 0)
                {
                    result = num1 / num2;
                }
                break;
            // Return text for an incorrect option entry.
            default:
                break;
        }
        return result;
    }

    public static double DoOperation1(double num3, double num2, string opn)
    {
        double result = double.NaN; // Default value is "not-a-number" if an operation, such as division, could result in an error.

        // Use a switch statement to do the math.
        switch (opn)
        {
            case "a":
                result = num3 + num2;
                break;
            case "s":
                result = num3 - num2;
                break;
            case "m":
                result = num3 * num2;
                break;
            case "d":
                // Ask the user to enter a non-zero divisor.
                if (num2 != 0)
                {
                    result = num3 / num2;
                }
                break;
            // Return text for an incorrect option entry.
            default:
                break;
        }
        return result;
    }

}

class Program
{
    static int count = 0;
    static List<string> calcHistory = new List<string>();

    static void Main(string[] args)
    {
        
        bool endApp = false;
        // Display title as the C# console calculator app.
        Console.WriteLine("Console Calculator in C#\r");
        Console.WriteLine("------------------------\n");



        while (!endApp)
        {
            
            count++;
            // Declare variables and set to empty.
            string numInput1 = "";
            string numInput2 = "";
            double result = 0;


           


            // Ask the user to type the first number.
            Console.Write("Type a number, and then press Enter: ");
                numInput1 = Console.ReadLine();
            

           
            double cleanNum1 = 0;
            while (!double.TryParse(numInput1, out cleanNum1))
            {
                Console.Write("This is not valid input. Please enter an integer value: ");
                numInput1 = Console.ReadLine();
            }

            // Ask the user to type the second number.
            Console.Write("Type another number, and then press Enter: ");
            numInput2 = Console.ReadLine();

            double cleanNum2 = 0;
            while (!double.TryParse(numInput2, out cleanNum2))
            {
                Console.Write("This is not valid input. Please enter an integer value: ");
                numInput2 = Console.ReadLine();
            }

            // Ask the user to choose an operator.
            Console.WriteLine("Choose an operator from the following list:");
            Console.WriteLine("\ta - Add");
            Console.WriteLine("\ts - Subtract");
            Console.WriteLine("\tm - Multiply");
            Console.WriteLine("\td - Divide");
            Console.Write("Your option? ");

            string op = Console.ReadLine();

            try
            {
                result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
                if (double.IsNaN(result))
                {
                    Console.WriteLine("This operation will result in a mathematical error.\n");
                    
                }
                else
                {
                    Console.WriteLine("Your result: {0:0.##}\n", result);
                    calcHistory.Add($"{cleanNum1} {op} {cleanNum2} = {result}");
                    //calcHistory.Add(string.Format("{0} {1} {2} = {3:0.##}", cleanNum1, op, cleanNum2, result));
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
            }

            Console.WriteLine("------------------------\n");

            Console.WriteLine("Calculator has been used " + count + " time(s)");

            Console.WriteLine("Calculation history:");
             foreach(string calc in calcHistory)
            {
                Console.WriteLine(calc);
            }

            Console.WriteLine("Clear calculation history? (Y/N)");

            string clearHistory = Console.ReadLine();
            if (clearHistory == "y")
            {
                calcHistory.Clear();
                Console.WriteLine("Calculation history cleared");
            }
            else
            {
                Console.WriteLine("Ok!");

                if (calcHistory.Count > 0)

                {
                    Console.WriteLine("Would you like to use a result from calcHistory list? (y/n)");
                    string useResult = Console.ReadLine();

                    if (useResult == "y")
                    {
                        Console.WriteLine("Here is the history list:");
                        for (int i = 0 + 1; i < calcHistory.Count; i++)
                        {
                            Console.WriteLine(i + 1 + ")" + calcHistory[i]);
                            
                            //pick the result you want to use
                            Console.WriteLine("Enter the index of the result you want to use");
                          int Index = Convert.ToInt32( Console.ReadLine());

                            double cleanNum3 = 0;
                            while (!double.TryParse(calcHistory[Index], out cleanNum3 ))
                            {
                                Console.Write("This is not valid input. Please enter an integer value: ");
                                 Index = Convert.ToInt32(Console.ReadLine()); ;
                            }



                            // Ask the user to choose an operator.
                            Console.WriteLine("Choose an operator from the following list:");
                            Console.WriteLine("\ta - Add");
                            Console.WriteLine("\ts - Subtract");
                            Console.WriteLine("\tm - Multiply");
                            Console.WriteLine("\td - Divide");
                            Console.Write("Your option? ");

                            string opn = Console.ReadLine();

                            try
                            {
                                result = Calculator.DoOperation1(cleanNum3, cleanNum2, opn);
                                if (double.IsNaN(result))
                                {
                                    Console.WriteLine("This operation will result in a mathematical error.\n");

                                }
                                else
                                {
                                    Console.WriteLine("Your result: {0:0.##}\n", result);
                                    
                                    //calcHistory.Add(string.Format("{0} {1} {2} = {3:0.##}", cleanNum1, op, cleanNum2, result));
                                }

                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                            }


                        }

                                           

                    }

                }

            }


            // Wait for the user to respond before closing.
            Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
            if (Console.ReadLine() == "n")
            {               
              endApp = true;
            }

            Console.WriteLine("\n"); // Friendly linespacing.
        }
        return;
    }
}
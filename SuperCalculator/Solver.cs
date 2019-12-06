using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperCalculator
{
    public class Solver
    {
        static private string MathSolver(string firstval,string secondVal,string symbol)
        {
            if (symbol == "+")
            {
                double result = Convert.ToDouble(firstval) + Convert.ToDouble(secondVal);
                return result.ToString();
            }
            if (symbol == "-")
            {
                double result = Convert.ToDouble(firstval) - Convert.ToDouble(secondVal);
                return result.ToString();
            }
            if (symbol == "*")
            {
                double result = Convert.ToDouble(firstval) * Convert.ToDouble(secondVal);
                return result.ToString();
            }
            if (symbol == "/")
            {
                double result = Convert.ToDouble(firstval) / Convert.ToDouble(secondVal);
                return result.ToString();
            }
            return "not done yet";
        }
        
        static public string MultiplyAndDivide(string input)
        {
            int counter = 0;
            string result = "";
            string firstSign = "";
            string secondSign = "";
            string firstVal = "";
            string secondVal = "";
            string lastSymbol = "";
            bool sighFound = false;
            bool secondSignFound = false;
            bool signFoundInThisCycle = false;


            signFoundInThisCycle = false;
            foreach (char character in input)
            {
                counter++;
                signFoundInThisCycle = false;
                if (lastSymbol == "" && character == '-')
                {
                    firstVal += character;
                    lastSymbol = "";
                    lastSymbol += character;
                    continue;

                }
                if (Validation.MathSymbols(lastSymbol) && character == '-')
                {
                    secondVal += character;
                    lastSymbol = "";
                    lastSymbol += character;
                    continue;

                }
                lastSymbol = "";
                lastSymbol += character;
                if (Validation.MathSymbols(character.ToString()))
                {
                    if (sighFound)
                    {
                        secondSign += character;
                        signFoundInThisCycle = true;
                        secondSignFound = true;
                        
                    }
                    else if (!sighFound)
                    {
                        firstSign += character;
                        signFoundInThisCycle = true;
                        sighFound = true;
                    }
                }
                if (sighFound&&!signFoundInThisCycle)
                {
                    secondVal += character;
                }
                else if(!sighFound && !signFoundInThisCycle)
                {
                    firstVal += character;
                }
                if (secondSignFound)
                {
                    if (firstSign == "+" || firstSign == "-")
                    {
                        result += firstVal;
                        result += firstSign;
                        

                        firstVal = "";
                        firstSign = "";
                        firstVal += secondVal;
                        firstSign += secondSign;
                        secondVal = "";
                        secondSign = "";
                        secondSignFound = false;
                    }
                    else if(firstSign == "/" || firstSign == "*")
                    {
                        firstVal = Validation.ValidateAndEdit(firstVal);
                        secondVal = Validation.ValidateAndEdit(secondVal);
                        firstVal = Solver.MathSolver(firstVal, secondVal, firstSign);
                        firstSign = ""; 
                        firstSign += secondSign;
                        secondVal = "";
                        secondSign = "";
                        secondSignFound = false;
                    }
                }
                if (counter == input.Length)
                {
                    if (firstSign == "+" || firstSign == "-")
                    {
                        result += firstVal + firstSign + secondVal;
                    }
                    else if (firstSign == "/" || firstSign == "*")
                    {
                        firstVal = Validation.ValidateAndEdit(firstVal);
                        secondVal = Validation.ValidateAndEdit(secondVal);
                        result += Solver.MathSolver(firstVal, secondVal, firstSign);
                    }
                    else result += firstVal;
                }
            }

            


            return result;
        }
        static public string SumAndMinusFinder(string input)
        {
            int counter = 0;
            string symbol = "";
            bool symbolFound = false;
            string firstVar = "";
            string secondVar = "";
            string lastSymbol = "";
            input = BigNumberEditer(input);
            foreach (char character in input)
            {
                counter++;
                if (lastSymbol == "" && character == '-')
                {
                    firstVar += character;
                    lastSymbol = "";
                    lastSymbol += character;
                    continue;

                }
                if ((lastSymbol == "-" || lastSymbol == "+")&&character=='-')
                {
                    secondVar += character;
                    lastSymbol = "";
                    lastSymbol += character;
                    continue;

                }
                lastSymbol = "";
                lastSymbol += character;
                if(symbolFound&&(character == '+' || character == '-'))
                {
                    firstVar = Validation.ValidateAndEdit(firstVar);
                    secondVar = Validation.ValidateAndEdit(secondVar);
                    firstVar = Solver.MathSolver(firstVar, secondVar, symbol);
                    secondVar = "";
                    symbol = "";
                    symbol += character;
                    continue;

                }
                if (symbolFound)
                {
                    secondVar += character;
                }
               
                if (character == '+'||character == '-')
                {
                    symbolFound = true;
                    symbol += character;
                    continue;
                }
                if (!symbolFound)
                {
                    firstVar += character;
                }
                if (counter == input.Length&&secondVar!="")
                {
                    firstVar = Validation.ValidateAndEdit(firstVar);
                    secondVar = Validation.ValidateAndEdit(secondVar);
                    firstVar = Solver.MathSolver(firstVar, secondVar, symbol);
                }
            }
            return firstVar;
               
        }
        static public string BigNumberEditer(string input)
        {
            string result = "";
            string lastSymbol = "";
            foreach(char character in input){
                if (lastSymbol == "E")
                {
                    
                }
                else
                {
                    result += character;
                }
                lastSymbol = character.ToString();  
            }
            return result;
        }
        static public string RemoveBrackets(string input)
        {
            bool bracketFound = false;
            int bracketCounter = 0;
            string output = "";
            string result = "";
            foreach(char character in input)
            {
               
                if (character == ')')
                {
                    bracketCounter -= 1;
                }

                if (bracketCounter == 0 && bracketFound)
                {
                    bracketFound = false;
                    result+= Solver.RemoveBrackets(output);
                    output = "";
                    continue;
                }
                if (bracketFound)
                {
                    output += character;
                }
                if (character == '(')
                {
                    bracketFound = true;
                    bracketCounter += 1;
                }
                if (!bracketFound)
                {
                    if (character == '-')
                    {
                        result += character + "1" + "*";
                    }
                    else
                        result += character;
                }


            }
            return Solver.SumAndMinusFinder(Solver.MultiplyAndDivide(result));
        }
    }
}

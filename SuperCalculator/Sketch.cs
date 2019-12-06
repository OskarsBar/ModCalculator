/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperCalculator
{
    class Sketch
    {
        counter++;
                if (lastSymbol == "" && character == '-')
                {
                    firstVar += character;
                    lastSymbol = "";
                    lastSymbol += character;
                    continue;

                }
                if ((lastSymbol == "*" || lastSymbol == "/" || lastSymbol == "-" || lastSymbol == "+") && character == '-')
                {
                    secondVar += character;
                    lastSymbol = "";
                    lastSymbol += character;
                    continue;

                }
lastSymbol = "";
                lastSymbol += character;
                if (symbolFound && (character == '*' || character == '/' || character == '+' || character == '-'))
                {
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

                if (character == '*' || character == '/'|| character == '+' || character == '-')
                {
                    if (character == '*' || character == '/')
                    {
                        symbolFound = true;
                        symbol += character;
                        continue;
                    }
                    if (character == '+' || character == '-')
                    {

                    }
                }
                if (!symbolFound)
                {
                    firstVar += character;
                }
                if (counter == input.Length && secondVar != "")
                {
                    firstVar = Solver.MathSolver(firstVar, secondVar, symbol);
                }
    }
}
*//*
 foreach (char character in input)
            {
                counter++;
                justFound = false;
                if (character == '*' || character == '/' || character == '+' || character == '-')
                {
                    if (character == '*' || character == '/')
                    {
                        neededSymbolFound = true;
                        symbolFound = true;
                        symbol = "";
                        symbol += character;
                        justFound = true;
                        if (firstSymbolFound)
                        {
                            nextSymbolFound = true;
                        }
                        firstSymbolFound = true;

                    }
                    if (character == '+' || character == '-')
                    {
                        neededSymbolFound = false;
                        symbolFound = true;
                        symbol = "";
                        symbol += character;
                        justFound = true;
                        if (firstSymbolFound)
                        {
                            nextSymbolFound = true;
                        }
                        firstSymbolFound = true;
                    }
                }
                if (neededSymbolFound&& !justFound)
                {
                    secondVar += character;
                }
                else if (!neededSymbolFound&& !justFound)
                {
                    firstVar += character;
                }

                if (neededSymbolFound && nextSymbolFound &&(character == '*' || character == '/' || character == '+' || character == '-'))
                {
                    
                    if (character == '-' || character == '+')
                    {
                        result += Solver.MathSolver(firstVar, secondVar, symbol);
                        result += symbol;
                        firstVar = "";
                        secondVar = "";
                        symbol = "";
                        firstSymbolFound = false;
                        nextSymbolFound = false;
                        neededSymbolFound = false;
                        continue;
                    }
                    if (character == '*' || character == '/')
                    {
                        
                        firstVar= Solver.MathSolver(firstVar, secondVar, symbol);
                        
                        secondVar = "";
                        symbol = "";
                        symbol += character;
                        neededSymbolFound = true;
                        continue;
                    }
                }
                if (input.Length == counter && secondVar == "")
                {
                    result += firstVar;
                }
                else if (input.Length == counter && secondVar != "")
                {
                    result += Solver.MathSolver(firstVar, secondVar, symbol);
                }*/
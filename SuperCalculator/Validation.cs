using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperCalculator
{
    public class Validation
    {
        public static bool ValidBrackets(string input)
        {
            bool validBracketCount = true;
            int bracketCounter = 0;
            foreach(char character in input)
            {
                if (character == '(')
                    bracketCounter++;
                if (character == ')')
                    bracketCounter--;
                if (bracketCounter < 0)
                    validBracketCount = false;
            }
            return validBracketCount;
        }
        public static bool MathSymbols(string input)
        {
            if(input == "-" || input == "+" || input == "/" || input == "*")
            {
                return true;
            }
            return false;
        }
        public static bool ValidFormulaName(string input)
        {
            foreach(char character in input)
            {
                if (!Char.IsLetter(character))
                {
                    MessageBox.Show("Only letters in formula Name");
                    return false;
                }
            }
            return true;
        }
        public static bool ValidFormulaSymbols(string input)
        {
            foreach(char character in input)
            {
                
                if (!MathSymbols(character.ToString()) && !Char.IsLetterOrDigit(character) && character != '.' && character != '(' && character != ')')
                {
                    return false;
                }
            }
            return true;
        }
        public static bool ValidFormula(string input)
        {
            bool result = true;
            if (!ValidBrackets(input))
            {
                MessageBox.Show("Invalid barcket placement");
                result = false;
            }
            if (!ValidFormulaSignPlacement(input))
            {
                MessageBox.Show("Invalid Sign placement");
                result = false;
            }
            if (!ValidFormulaSymbols(input))
            {
                MessageBox.Show("In Formula use only +-*/. digits and letters");
                result = false;
            }
            return result;
        }
        static public string UnknowReplacer(string input)
        {

            double helpDouble;
            string helpString = Interaction.InputBox("Please input variable (" + input + ") digits only or (" + input + ") will be replace by 1", "Variable not found", "variable");
            if (Double.TryParse(helpString, out helpDouble))
            {
                return helpString;
            }
            else
            {
                return "1";
            }
        }
        public static bool ValidFormulaSignPlacement(string input)
        {
            bool validFormula = true;
            string lastVal = "";
            int counter = 0;
            foreach(char character in input)
            {
                counter++;
                if(lastVal==""&&(character=='*'|| character == '/'|| character == '+'))
                {
                    validFormula = false;
                }
                if ((lastVal == "*"|| lastVal == "/"|| lastVal == "+")
                    &&((character == '*' || character == '/' || character == '+')))
                {
                    validFormula = false;
                }
                if((lastVal == "*" || lastVal == "/" || lastVal == "+") && character == ')')
                {
                    validFormula = false;
                }
                if(lastVal=="("&&((character == '*' || character == '/' || character == '+')))
                {
                    validFormula = false;
                }
                if (counter == input.Length && (character == '*' || character == '/' || character == '+'))
                {
                    validFormula = false;
                }
                lastVal = "";
                lastVal += character;
            }
            return validFormula;
        }
        
        static public string ValidateAndEdit(string input)
        {

            double helpDouble;
            if (Double.TryParse(input, out helpDouble))
            {
                return input;
            }
            else
            {
                string helpString = Interaction.InputBox("Please replace variable (" + input + ") with digits only or (" + input + ") will be replace by 1", "Invalid value", "variable");
                if (Double.TryParse(helpString, out helpDouble))
                {
                    return input;
                }
                else
                {
                    return "1";
                }
                
            }
        }
    }
}

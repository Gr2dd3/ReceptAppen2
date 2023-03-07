
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReceptAppen2.Components
{
    internal class Validation : IValidation
    {
        // STEG 1
        public bool IsValidated(string socialSecurityNr, string passWord)
        {
            bool isValid = false;
            bool correctTypeOfPassWord = false;
            bool isASocialSecurityNr = false;

            // Validation logic here

            // TRY Social Security Number
            if (GetRightSocialNr(socialSecurityNr) is true)
            {
                isASocialSecurityNr = true;
            }

            // TRY Password
            if (GetRightTypeOfPassword(passWord) is true)
            {
                correctTypeOfPassWord = true;
            }



            // Summary
            if (isASocialSecurityNr is true && correctTypeOfPassWord is true)
            {
                isValid = true;
            }
            else
            {
                isValid = false;
            }
            return isValid;
        }


        private static MatchCollection GetRegex(int nrOfDigits, string pattern)
        {
            Regex reg = new Regex("^\\d" + "{" + nrOfDigits + "}$");


            if (pattern is not null)
            {
                MatchCollection matches = reg.Matches(pattern);
                return matches;
            }
            else
            {
                MatchCollection matches = reg.Matches("0");
                return matches;
            }


        }
        private static bool GetRightTypeOfPassword(string passWord)
        {
            bool isRightTypeOfPassWord = false;

            MatchCollection matches = GetRegex(6, passWord);

            if (matches.Count == 1)
            {
                isRightTypeOfPassWord = true;
            }
            else
            {
                isRightTypeOfPassWord = false;
            }

            return isRightTypeOfPassWord;
        }
        private static bool GetRightSocialNr(string socialSecurityNr)
        {
            // Luhn Algorithm
            bool isASocialSecurityNr = false;

            MatchCollection matches = GetRegex(12, socialSecurityNr);

            if (matches.Count == 1)
            {
                int sum = 0;

                string resultToString = matches[0].Value.ToString();
                char[] charNumbers = resultToString.ToCharArray();

                int lastDigit = int.Parse(charNumbers[charNumbers.Length - 1].ToString());

                var charList = charNumbers.ToList();

                //int i = charList.Count - 1;

                for (int i = charList.Count - 1; i >= 2; i--)
                {
                    int.TryParse(charList[i].ToString(), out int nr);
                    // Ojämna index
                    if (i % 2 == 0)
                    {
                        nr = nr * 2;
                        if (nr > 9)
                        {
                            List<char> twoNr = nr.ToString().ToList();
                            sum += (int.Parse(twoNr[0].ToString()) + int.Parse(twoNr[1].ToString()));
                        }
                        else
                        {
                            sum += nr;
                        }
                    }
                    else
                    {
                        sum += nr;
                    }
                }
                int result = sum % 10;
                // add check for month and date in if
                if (result == 0)
                {
                    isASocialSecurityNr = true;
                }
                else
                {
                    isASocialSecurityNr = false;
                }
            }
            else
            {
                isASocialSecurityNr = false;
            }

            return isASocialSecurityNr;
        }
    }
}

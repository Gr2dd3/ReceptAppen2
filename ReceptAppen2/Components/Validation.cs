namespace ReceptAppen2.Components
{
    internal class Validation : IValidation
    {
        private delegate bool MyDelegate(bool one, bool two);


        public bool IsValidated(string socialSecurityNr, string passWord)
        {
            bool correctTypeOfPassWord = false;
            bool isASocialSecurityNr = false;
            MyDelegate validate = GetBool;

            if (GetRightSocialNr(socialSecurityNr))
            {
                isASocialSecurityNr = true;
            }

            if (GetRightTypeOfPassword(passWord))
            {
                correctTypeOfPassWord = true;
            }

            return validate(isASocialSecurityNr, correctTypeOfPassWord);
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
            bool isASocialSecurityNr = false;

            MatchCollection matches = GetRegex(12, socialSecurityNr);

            if (matches.Count == 1)
            {
                int sum = 0;
                string resultToString = matches[0].Value.ToString();
                char[] charNumbers = resultToString.ToCharArray();
                int lastDigit = int.Parse(charNumbers[charNumbers.Length - 1].ToString());
                var charList = charNumbers.ToList();

                for (int position = charList.Count - 1; position >= 2; position--)
                {
                    int.TryParse(charList[position].ToString(), out int digitInSocSecNr);
                    if (position % 2 == 0)
                    {
                        digitInSocSecNr *= 2;
                        if (digitInSocSecNr > 9)
                        {
                            List<char> digitInSocSecNrResult = digitInSocSecNr.ToString().ToList();
                            sum += (int.Parse(digitInSocSecNrResult[0].ToString()) + int.Parse(digitInSocSecNrResult[1].ToString()));
                        }
                        else
                        {
                            sum += digitInSocSecNr;
                        }
                    }
                    else
                    {
                        sum += digitInSocSecNr;
                    }
                }
                int result = sum % 10;

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

        private static bool GetBool(bool checkSocialSecurityNr, bool checkPassword)
        {
            bool isValid;

            if (checkSocialSecurityNr is true && checkPassword is true)
            {
                isValid = true;
            }
            else
            {
                isValid = false;
            }
            return isValid;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace program8
{
    
    public abstract class CreditCard
    {
        private string cardNum;
        private int expMM, expYY;

        public abstract bool IsDiner(string card);
        public abstract bool isMaster(string card);

        public CreditCard(string cc, int month, int year)
        {
            cardNum = cc;
            expMM = month;
            expYY = year;
        }

        public bool IsValidCheckSum()
        {
            bool result = true;
            int sum = 0;
            int multipler = 2;
            int strLen = cardNum.Length;
            for(int i = 0; i < strLen; i++)
            {
                string digit = cardNum.Substring(i, 1);
                int currProduct = Int32.Parse(digit) * multipler;
                if(currProduct >= 10)
                {
                    sum += (currProduct % 10) + 1;
                }
                else
                {
                    sum += currProduct;
                }
                if(multipler == 2)
                {
                    multipler--;
                }
                else
                {
                    multipler++;
                }                
            }
            if ((sum % 10) != 0)
            {
                result = false;
            }
            return result;
        }

        public bool IsExpDtValid()
        {            
            DateTime now = DateTime.Now;
            string format = "M yy";
            string[] info = now.ToString(format).Split(' ');
            int mm = Int32.Parse(now.ToString(info[0]));
            int yy = Int32.Parse(now.ToString(info[1]));
            if(expYY > yy)
            {
                return true;
            }
            else if(yy == expYY)
            {
                if(expMM > mm)
                {
                    return true;
                }
                else if(mm == expMM)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            
        }

        public bool HasValidChars()
        {
           string validChars = "0123456789";
           bool result = true;
           foreach (char c in cardNum)
           {
                if(!validChars.Contains(c))
                {
                    return !result;
                }
           }
            return result;
        }

        public bool IsValidPrefix()
        {
            string prefix = cardNum.Substring(0, 1);
            string nextChar = cardNum.Substring(1, 1);
            string validChars = "";
            if(isMaster(cardNum))
            {
                validChars = "12345";
            }
            else if (IsDiner(cardNum))
            {
                validChars = "068";
            }
            else
            {
                if(prefix == "4")
                return true;
            }
            if(validChars.IndexOf(nextChar) >= 0 )
            {
                return true;
            }
            else
            {
                return false;
            }    
        }

        public bool IsNumOfDigitsValid()
        {
            if(!IsDiner(cardNum))
            {
                if(!isMaster(cardNum))
                {
                    if(cardNum.Length == 13 || cardNum.Length == 16)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if(cardNum.Length == 16)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                if(cardNum.Length == 14)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }            
        }

        public bool IsAccountInGoodStand()
        {
            return true;
        }

        public bool IsValid()
        {
            if(!IsExpDtValid())
            {
                Console.WriteLine("Invalid Exp Dt.");
                return false;
            }
            if(!IsNumOfDigitsValid())
            {
                Console.WriteLine("Invalid Number of Digits");
                return false;
            }
            if(!IsValidPrefix())
            {
                Console.WriteLine("Invalid Prefix");
                return false;
            }
            if(!HasValidChars())
            {
                Console.WriteLine("Invalid Characters");
                return false;
            }
            if(!IsValidCheckSum())
            {
                Console.WriteLine("Invalid Check Sum");
                return false;
            }
            if(!IsAccountInGoodStand())
            {
                Console.WriteLine("Account is Inactive/Revoked/Over the Limit");
                return false;
            }
            return true;
        }


    }
}
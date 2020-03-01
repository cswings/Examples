using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace program8
{
    public class VisaCard : CreditCard
    {
        public VisaCard(string cc, int month, int year) : base(cc, month, year)
        {
            
        }

        public override bool IsDiner(string card)
        {
            if(card[0] == '3')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool isMaster(string card)
        {
            if(card[0] == '5')
            {
                return true;
            }
            else
            {
                return false;
            }
        }    
    }
}
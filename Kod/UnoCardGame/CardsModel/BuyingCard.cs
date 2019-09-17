using System;
namespace Cards
{
    public class BuyingCard : Card
    {

        public BuyingCard( String number, String color, int buyingNumber):base(number,color)
        {
            base.Buy = buyingNumber;
            base.Type = "BuyingCard";
        }
    }
}
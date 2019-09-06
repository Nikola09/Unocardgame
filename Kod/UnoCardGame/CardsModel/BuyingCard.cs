using System;
namespace Cards
{
    public class BuyingCard : Card
    {
        public int BuyingNumber { get; set; }

        public BuyingCard()
        {

        }

        public BuyingCard( String number, String color, int buyingNumber):base(number,color)
        {
            base.buy = buyingNumber;
            this.BuyingNumber = buyingNumber;
        }

        public override string Special()
        {
            return "BuyingCard"; 
        }
    }
}
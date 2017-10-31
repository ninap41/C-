using System.Collections.Generic;

namespace ConsoleApplication {

    public class Deck{
        private List<Card> cards; //create the list of cards from other.

        public Deck(){
            cards = new List<Card>();
            string[] suits = new string[4] {"Hearts", "Clubs", "Spades", "Diamonds"};
            foreach(string suit in suits){
                for(int val=1; val <= 13; val++){
                    cards.Add(new Card(suit,val));


                }

            }
        }
        public override string ToString() {
            string info = "";
            foreach(Card card in cards) {
                info += card + "\n";
            }
            return info;
        }
    }
}

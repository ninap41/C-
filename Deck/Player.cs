using System.Collections.Generic;

namespace ConsoleApplication{
    public class Player{

        public string name;
        private List<Card> hand;

        public Player() {
            hand.Add(new Card("cool",2));
        }
    }



}
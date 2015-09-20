using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace geiko.DZ9.Entities
{
    /// <summary>
    /// This class represents a casino table for playing to card game - "Black Jack" or "21".
    /// </summary>
    [Serializable, DataContract]
    public class Table : ITable
    {
        #region Properties
        /// <summary>
        /// Minimal permissible bet.
        /// </summary>
        [DataMember]
        public int MinBet { get; set; }

        /// <summary>
        /// Maximal permissible bet.
        /// </summary>
        [DataMember]
        public int MaxBet { get; set; }

        /// <summary>
        /// Player's score.
        /// </summary>
        [DataMember]
        public int MyScore { get; set; }

        /// <summary>
        /// Shuffler's score.
        /// </summary>
        [DataMember]
        public int ShufflerScore { get; set; }
        #endregion

        
        /// <summary>
        /// This is a constructor of a card table.
        /// </summary>
        public Table()
        {
            MinBet = 1;
            MaxBet = 5;
            MyScore = 0;
            ShufflerScore = 0;
        }
        

        /// <summary>
        /// This method repesents a shuffler who manage a game.
        /// </summary>
        /// <param name="myPurse"></param>
        public void UserMenu(ref double myPurse, int tableNumber)
        {
            #region  Tuning of table instance.
            string shufflerName = "";
            switch (tableNumber)
            {
                case 1:
                    shufflerName = "Vasya";
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case 2:
                    shufflerName = "Fedya";
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case 3:
                    shufflerName = "Sveta";
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case 4:
                    MinBet = 10;
                    MaxBet = 50;
                    shufflerName = "Roma";
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
                case 5:
                    MinBet = 10;
                    MaxBet = 50;
                    shufflerName = "Rosa";
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
                case 6:
                    MinBet = 10;
                    MaxBet = 50;
                    shufflerName = "Natasha";
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                case 7:
                    MinBet = 100;
                    MaxBet = 500;
                    shufflerName = "Katya";
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                case 8:
                    MinBet = 100;
                    MaxBet = 500;
                    shufflerName = "Kolya";
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    break;
                case 9:
                    MinBet = 100;
                    MaxBet = 500;
                    shufflerName = "Tanya";
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case 10:
                    MinBet = 100;
                    MaxBet = 1000;
                    shufflerName = "Liza";
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                default:
                    Console.WriteLine("Error!");
                    break;
            }
            #endregion

            IDeck deck = new Deck();

            while (true)
            {
                #region Shuffler's hello.
                Console.Clear();
                Console.WriteLine("Shuffler: \"Hi!\"\nShuffler: \"My name is {0}\".\nShuffler: \"I am glad to see you!\"", shufflerName);
                Console.WriteLine("\nShuffler: \"Minimal bet is ${0}.\"\nShuffler: \"Maximal bet is ${1}.\"", MinBet, MaxBet);

                Console.WriteLine("\n   I have ============= ${0} in my purse.", myPurse);
                if (myPurse <= 0)
                {
                    Console.WriteLine("I have no money!");
                    Console.ReadKey();
                    break;
                }

                Console.WriteLine("\nShuffler: \"Set \"1\" if you are playing or other string to guit.\"");
                string answ = Console.ReadLine();
                if (answ.CompareTo("1") != 0)
                    break;

                Console.WriteLine("\nShuffler: \"Make your bet, please.");
                #endregion
                
                int myBet = ReadMyBet();

                deck.Shuffle();

                #region Card's dealing.
                List<ICard> myCards = new List<ICard>();
                List<ICard> shufflerCards = new List<ICard>();

                myCards.Add(deck.Pop());

                ICard opened = deck.Pop();
                Console.WriteLine("\n   Opened card of shuffler: \n{0}", opened);
                shufflerCards.Add(opened);
                
                bool flag1 = DealCardsToPlayer(ref myCards, ref myPurse, myBet, deck);
                if (flag1 == true)
                {
                    bool flag2 = DealCardsToShuffler(ref shufflerCards, ref myPurse, myBet, deck);
                    if (flag2 == true)
                    {
                        ShowRezult( shufflerCards, ref myPurse, myBet);
                        Console.WriteLine("\n   My purse =============== ${0}.", myPurse);
                    }
                }
                #endregion

                GetCardsBack(ref deck, ref myCards, ref shufflerCards);
            }
            Console.ReadKey();
        }


        /// <summary>
        /// This method collects cards back into the deck.
        /// </summary>
        /// <param name="deck">A deck of cards.</param>
        /// <param name="myCards">A list of player cards.</param>
        /// <param name="shufflerCards">A list of shuffler cards.</param>
        private void GetCardsBack(ref IDeck deck, ref List<ICard> myCards, ref List<ICard> shufflerCards)
        {
            foreach (ICard card in myCards)
            {
                deck.Add(card);
            }
            myCards.Clear();
            foreach (ICard card in shufflerCards)
            {
                deck.Add(card);
            }
            shufflerCards.Clear();
        }        


        /// <summary>
        /// This method determines a winner and adds to or takes money out of player's purse.
        /// </summary>
        /// <param name="shufflerCards">A list of shuffler csrds.</param>
        /// <param name="myPurse">Player's money.</param>
        /// <param name="myBet">Player's bet.</param>
        private void ShowRezult(List<ICard> shufflerCards, ref double myPurse, int myBet)
        {
            Console.WriteLine("\n   Shuffler's cards:");
            ShowCards(shufflerCards);
            Console.WriteLine("\n   Shuffler score: {0}.\n", this.ShufflerScore);

            Console.WriteLine("\nTHIS SCORE ________________________ {0} : {1}", MyScore, ShufflerScore);

            if (this.ShufflerScore > Constants.BEST_SCORE)
            {
                Console.WriteLine("\nYou win!");
                myPurse += myBet * 1.5;
            }
            else
            {
                if (this.MyScore > this.ShufflerScore)
                {
                    Console.Beep();
                    Console.WriteLine("\nShuffler: \"You win ${0} !!!!!!!!!!!!!!!!!!!!! :) :) :) :) :)\"", myBet * 1.5);
                    myPurse += myBet * 1.5;
                }
                else if (this.MyScore < this.ShufflerScore)
                {
                    Console.Beep(); Console.Beep(); Console.Beep();
                    Console.WriteLine("\nShuffler: \"You lost ${0}.   :(   :(   :(   :(   :( \"", myBet);
                    myPurse -= myBet;
                }
                else
                {
                    Console.Beep(); Console.Beep();
                    Console.WriteLine("Shuffler: \"Draw.\"");
                }
            }
            Console.WriteLine("\nShuffler: \"Good by!\"");
        }


        /// <summary>
        /// This method provides that shuffler gives cards to himself.
        /// </summary>
        /// <param name="shufflerCards">A list of shuffler csrds.</param>
        /// <param name="myPurse">Player's money.</param>
        /// <param name="myBet">Player's bet.</param>
        /// <returns>False if overflow happens.</returns>
        private bool DealCardsToShuffler(ref List<ICard> shufflerCards, ref double myPurse, int myBet, IDeck deck)
        {
            do
            {
                shufflerCards.Add(deck.Pop());
                this.ShufflerScore = countScore(shufflerCards);
                if (this.ShufflerScore >= Constants.SHUFFLER_LIMT_SCORE)
                    break;
            } while (true);

            if (this.ShufflerScore > Constants.BEST_SCORE)
            {
                myPurse += myBet * 1.5;
                Console.Beep();
                Console.WriteLine("Shuffler: \"It is overflow. You win ${0} !!!!!!!   :)   :)   :)\"", myBet);
                Console.WriteLine("\n   My purse ${0}.==========", myPurse);
                return false;
            }
            return true;            
        }


        /// <summary>
        /// This method provides that shuffler gives cards to player.
        /// </summary>
        /// <param name="myCards">A list of player cards.</param>
        /// <param name="myPurse">Player's money.</param>
        /// <param name="myBet">Player's bet.</param>
        /// <returns>False if overflow happens.</returns>
        private bool DealCardsToPlayer(ref List<ICard> myCards, ref double myPurse, int myBet, IDeck deck)
        {
            do
            {
                myCards.Add(deck.Pop());
                Console.WriteLine("\n   My cards:");
                ShowCards(myCards);
                this.MyScore = countScore(myCards);
                Console.WriteLine("\n   My score: {0}.\n", this.MyScore);

                if (this.MyScore > Constants.BEST_SCORE)
                {
                    myPurse -= myBet;
                    Console.Beep(); Console.Beep(); Console.Beep();
                    Console.WriteLine("Shuffler: \"Your score = {0}. It is overflow. You lost ${1}.  :(   :(   :(\"", this.MyScore, myBet);
                    Console.WriteLine("\n   My purse ${0}.", myPurse);
                    return false;
                }

                string answer = "";
                do
                {
                    Console.WriteLine("\nShuffler: \"Would you like to get one card? 1-no, 2-yes.\"");
                    answer = Console.ReadLine();
                    if (answer.CompareTo("1") == 0 || answer.CompareTo("2") == 0)
                        break;
                } while (true);

                if (answer.CompareTo("1") == 0)
                    return true;

            } while (true);
        }


        /// <summary>
        /// This method counts cards of player or shuffler.
        /// </summary>
        /// <param name="Cards">A list of (player or shuffler) cards.</param>
        /// <returns>A score of player or shuffler.</returns>
        private int countScore(List<ICard> Cards)
        {
            int rezult = 0;
            foreach (ICard card in Cards)
            {
                rezult += (int)card.Significance;
            }
            return rezult;
        }


        /// <summary>
        /// This method shows card array.
        /// </summary>
        /// <param name="Cards">A list of (player or shuffler) cards.</param>
        private void ShowCards(List<ICard> Cards)
        {
            foreach (ICard card in Cards)
            {
                Console.WriteLine(card);
            }
        }


        /// <summary>
        /// This method allows you to input your bet, parses it, converts it to int, checks it.
        /// </summary>
        /// <returns>A player bet.</returns>
        private int ReadMyBet()
        {
            int myBet;
            do
            {
                string Bet = Console.ReadLine();
                bool res = int.TryParse(Bet, out myBet);
                if (res == false)
                {
                    Console.WriteLine("Shuffler: \"Bet is not a number. Try again. Make your bet, please.\"");
                }
                else
                {
                    if(myBet < MinBet)
                    {
                        Console.WriteLine("Shuffler: \"Your bet is too small. Try again. Make your bet, please.\"");
                        continue;
                    }
                    else if (myBet > MaxBet)
                    {
                        Console.WriteLine("Shuffler: \"Your bet is too large. Try again. Make your bet, please.\"");
                        continue;
                    }
                    break;
                }
            } while(true);
            return myBet;
        }
    }
}



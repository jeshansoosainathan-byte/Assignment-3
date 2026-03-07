// Include the namespaces (code libraries) you need below.
using Assignment_3;
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:

        public static int cardNum = 18;
        Card[] cards = new Card[cardNum];

        public static int cardWidth = 80;
        public static int cardHeight = 140;

        public int cardOne = -1;
        public int cardTwo = -1;

        public int tries = 0;

        int gapX = 5;
        int gapY = 5;

        float revealTimer = 1f;
        bool waiting = false;

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("Concentration");
            Window.SetSize(800, 600);

            int[] numbers = new int[cardNum];

            for (int i = 0; i < 9; i++)
            {
                numbers[i * 2] = i + 1;
                numbers[i * 2 + 1] = i + 1;
            }

            for (int i = numbers.Length - 1; i > 0; i--)
            {
                int j = Random.Integer(i + 1);

                int temp = numbers[i];
                numbers[i] = numbers[j];
                numbers[j] = temp;
            }

            for (int i = 0; i < cards.Length; i++)
            {
                int col = i % 2;
                int row = i / 2;

                cards[i] = new Card(gapX + (row * (cardWidth + gapX)), gapY + (col * (cardHeight + gapY)), numbers[i]);


            }



        }

        public void Update()
        {

            Window.ClearBackground(Color.White);

            for (int i = 0; i < cards.Length; i++)
            {

                cards[i].Render();


            }

            if (waiting)
            {
                revealTimer -= Time.DeltaTime;

                if (revealTimer <= 0)
                {
                    CheckMatch();
                    waiting = false;
                }
            }

            
            CheckVictory();
            if (Input.IsMouseButtonPressed(MouseInput.Left) && (cardOne == -1 || cardTwo == -1))
            {

                for (int i = 0; i < cards.Length; i++) {

                    if (cards[i].CheckClick())
                    {

                        if (cardOne == -1)
                        {
                            cardOne = i;

                        }
                        else if (cardTwo == -1 && i != cardOne)
                        {

                            revealTimer = 1.0f;
                            waiting = true;
                            tries++;
                            cardTwo = i;
                        }

                        break;

                    }

                }
            }





        }


        public void ResetCards()
        {

            cardOne = -1;
            cardTwo = -1;


        }





        public void CheckMatch()
        {
            if (cardOne != -1 && cardTwo != -1)
            {

                

                if (cards[cardOne].id == cards[cardTwo].id)
                {
                     
                    cards[cardOne].collect();
                    cards[cardTwo].collect();
                    ResetCards();


                }
                else
                {


                    cards[cardOne].clicked = false;
                    cards[cardTwo].clicked = false;
                    ResetCards();


                }


            }

            

        }

    

    public void CheckVictory()
        {

            bool victory = true;

            foreach (Card card in cards) {

                if (!card.collected)
                {

                    victory = false;
                    break;

                }


            }

            if (victory)
            {

                Text.Color = Color.Black;
                Text.Size = 64;

                Text.Draw("VICTORY!", 400-64, 300-64);
                Text.Draw($"Tries: {tries}", 400 - 64   , 400 - 64);

            }



        }
    }


}

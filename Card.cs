using MohawkGame2D;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
   
   


    public class Card
    {
        public int x {  get; set; }
        public int y { get; set; }
        public int id { get; set; }

        public bool collected = false;
        public bool hovering = false;
        public bool clicked = false;


        private int cardWidth = 80;
        private int cardHeight = 140;

        public int leftEdge;
        public int rightEdge;
        public int topEdge;
        public int bottomEdge;

        public Card pair;


        public Card(int xIn, int yIn, int idIn) { 
        
            x=xIn;
            y=yIn;
            id=idIn;

            leftEdge = x;
            rightEdge = x + cardWidth;
            topEdge = y;
            bottomEdge = y + cardHeight;




        }

        public void setPair(Card card)
        {

            this.pair = card;
            card.pair = this;
        }


        public void Render()
        {
            Vector2 position = new Vector2(Input.GetMouseX(), Input.GetMouseY());

            MohawkGame2D.Color background = MohawkGame2D.Color.Black;


            if (IsHovering(position))
            {
                background = MohawkGame2D.Color.Yellow;

            }

            if (clicked)
            {

                background = MohawkGame2D.Color.Blue;
            }


            Draw.FillColor=background;
 
            Draw.Rectangle(x, y, cardWidth, cardHeight);

            if (clicked)
            {


               
                Text.Color = MohawkGame2D.Color.Black;
                Text.Size = 32;
                Text.Draw(id.ToString(), (x + cardWidth / 2) - 16, (y + cardHeight / 2) - 16);
               
            }
        }

        public bool IsHovering(Vector2 point)
        {

            bool isWithinX = point.X > leftEdge && point.X < rightEdge;
            bool isWithinY = point.Y > topEdge && point.Y < bottomEdge;

            // We can combine these two results into one
           return isWithinX && isWithinY;

        }

        public void ToggleHover(Vector2 point)
        {

            hovering = IsHovering(point);

        }

        public void CheckClick()
        {
            
            Vector2 position = new Vector2(Input.GetMouseX(), Input.GetMouseY());
            
            if (IsHovering(position))
            {
              
                clicked = true;


            }



            





        }




    }
}

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

        public float fallTime = 0;
      

        public int leftEdge;
        public int rightEdge;
        public int topEdge;
        public int bottomEdge;


      



        public Card(int xIn, int yIn, int idIn) { 
        
            x=xIn;
            y=yIn;
            id=idIn;

            leftEdge = x;
            rightEdge = x + Game.cardWidth;
            topEdge = y;
            bottomEdge = y + Game.cardHeight;




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

            if (collected)
            {

                
                    y++;
       
                background = MohawkGame2D.Color.Green;
            }



            Draw.FillColor=background;
 
            Draw.Rectangle(x, y, Game.cardWidth, Game.cardHeight);



            if (clicked || collected)
            {

                Text.Color = MohawkGame2D.Color.Black;
                Text.Size = 32;
                Text.Draw(id.ToString(), (x + Game.cardWidth / 2) - 16, (y + Game.cardHeight / 2) - 16);

            }
 



        }

        public bool IsHovering(Vector2 point)
        {

            bool isWithinX = point.X > leftEdge && point.X < rightEdge;
            bool isWithinY = point.Y > topEdge && point.Y < bottomEdge;

            
           return isWithinX && isWithinY;

        }

        public void ToggleHover(Vector2 point)
        {

            hovering = IsHovering(point);

        }

        public bool CheckClick()
        {
            
            Vector2 position = new Vector2(Input.GetMouseX(), Input.GetMouseY());
           
            if (IsHovering(position))
            {

                
                clicked = true;
                return true;

            }

            return false;

        }

        public void collect()
        {

            Console.WriteLine($"Collecting card of id {id}");
            clicked = false;
            collected = true;

        }





    }
}

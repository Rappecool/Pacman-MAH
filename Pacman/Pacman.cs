using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class Pacman:GameObject
    {
        Game1 game;
        int lives;

        //destination is position we want to move to.
        Vector2 destination;
        Vector2 direction;
        float speed = 100.0f;
        bool moving = false;

        public Pacman(Texture2D tex, Vector2 pos, Game1 game)
            :base(tex,pos)
        {
            this.game = game;
        }

        public override void update(GameTime gameTime)
        {
            //if we're not moving pick new direction and check if that way is possible to move.
            if(!moving)
            {
                    //movement
                if(Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    changeDirection(new Vector2(-1, 0));
                }

                else if(Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    changeDirection(new Vector2(1, 0));
                }
                else if(Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    changeDirection(new Vector2(0, -1));
                }
                else if(Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    changeDirection(new Vector2(0, 1));
                }
            }

                    //???
            else
            {
                    //???
                Pos += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

                //check if we're near enough the destination

                if(Vector2.Distance(Pos,destination) < 1)
                {
                    Pos = destination;
                    moving = false;
                }



            }


            base.update(gameTime);
        }

            //handles movement.
        private void changeDirection(Vector2 dir)
        {
            direction = dir;
                //??
            Vector2 newDestination = Pos + direction * 50.0f;

            //check if we can move in the desired direction, if not, do nothing.

            if(!game.getTileAtPosition(newDestination).Wall)
            {
                destination = newDestination;
                moving = true;
            }
            
        }
    }
}

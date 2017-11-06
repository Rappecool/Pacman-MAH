using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

        public Pacman(Texture2D tex, Vector2 pos, Game1 game)
            :base(tex,pos)
        {
            this.game = game;
        }

        public override void update(GameTime gameTime)
        {

            base.update(gameTime);
        }
    }
}

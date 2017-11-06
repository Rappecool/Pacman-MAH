using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class GameObject
    {
        Vector2 pos;
        Texture2D tex;

        //getter and setter
        public Vector2 Pos
        {
            get { return pos; }
            set { pos = value; }
        }

        public GameObject(Texture2D tex, Vector2 pos)
        {
            this.tex = tex;
            this.pos = pos;
        }

        public virtual void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, pos, Color.White);
        }

        public virtual void update(GameTime gameTime)
        {

        }

    }
}

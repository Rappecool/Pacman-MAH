using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class Tile:GameObject
    {
        bool wall;
        
        //getter and setter
        public bool Wall
        {
            get { return wall; }
            set { wall = value; }
        }

        public Tile(Texture2D tex, Vector2 pos, bool wall)
            : base(tex, pos)
        {
            this.wall = wall;

        }

    }
}

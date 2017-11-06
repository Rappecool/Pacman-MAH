using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.IO;

namespace Pacman
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Tile[,] tiles;
        Pacman pacman;
        int tileSize;

        List<string> strings = new List<string>();


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //textures
            Texture2D floorTileTex = Content.Load<Texture2D>(@"floortile");
            Texture2D wallTileTex = Content.Load<Texture2D>(@"walltile");
            
            Texture2D ballTex = Content.Load<Texture2D>(@"ball");

                //Read from map.txt to string list.
            StreamReader sr = new StreamReader(@"map.txt");
            while(!sr.EndOfStream)
            {
                strings.Add(sr.ReadLine());
            }
            sr.Close();

            //create tiles from string List.

            tiles = new Tile[strings[0].Length, strings.Count];

            for(int i = 0; i < tiles.GetLength(0);i++)
            {
                for(int k = 0; k < tiles.GetLength(1);k++)
                {
                        //if strings[i][k] == wall; add wall to game.
                    if (strings[k][i] == 'w')
                    {
                        tiles[i, k] = new Tile(wallTileTex, new Vector2(wallTileTex.Width * i, wallTileTex.Height * k), true);
                    }
                        //if floor.
                    else if(strings[k][i] == '-')
                    {
                        tiles[i, k] = new Tile(floorTileTex, new Vector2(floorTileTex.Width * i, floorTileTex.Height * k), false);
                    }

                    else if(strings[k][i] == 'b')
                    {
                        //if pacman
                        tiles[i, k] = new Tile(floorTileTex, new Vector2(floorTileTex.Width * i, floorTileTex.Height * k), false);

                                                                                                    //this? hur refererar det till denna instansen av game1
                        pacman = new Pacman(ballTex, new Vector2(floorTileTex.Width * i, floorTileTex.Height * k), this);
                    }
                }
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            for(int i = 0; i < tiles.GetLength(1); i++)
            {
                for(int k = 0; k < tiles.GetLength(1); k++)
                {
                    tiles[i, k].draw(spriteBatch);
                }
            }
            pacman.draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

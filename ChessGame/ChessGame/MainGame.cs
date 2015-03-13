/*   MainGame.cs - Main file for game operation.
*    Copyright (C) 2015  Connor Blakey <connorblakey96@gmail.com>, Matthew Burling <mattyburlin@gmail.com>.
*
*    This program is free software; you can redistribute it and/or modify
*    it under the terms of the GNU General Public License as published by
*    the Free Software Foundation; either version 2 of the License, or
*    (at your option) any later version.
*
*    This program is distributed in the hope that it will be useful,
*    but WITHOUT ANY WARRANTY; without even the implied warranty of
*    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
*    GNU General Public License for more details.
*
*    You should have received a copy of the GNU General Public License along
*    with this program; if not, write to the Free Software Foundation, Inc.,
*    51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace ChessGame
{
    enum gameState
    {
        MainMenu,
        Playing,
        Paused,
        RedWon,
        BlueWon
    }
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class MainGame : Microsoft.Xna.Framework.Game
    {
        // Graphics Class Allocations
        GraphicsDeviceManager graphics;

        // Sprite class allocations
        SpriteBatch spriteBatch;

        // Mouse class allocations
        private MouseState oldMouseState;

        // Song class allocations
        protected Song song;
        protected Song song2;

        public MainGame()
        {
            // Graphics allocation + resolution 
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;

            // Content allocations 
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
            Window.Title = "Nyaa~ Chess";
            IsMouseVisible = true;

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

            // TODO: use this.Content to load your game content here

            // Song allocations WILL BE FIXED LATER. - Matthew
            song = Content.Load<Song>("test");
            song2 = Content.Load <Song>("test2");
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allocates the mouse state and also checks if the window is active

            MouseState newMouseState = Mouse.GetState();

            if(this.IsActive)
            {
                if (newMouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
                {
#if DEBUG
                    // Useful message to see if mouse has been clicked.
                    // DEBUG ONLY
                    Console.WriteLine("Mouse was clicked.");
                    Console.WriteLine(newMouseState.X);
                    Console.WriteLine(newMouseState.Y);
                    MediaPlayer.Pause();
#endif
                    // TODO: Add the real logic for this if statement.
                }
                oldMouseState = newMouseState;
            }
            // Song stuff WILL BE FIXED LATER. - Matthew
            if (MediaPlayer.State == MediaState.Paused)
            {
               MediaPlayer.Play(song2);
               MediaPlayer.IsRepeating = true;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}

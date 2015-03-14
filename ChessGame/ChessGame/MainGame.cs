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
using ChessGameAssets;


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

        // Board class allocations
        Board newBoard;

        // Chess piece allocations
        Pawn newPawn;

        // Game Object Allocations
        GameObject startButton;
        GameObject mainscreen;
        GameObject quitbutton;
        GameObject Background;

        // Song class allocations
        protected Song PlayingTheme;
        protected Song song2;

        // Game State allocations
        private gameState activeGameState;

        public MainGame()
        {
            // Graphics allocation + resolution 
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            activeGameState = gameState.MainMenu;

            // Content allocations 
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Check if the mouse intersects a rectangle.
        /// </summary>
        /// <param name="x">X position of the mouse.</param>
        /// <param name="y">Y position of the mouse.</param>
        /// <param name="rectangleCheck">Rectangle to check the intersection against.</param>
        /// <returns></returns>
        bool MouseIntersected(int x, int y, Rectangle rectangleCheck)
        {
            //Creates a rectangle around the mouse click - Matthew
            Rectangle mouseClickRect = new Rectangle(x, y, 10, 10);

            if (mouseClickRect.Intersects(rectangleCheck))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            Window.Title = "Nyaa Chesu";
            IsMouseVisible = true;
            activeGameState = gameState.MainMenu;
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

            newPawn = new Pawn(Content.Load<Texture2D>("ball"), new Rectangle(0, 0, 30, 30), spriteBatch);
            startButton = new GameObject(Content.Load<Texture2D>("StartButton"), new Rectangle(475, 300, 300, 150), spriteBatch);
            mainscreen = new GameObject(Content.Load<Texture2D>("startscreen"), new Rectangle(0, 0, 1280, 720), spriteBatch);
            quitbutton = new GameObject(Content.Load<Texture2D>("quitbutton"), new Rectangle(475, 475, 300, 150), spriteBatch);
            Background = new GameObject(Content.Load<Texture2D>("Background"), new Rectangle(0, 0, 1280, 720), spriteBatch);


            // List to store all sprited to load into the piece sprite dictionary.
            List<Texture2D> textureList = new List<Texture2D>();
            // Dictionary to pass to the board for piece sprites.
            Dictionary<int, Texture2D> spriteDictionary = new Dictionary<int, Texture2D>();
            int spriteKey = 0;

            // Load piece sprites into list here.
            textureList.Add(Content.Load<Texture2D>("ball"));
            textureList.Add(Content.Load<Texture2D>("bat"));

            // Load all piece sprites into list into the dictionary.
            foreach (Texture2D texture in textureList)
            {
                spriteDictionary.Add(spriteKey, texture);
                spriteKey++;
            }

            newBoard = new ChessGameAssets.Board(Content.Load<Texture2D>("Chess_board"), new Rectangle(GraphicsDevice.Viewport.Width / 8, 10, 6 * GraphicsDevice.Viewport.Width / 8, 700), spriteDictionary, spriteBatch);

            // Song allocations
            // Anime Style Soundscape - In The Hills Copyright © 2014 Grant Stevens Varazuvi™ www.varazuvi.com
            PlayingTheme = Content.Load<Song>("inthehills");
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

            if (this.IsActive)
            {
                // Game state checks
                //if (activeGameState == gameState.Paused)
                //{
                //    MediaPlayer.Play(song2);
                //    MediaPlayer.IsRepeating = true;
                //}
                if (activeGameState == gameState.MainMenu)
                {
                    if (MediaPlayer.State == MediaState.Stopped)
                    {
                        MediaPlayer.Play(PlayingTheme);
                        MediaPlayer.IsRepeating = true;
                    }
                }
                if (newMouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
                {
#if DEBUG
                    // Useful message to see if mouse has been clicked.
                    // DEBUG ONLY
                    Console.WriteLine("Mouse was clicked.");
                    Console.WriteLine(newMouseState.X);
                    Console.WriteLine(newMouseState.Y);


#endif
                    //MouseClicked(newMouseState.X, newMouseState.Y,);
                    if (MouseIntersected(newMouseState.X, newMouseState.Y, startButton.getRectangle()))
                    {
                        activeGameState = gameState.Playing;
                        Console.WriteLine("Game state is now playing game state");
                    }
                    else if (MouseIntersected(newMouseState.X, newMouseState.Y, quitbutton.getRectangle()))
                    {
                        Exit();
                    }

                }
                oldMouseState = newMouseState;
            }
            // Song stuff WILL BE FIXED LATER. - Matthew
            if (MediaPlayer.State == MediaState.Paused)
            {
                MediaPlayer.Play(song2);
                MediaPlayer.IsRepeating = true;
            }

            //// Song stuff WILL BE FIXED LATER. - Matthew
            //if (MediaPlayer.State == MediaState.Paused)
            //{
            //   MediaPlayer.Play(song2);
            //   MediaPlayer.IsRepeating = true;
            //}

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
            spriteBatch.Begin();
            //newBoard.Draw();
            //newPawn.Draw();
            //startButton.Draw();
            if (activeGameState == gameState.MainMenu)
            {
                mainscreen.Draw();
                startButton.Draw();
                quitbutton.Draw();

            }
            if (activeGameState == gameState.Playing)
            {
                Background.Draw();
                newBoard.Draw();
            }
            //spriteBatch.Begin();
            //    spriteBatch.Draw(startscreen, new Rectangle(0, 0, 1280, 720), Color.White);
            //    spriteBatch.Draw(quitbutton, quitButtonRectangle, Color.White);
            //    //spriteBatch.End();
            //}
            //if (activeGameState == gameState.Playing)
            //{
            //    // TODO: Add board drawing stuff here.

            //}
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

﻿/*   ChessGamePieces.cs - Class file for chess pieces.
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

namespace ChessGameAssets
{
    /// <summary>
    /// A basic object 
    /// </summary>
    class GameObject
    {
        // Create allocations for position of piece, sprite texture and rectangle to draw in.
        protected Texture2D mSprite;
        protected Rectangle mSpriteRectangle;
        protected SpriteBatch spriteBatch;

        /// <summary>
        /// Create a new instance of a GameObject.
        /// </summary>
        /// <param name="pSetSprite">Sprite to be loaded into the object.</param>
        /// <param name="pSetRectangle">Rectange to draw the sprite in and it's size.</param>
        /// <param name="pSetSpriteBatch">SpriteBatch to use to draw the object.</param>
        public GameObject(Texture2D pSetSprite, Rectangle pSetRectangle, SpriteBatch pSetSpriteBatch)
        {
            mSprite = pSetSprite;
            mSpriteRectangle = pSetRectangle;
            spriteBatch = pSetSpriteBatch;
        }

        /// <summary>
        /// Return the Vector2 position of the GameObject.
        /// </summary>
        /// <returns>The vector position of the GameObject.</returns>
        public Vector2 getPosition()
        {
            return new Vector2(mSpriteRectangle.X, mSpriteRectangle.Y);
        }

        /// <summary>
        /// Return the Rectangle of the GameObject.
        /// </summary>
        /// <returns>The Rectangle of the GameObject.</returns>
        public Rectangle getRectangle()
        {
            return mSpriteRectangle;
        }

        /// <summary>
        /// Draw the GameObject to the SpriteBatch.
        /// </summary>
        public virtual void Draw()
        {
            spriteBatch.Draw(mSprite, mSpriteRectangle, Color.White);
        }
    }

    /// <summary>
    /// Base class for all chess pieces.
    /// </summary>
    class GamePiece : GameObject
    {
        /// <summary>
        /// Create a new instance of a GamePiece.
        /// </summary>
        /// <param name="pSetSprite">Sprite to be loaded into the object.</param>
        /// <param name="pSetRectangle">Rectange to draw the sprite in and it's size.</param>
        /// <param name="pSetSpriteBatch">SpriteBatch to use to draw the object.</param>
        public GamePiece(Texture2D pSetSprite, Rectangle pSetRectangle, SpriteBatch pSetSpriteBatch) : base(pSetSprite, pSetRectangle, pSetSpriteBatch) { }

        protected virtual void Move()
        {

        }
    }

    /// <summary>
    /// A Pawn class for chess.
    /// </summary>
    class Pawn : GamePiece
    {
        /// <summary>
        /// Create a new instace of a Pawn.
        /// </summary>
        /// <param name="pSetXPosition">Vector value of the position.</param>
        /// <param name="pSetSprite">Sprite to be loaded into the object.</param>
        /// <param name="pSetRectangle">Rectange to draw the sprite in and it's size.</param>
        /// <param name="pSetSpriteBatch">SpriteBatch to use to draw the object.</param>
        public Pawn(Texture2D pSetSprite, Rectangle pSetRectangle, SpriteBatch pSetSpriteBatch) : base(pSetSprite, pSetRectangle, pSetSpriteBatch) { }
    }

    /// <summary>
    /// A class for a chess board.
    /// </summary>
    class Board : GameObject
    {
        List<GamePiece> Pieces = new List<GamePiece>();
        Dictionary<int, Texture2D> SpriteDictionary;

        /// <summary>
        /// Create a new instance of of a game Board.
        /// </summary>
        /// <param name="pSetSprite">Sprite to be loaded into the object.</param>
        /// <param name="pSetRectangle">Rectange to draw the sprite in and it's size.</param>
        /// <param name="pPassDictionary">Sprite dictionary to load for the game pieces. Order of sprite index: pawn, rook, knight, bishop, queen and king.</param>
        /// <param name="pSetSpriteBatch">SpriteBatch to use to draw the object.</param>
        public Board(Texture2D pSetSprite, Rectangle pSetRectangle, Dictionary<int,Texture2D> pPassDictionary, SpriteBatch pSetSpriteBatch) : base(pSetSprite, pSetRectangle, pSetSpriteBatch)
        {
            SpriteDictionary = pPassDictionary;

            // TEST: drawing the set of pieces.
            for (int i = 0; i < 8; i++)
            {
                Pieces.Add(new Pawn(SpriteDictionary[0], new Rectangle(0, i * 90, 30, 30), spriteBatch));
            }
        }

        /// <summary>
        /// Draw each and every GamePiece on the board.
        /// </summary>
        public override void Draw()
        {
            base.Draw();
            foreach (GamePiece piece in Pieces)
            {
                piece.Draw();
            }
        }
    }
}

/*   ChessGamePieces.cs - Class file for chess pieces.
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
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChessGamePieces
{
    /// <summary>
    /// A basic object 
    /// </summary>
    class GameObject
    {
        // Create allocations for position of piece, sprite texture and rectangle to draw in.
        protected Vector2 mPosition;
        protected Texture2D mSprite;
        protected Rectangle mSpriteRectangle;

        /// <summary>
        /// Create a new instance of a GameObject.
        /// </summary>
        /// <param name="pSetXPosition">Vector value of the position.</param>
        /// <param name="pSetSprite">Sprite to be loaded into the object.</param>
        /// <param name="pSetRectangle">Rectange to draw the sprite in and it's size.</param>
        public GameObject(Vector2 pSetPosition, Texture2D pSetSprite, Rectangle pSetRectangle)
        {
            mPosition = pSetPosition;
            mSprite = pSetSprite;
            mSpriteRectangle = pSetRectangle;
        }

        public Vector2 getPosition()
        {
            return mPosition;
        }

        public Texture2D getTexture()
        {
            return mSprite;
        }

        public Rectangle getRectangle()
        {
            return mSpriteRectangle;
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
        /// <param name="pSetVector">Vector2 value of the position of the piece.</param>
        public GamePiece(Vector2 pSetPosition, Texture2D pSetSprite, Rectangle pSetRectangle) : base(pSetPosition, pSetSprite, pSetRectangle) { }
    }

    /// <summary>
    /// A Pawn class for chess.
    /// </summary>
    class Pawn : GamePiece
    {
        /// <summary>
        /// Create a new instace of a Pawn.
        /// </summary>
        /// <param name="pSetVector">Vector2 value of the position of the piece.</param>
        public Pawn(Vector2 pSetPosition, Texture2D pSetSprite, Rectangle pSetRectangle) : base(pSetPosition, pSetSprite, pSetRectangle) { }
    }

    /// <summary>
    /// A class for a chess board.
    /// </summary>
    class Board : GameObject
    {
        List<GamePiece> Pieces = new List<GamePiece>();

        public Board(Vector2 pSetPosition, Texture2D pSetSprite, Rectangle pSetRectangle) : base(pSetPosition, pSetSprite, pSetRectangle)
        {
            for (int i = 0; i < 10; i++)
            {
                Pieces.Add(new GamePiece(new Vector2(0, 0), null, new Rectangle(0, 0, 30, 30)));
            }
        }
    }
}

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
    /// A basic object used to draw a Texture2D in a Rectangle to screen.
    /// </summary>
    class GameObject
    {
        // Create allocations for position of piece, sprite texture and rectangle to draw in.
        private Texture2D m_Sprite;
        private Rectangle m_SpriteRectangle;

        /// <summary>
        /// Create a new instance of a GameObject.
        /// </summary>
        /// <param name="p_SetSprite">Sprite to be loaded into the object.</param>
        /// <param name="p_SetRectangle">Rectange to draw the sprite in and it's size.</param>
        public GameObject(Texture2D p_SetSprite, Rectangle p_SetRectangle)
        {
            m_Sprite = p_SetSprite;
            m_SpriteRectangle = p_SetRectangle;
        }

        /// <summary>
        /// Return the Vector2 position of the GameObject.
        /// </summary>
        /// <returns>The vector position of the GameObject.</returns>
        public Vector2 getPosition()
        {
            return new Vector2(m_SpriteRectangle.X, m_SpriteRectangle.Y);
        }

        /// <summary>
        /// Return the sprite contained.
        /// </summary>
        /// <returns>Texture2D sprite.</returns>
        public Texture2D getSprite()
        {
            return m_Sprite;
        }

        /// <summary>
        /// Set a new sprite for the object.
        /// </summary>
        public void setSprite(Texture2D p_NewSprite)
        {
            m_Sprite = p_NewSprite;
        }

        /// <summary>
        /// Return the Rectangle of the GameObject.
        /// </summary>
        /// <returns>The Rectangle of the GameObject.</returns>
        public Rectangle getRectangle()
        {
            return m_SpriteRectangle;
        }

        /// <summary>
        /// Draw the GameObject to the SpriteBatch.
        /// </summary>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(m_Sprite, m_SpriteRectangle, Color.White);
        }
    }

    /// <summary>
    /// Base class for all chess pieces.
    /// </summary>
    class GamePiece : GameObject
    {
        private bool m_Taken;

        /// <summary>
        /// Create a new instance of a GamePiece.
        /// </summary>
        /// <param name="p_SetSprite">Sprite to be loaded into the object.</param>
        /// <param name="p_SetRectangle">Rectange to draw the sprite in and it's size.</param>
        ///
        public GamePiece(Texture2D p_SetSprite, Rectangle p_SetRectangle) : base(p_SetSprite, p_SetRectangle)
        {
            m_Taken = false;
        }

        /// <summary>
        /// Checks if the GamePiece has been taken.
        /// </summary>
        /// <returns>If true, piece has been taken. If false, the piece has not been taken.</returns>
        public bool IsTaken()
        {
            return m_Taken;
        }

        private virtual void Move()
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
        /// <param name="p_SetSprite">Sprite to be loaded into the object.</param>
        /// <param name="p_SetRectangle">Rectange to draw the sprite in and it's size.</param>
        public Pawn(Texture2D p_SetSprite, Rectangle p_SetRectangle) : base(p_SetSprite, p_SetRectangle) { }
    }

    /// <summary>
    /// A Rook class for chess.
    /// </summary>
    class Rook : GamePiece
    {
        /// <summary>
        /// Create a new instace of a Rook.
        /// </summary>
        /// <param name="p_SetSprite">Sprite to be loaded into the object.</param>
        /// <param name="p_SetRectangle">Rectange to draw the sprite in and it's size.</param>
        public Rook(Texture2D p_SetSprite, Rectangle p_SetRectangle) : base(p_SetSprite, p_SetRectangle) { }
    }

    /// <summary>
    /// A Knight class for chess.
    /// </summary>
    class Knight : GamePiece
    {
        /// <summary>
        /// Create a new instace of a Knight.
        /// </summary>
        /// <param name="p_SetSprite">Sprite to be loaded into the object.</param>
        /// <param name="p_SetRectangle">Rectange to draw the sprite in and it's size.</param>
        public Knight(Texture2D p_SetSprite, Rectangle p_SetRectangle) : base(p_SetSprite, p_SetRectangle) { }
    }

    /// <summary>
    /// A Bishop class for chess.
    /// </summary>
    class Bishop : GamePiece
    {
        /// <summary>
        /// Create a new instace of a Bishop.
        /// </summary>
        /// <param name="p_SetSprite">Sprite to be loaded into the object.</param>
        /// <param name="p_SetRectangle">Rectange to draw the sprite in and it's size.</param>
        public Bishop(Texture2D p_SetSprite, Rectangle p_SetRectangle) : base(p_SetSprite, p_SetRectangle) { }
    }

    /// <summary>
    /// A Queen class for chess.
    /// </summary>
    class Queen : GamePiece
    {
        /// <summary>
        /// Create a new instace of a Queen.
        /// </summary>
        /// <param name="p_SetSprite">Sprite to be loaded into the object.</param>
        /// <param name="p_SetRectangle">Rectange to draw the sprite in and it's size.</param>
        public Queen(Texture2D p_SetSprite, Rectangle p_SetRectangle) : base(p_SetSprite, p_SetRectangle) { }
    }

    /// <summary>
    /// A King class for chess.
    /// </summary>
    class King : GamePiece
    {
        /// <summary>
        /// Create a new instace of a King.
        /// </summary>
        /// <param name="p_SetSprite">Sprite to be loaded into the object.</param>
        /// <param name="p_SetRectangle">Rectange to draw the sprite in and it's size.</param>
        public King(Texture2D p_SetSprite, Rectangle p_SetRectangle) : base(p_SetSprite, p_SetRectangle) { }
    }

    /// <summary>
    /// A class for a chess board.
    /// </summary>
    class Board : GameObject
    {
        List<GamePiece> Pieces;
        Dictionary<int, Texture2D> SpriteDictionary;
        GamePiece[,] PieceArray = new GamePiece[,] { };

        /// <summary>
        /// Create a new instance of of a game Board.
        /// </summary>
        /// <param name="p_SetSprite">Sprite to be loaded into the object.</param>
        /// <param name="p_SetRectangle">Rectange to draw the sprite in and it's size.</param>
        /// <param name="pLoadDictionary">Sprite dictionary to load for the game pieces. Order of sprite index: pawn, rook, knight, bishop, queen and king.</param>
        /// <param name="p_SetSpriteBatch">SpriteBatch to use to draw the object.</param>
        /// <param name="pLoadPieces">GamePieces to initialise the board with.</param>
        public Board(Texture2D p_SetSprite, Rectangle p_SetRectangle, Dictionary<int, Texture2D> pLoadDictionary, List<GamePiece> pLoadPieces)
            : base(p_SetSprite, p_SetRectangle)
        {
            SpriteDictionary = pLoadDictionary;
            Pieces = pLoadPieces;
        }

        /// <summary>
        /// Draw each and every GamePiece on the board.
        /// </summary>
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            foreach (GamePiece piece in Pieces)
            {
                piece.Draw(spriteBatch);
            }
        }
    }
}

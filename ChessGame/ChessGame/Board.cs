/*   Board.cs - Board class for chess.
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
    /// Indexing of the board tiles.
    /// </summary>
    enum BoardIndex
    {
        A,
	B,
	C,
	D,
	E,
	F,
	G,
	H
    }

    /// <summary>
    /// Data/representation class for a board tile.
    /// </summary>
    class BoardTile : GameObject
    {
        private BoardIndex m_Index;
	private int m_Vector;
	private GamePiece m_HeldPiece;

	/// <summary>
	/// Create a new instace of a board tile.
	/// </summary>
	public BoardTile(BoardIndex newIndex, int newVector)
	{
	    m_Index = newIndex;
	    if (newVector > 7)
	    {
	        throw new Exception("Index is too large, {}.", newVector);
	    }
	    else if (newVector < 0)
	    {
	        throw new Exception("Index is too low, {}.", newVector);
	    }
	    m_Vector = newVector;
	}

	public BoardIndex getIndex()
	{
	  return m_Index;
	}

	public int getVector()
	{
	  return m_Vector;
	}
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
	/// Finds the intersected board tile from a Mouse Rectangle.
	/// </summary>
	public BoardIndex getBoardTile(Rectangle p_MouseRect)
	{
	  throw new NotImplementedException();
	}

        /// <summary>
        /// Draw each and every GamePiece on top of the board.
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

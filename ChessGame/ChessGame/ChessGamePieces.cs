using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChessGamePieces
{
    /// <summary>
    /// Represents the class of a chess piece.
    /// </summary>
    public enum PieceClass
    {
        pawn,
        rook,
        knight,
        bishop,
        queen,
        king
    }

    /// <summary>
    /// Base class for all chess pieces.
    /// </summary>
    class GamePiece
    {
        // Create allocations for position of piece, sprite texture and rectangle to draw in.
        protected Vector2 mPosition;
        // TODO: These two items might not be needed as per good design, will look up later
        // when adeqate sleep has been aquired.
        protected Texture2D mSprite;
        protected Rectangle mSpriteRectangle;

        // Allocation for the assignment of a the piece class - for use by child classes ONLY.
        protected PieceClass mPieceClass;

        /// <summary>
        /// Create a new instance of a GamePiece.
        /// </summary>
        /// <param name="pSetXPosition">The x value of the position of the piece.</param>
        /// <param name="pSetYPosition">The y value of the position of the piece.</param>
        public GamePiece(int pSetXPosition, int pSetYPosition)
        {
            mPosition = new Vector2(pSetXPosition, pSetYPosition);
        }

        /// <summary>
        /// Create a new instance of a GamePiece.
        /// </summary>
        /// <param name="pSetVector">Vector2 value of the position of the piece.</param>
        public GamePiece(Vector2 pSetVector)
        {
            mPosition = pSetVector;
        }

        /// <summary>
        /// Return the class of chess piece which the object is.
        /// </summary>
        /// <returns>A PieceClass enum type.</returns>
        public PieceClass getPieceClass()
        {
            return mPieceClass;
        }
    }

    /// <summary>
    /// A Pawn class for a chess.
    /// </summary>
    class Pawn : GamePiece
    {
        // TODO: Might need to add code to constructors to load in sprites, etc.

        /// <summary>
        /// Create a new instance of a Pawn,
        /// </summary>
        /// <param name="pSetXPosition">The x value of the position of the piece.</param>
        /// <param name="pSetYPosition">The y value of the position of the piece.</param>
        public Pawn(int pSetXPosition, int pSetYPosition) : base(pSetXPosition, pSetYPosition)
        {
            mPieceClass = PieceClass.pawn;
        }

        /// <summary>
        /// Create a new instace of a Pawn.
        /// </summary>
        /// <param name="pSetVector">Vector2 value of the position of the piece.</param>
        public Pawn(Vector2 pSetVector) : base(pSetVector)
        {
            mPieceClass = PieceClass.pawn;
        }
    }
}

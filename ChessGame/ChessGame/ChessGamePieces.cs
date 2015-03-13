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
        public GameObject(Vector2 pSetXPosition, Texture2D pSetSprite, Rectangle pSetRectangle)
        {
            mPosition = pSetXPosition;
            mSprite = pSetSprite;
            mSpriteRectangle = pSetRectangle;
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
        public GamePiece(Vector2 pSetVector, Texture2D pSetSprite, Rectangle pSetRectangle) : base(pSetVector, pSetSprite, pSetRectangle) { }
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
        public Pawn(Vector2 pSetVector, Texture2D pSetSprite, Rectangle pSetRectangle) : base(pSetVector, pSetSprite, pSetRectangle) { }
    }
}

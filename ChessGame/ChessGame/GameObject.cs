/*   GameObject.cs - Basic object for the game.
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
        public Texture2D m_Sprite;
        public Rectangle m_SpriteRectangle;

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
        /// Draw the GameObject to the SpriteBatch.
        /// </summary>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(m_Sprite, m_SpriteRectangle, Color.White);
        }
    }
}

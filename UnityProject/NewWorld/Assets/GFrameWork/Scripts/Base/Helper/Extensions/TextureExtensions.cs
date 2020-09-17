using System;
using UnityEngine;

namespace GFrame
{
    public static class TextureExtensions
    {
        public static Sprite ToSprite(this Texture2D value)
        {
            return Sprite.Create(value, new Rect(0, 0, value.width, value.height), Vector2.zero, 1f);
        }
    }
}

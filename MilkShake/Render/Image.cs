﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using MilkShakeFramework.Core.Content;
using Microsoft.Xna.Framework;
using MilkShakeFramework.Core.Scenes;

namespace MilkShakeFramework.Render
{
    public class Image : Renderer
    {
        private Texture2D mTexture2D;
        private string mURL;

        public Image(string url)
        {
            mURL = url;
        }

        public override void Load(LoadManager content)
        {
            mTexture2D = MilkShake.ConentManager.Load<Texture2D>(URL);
            
            base.Load(content);
        }

        public void Draw(Vector2 position)
        {
            Draw(position, Texture.Width, Texture.Height, 0, Vector2.Zero, Color.White);
        }

        public void Draw(Vector2 position, int width, int height, float rotation, Vector2 origin, Color color)
        {
            RenderManager.Draw(position, Texture, width, height, rotation, origin, color);
        }

        public Texture2D Texture { get { return mTexture2D; } }
        public string URL { get { return mURL; } }
        public Vector2 ImageCenter { get { return new Vector2(Texture.Width / 2, Texture.Height / 2); } }

    }
}

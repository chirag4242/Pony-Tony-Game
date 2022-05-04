using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CPFinalProject
{
    class AboutScene:GameScene
    {
        private SpriteBatch spriteBatch;
        private Texture2D aboutSprite;

        public AboutScene(Game game): base(game)
        {
            this.spriteBatch = ((GameWorld)game).spriteBatch;
            aboutSprite = ((GameWorld)game).Content.Load<Texture2D>("Images/aboutImage");
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(aboutSprite,Vector2.Zero, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

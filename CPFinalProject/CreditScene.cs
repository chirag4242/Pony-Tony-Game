using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CPFinalProject
{
    class CreditScene:GameScene
    {
        private SpriteBatch spriteBatch;
        private Texture2D creditSprite;

        public CreditScene(Game game) : base(game)
        {
            this.spriteBatch = ((GameWorld)game).spriteBatch;
            creditSprite = ((GameWorld)game).Content.Load<Texture2D>("Images/creditImage");
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(creditSprite, Vector2.Zero, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CPFinalProject
{
    class HelpScene:GameScene
    {
        private SpriteBatch spriteBatch;
        private Texture2D helpSprite;

        public HelpScene(Game game) : base(game)
        {
            this.spriteBatch = ((GameWorld)game).spriteBatch;
            helpSprite = ((GameWorld)game).Content.Load<Texture2D>("Images/helpImage");
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(helpSprite, Vector2.Zero, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

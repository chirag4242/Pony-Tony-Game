using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CPFinalProject
{
    class StartScene:GameScene
    {
        public MenuComponent Menu;
        public Texture2D background;
        private SpriteBatch spriteBatch;
        private List<string> menuItems = new List<string> { "Start Game", "About", "Help", "High Score", "Credit", "Quit" };

        public StartScene(Game game) : base(game)
        {
            GameWorld gameWorld = (GameWorld)game;
            this.spriteBatch = gameWorld.spriteBatch;
            SpriteFont regularFont = gameWorld.Content.Load<SpriteFont>("regularFont");
            SpriteFont highlightFont = gameWorld.Content.Load<SpriteFont>("highlightFont");
            background = gameWorld.Content.Load<Texture2D>("Images/backScreen");
            Menu = new MenuComponent(game, spriteBatch, regularFont, highlightFont, menuItems);
            this.Components.Add(Menu);
        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(background, Vector2.Zero, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

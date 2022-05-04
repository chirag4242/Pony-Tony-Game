using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
 using System.Collections.Generic;
using System.Text;

namespace CPFinalProject
{
    class MenuComponent:DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private SpriteFont regularFont;
        private SpriteFont highlightFont;
        private List<string> menuItems;
        public int selectedIndex;
        private Vector2 position;
        private Color regularColor = Color.Black;
        private Color highlightColor = Color.Red;
        private KeyboardState prevKBState;

        public MenuComponent(Game game, SpriteBatch spriteBatch, SpriteFont regularFont, SpriteFont highlightFont, List<string> menuItems) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.regularFont = regularFont;
            this.highlightFont = highlightFont;
            this.menuItems = menuItems;
            position = new Vector2(Shared.ScreenDimension.X / 3, Shared.ScreenDimension.Y / 3);
        }
        public override void Update(GameTime gameTime)
        {
            KeyboardState currentKBState = Keyboard.GetState();
            if(currentKBState.IsKeyDown(Keys.Down) && (prevKBState.IsKeyUp(Keys.Down)))
            {
                selectedIndex++;
                if (selectedIndex == menuItems.Count)
                {
                    selectedIndex = 0;
                }
            }

            if(currentKBState.IsKeyDown(Keys.Up) && prevKBState.IsKeyUp(Keys.Up))
            {
                selectedIndex--;
                if (selectedIndex == -1)
                {
                    selectedIndex = menuItems.Count - 1;
                }
            }

            prevKBState = currentKBState;
        }

        public override void Draw(GameTime gameTime)
        {
            Vector2 itemPosition = position;

            spriteBatch.Begin();
            for(int n = 0; n < menuItems.Count; n++)
            {
                if (selectedIndex == n)
                {
                    spriteBatch.DrawString(highlightFont, menuItems[n], itemPosition, highlightColor);
                    itemPosition.Y += highlightFont.LineSpacing;
                }
                else
                {
                    spriteBatch.DrawString(regularFont, menuItems[n], itemPosition, regularColor);
                    itemPosition.Y += regularFont.LineSpacing;
                }
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

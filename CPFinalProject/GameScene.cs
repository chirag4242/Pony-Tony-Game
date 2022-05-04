using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CPFinalProject
{
    class GameScene:DrawableGameComponent
    {
        public List<GameComponent> Components;
        public virtual void show()
        {
            this.Enabled = true;
            this.Visible = true;
        }

        public GameScene(Game game) : base(game)
        {
            Components = new List<GameComponent>();
            Hide();
        }

        public virtual void Hide()
        {
            this.Enabled = false;
            this.Visible = false;
        }


      

        public override void Update(GameTime gameTime)
        {
            foreach(GameComponent item in Components)
            {
                if (item.Enabled)
                {
                    item.Update(gameTime);
                }
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            DrawableGameComponent component = null;
            foreach(DrawableGameComponent item in Components)
            {
                component = (DrawableGameComponent)item;
                if (component.Visible)
                {
                    component.Draw(gameTime);
                }
            }
            base.Draw(gameTime);
        }
    }
}

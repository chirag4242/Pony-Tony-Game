using CPFinalProject.Models;
using CPFinalProject.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Text;


namespace CPFinalProject
{
    class ActionScene:GameScene
    {
        private SpriteBatch spriteBatch;
        
        private Score _score;
        private List<Sprite> _sprites;
        public ActionScene(Game game) : base(game)
        {
            
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ContentManager Content = ((GameWorld)game).Content;


            var batTexture = Content.Load<Texture2D>("Images/Bat");
            var ballTexture = Content.Load<Texture2D>("Images/Ball");

            _score = new Score(Content.Load<SpriteFont>("regularFont"));

            _sprites = new List<Sprite>()
         {
            new Sprite(Content.Load<Texture2D>("Images/Background")),
          new Bat(batTexture)
        {
          Position = new Vector2(20, (Shared.ScreenHeight / 2) - (batTexture.Height / 2)),
          Input = new Input()
          {
            Up = Keys.W,
            Down = Keys.S,
          }
        },
        new Bat(batTexture)
        {
          Position = new Vector2(Shared.ScreenWidth - 20 - batTexture.Width, (Shared.ScreenHeight / 2) - (batTexture.Height / 2)),
          Input = new Input()
          {
            Up = Keys.Up,
            Down = Keys.Down,
          }
        },
        new Ball(ballTexture)
        {
          Position = new Vector2((Shared.ScreenWidth / 2) - (ballTexture.Width / 2), (Shared.ScreenHeight / 2) - (ballTexture.Height / 2)),
          Score = _score,
        }
      };
        }


        public override void Update(GameTime gameTime)
        {
            foreach (var sprite in _sprites)
            {
                sprite.Update(gameTime, _sprites);
            }

            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            foreach (var sprite in _sprites)
                sprite.Draw(spriteBatch);

            _score.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

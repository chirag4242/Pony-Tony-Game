﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CPFinalProject.Sprites
{
  public class Ball : Sprite
  {
    private float timer = 0f; // Incrementing the speed over time
    private Vector2? startPosition = null;
    private float? startSpeed;
    private bool isPlaying;

    public Score Score;
    public int SpeedIncrementSpan = 10; // How often the speed will increment

    public Ball(Texture2D texture)
      : base(texture)
    {
      Speed = 3f;
    }

    public override void Update(GameTime gameTime, List<Sprite> sprites)
    {
      if (startPosition == null)
      {
        startPosition = Position;
        startSpeed = Speed;

        Restart();
      }

      if (Keyboard.GetState().IsKeyDown(Keys.Space))
        isPlaying = true;

      if (!isPlaying)
        return;

      timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

      if (timer > SpeedIncrementSpan)
      {
        Speed++;
        timer = 0;
      }

      foreach (var sprite in sprites)
      {
        if (sprite == this)
          continue;

        if (this.Velocity.X > 0 && this.IsTouchingLeft(sprite))
          this.Velocity.X = -this.Velocity.X;
        if (this.Velocity.X < 0 && this.IsTouchingRight(sprite))
          this.Velocity.X = -this.Velocity.X;
        if (this.Velocity.Y > 0 && this.IsTouchingTop(sprite))
          this.Velocity.Y = -this.Velocity.Y;
        if (this.Velocity.Y < 0 && this.IsTouchingBottom(sprite))
          this.Velocity.Y = -this.Velocity.Y;
      }

      if (Position.Y <= 0 || Position.Y + _texture.Height >= GameWorld.ScreenHeight)
        Velocity.Y = -Velocity.Y;

      if (Position.X <= 0)
      {
        Score.Score2++;
        Restart();
      }

      if (Position.X + _texture.Width >= GameWorld.ScreenWidth)
      {
        Score.Score1++;
        Restart();
      }

      Position += Velocity * Speed;
    }

    public void Restart()
    {
      var direction = GameWorld.Random.Next(0, 4);

      switch (direction)
      {
        case 0:
          Velocity = new Vector2(1, 1);
          break;
        case 1:
          Velocity = new Vector2(1, -1);
          break;
        case 2:
          Velocity = new Vector2(-1, -1);
          break;
        case 3:
          Velocity = new Vector2(-1, 1);
          break;
      }

      Position = (Vector2)startPosition;
      Speed = (float)startSpeed;
      timer = 0;
      isPlaying = false;
    }
  }
}

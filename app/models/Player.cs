using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Platformer.App.Models;
class Player
{
    Texture2D texture;
    Vector2 position;
    float playerSpeed, updatedPlayerSpeed, walk, run;
    int playerHeight,playerWidth;
    GameTime gameTime;
    GraphicsDeviceManager _graphics;
    KeyboardState kstate;

    public Player(GraphicsDeviceManager graphics)
    {
        position = new Vector2(graphics.PreferredBackBufferWidth / 2,
                                graphics.PreferredBackBufferHeight / 2);

        _graphics = graphics;
        playerSpeed = 100f;
    }
    public void setTexture(Texture2D texture2D)
    {
        this.texture = texture2D;
        playerHeight = texture.Height /2;
        playerWidth = texture.Width / 2;
    }
    public void Update(GameTime gameTime,KeyboardState keyboardState)
    {
        this.gameTime = gameTime;
        this.updatedPlayerSpeed = playerSpeed * (float)this.gameTime.ElapsedGameTime.TotalSeconds;
        this.walk = updatedPlayerSpeed;
        this.run = updatedPlayerSpeed + (updatedPlayerSpeed * 2);
        this.kstate = keyboardState;

        Movement();
        PreventOutOfBoundaries();

    }
    public void Draw(SpriteBatch _spriteBatch)
    {
        if (texture == null) return;

        _spriteBatch.Draw(
            texture,
            position,
            null,
            Color.White,
            0f,
            new Vector2(playerWidth, playerHeight),
            Vector2.One,
            SpriteEffects.None,
            0f
        );

    }

    public void Movement()
    {


        if (kstate.IsKeyDown(Keys.LeftShift))
        {
            updatedPlayerSpeed = run;
        }
        else
        {
            updatedPlayerSpeed = walk;

        }

        if (kstate.IsKeyDown(Keys.Up))
        {
            position.Y -= updatedPlayerSpeed;
        }

        if (kstate.IsKeyDown(Keys.Down))
        {
            position.Y += updatedPlayerSpeed;
        }

        if (kstate.IsKeyDown(Keys.Left))
        {
            position.X -= updatedPlayerSpeed;
        }

        if (kstate.IsKeyDown(Keys.Right))
        {
            position.X += updatedPlayerSpeed;
        }


    }

    public void PreventOutOfBoundaries()
    {
        if (position.Y > _graphics.PreferredBackBufferHeight - playerHeight)
        {
            position.Y = _graphics.PreferredBackBufferHeight - playerHeight;
        }
        else if (position.Y < playerHeight)
        {
            position.Y = playerHeight;
        }

        if (position.X > _graphics.PreferredBackBufferWidth - playerWidth)
        {
            position.X = _graphics.PreferredBackBufferWidth - playerWidth;
        }
        else if (position.X < playerWidth)
        {
            position.X = playerWidth;
        }
    }
}
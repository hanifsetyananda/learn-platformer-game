using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Platformer.App.Models;

namespace Platformer.App;

public class MainGame : Game
{
    Player player;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    public MainGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        player =  new Player(_graphics);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        player.setTexture(Content.Load<Texture2D>("ball"));

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        player.Update(gameTime,Keyboard.GetState());
       


        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        
        player.Draw(_spriteBatch);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}

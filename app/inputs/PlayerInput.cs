using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Platformer.App.Interfaces;

namespace Platformer.App.Inputs;
class PlayerInput  {
    private KeyboardState keyboardState;

    public PlayerInput(KeyboardState keyboardState){
        this.keyboardState = keyboardState;
    }

}
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Platformer.App.Interfaces;
interface PlayerInterface {
    void Jump();
    void Walk();
    void Run();
    void Left();
    void Right();
    void Crouch();
    
}
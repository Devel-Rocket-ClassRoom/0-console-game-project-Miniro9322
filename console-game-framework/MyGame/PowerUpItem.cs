using System;
using System.Collections.Generic;
using System.Text;
using Framework.Engine;

class PowerUpItem : GameObject
{
    private (int X, int Y) _position;
    private const char k_Body = '★';

    public PowerUpItem(Scene scene, (int, int) position) : base(scene)
    {
        Name = "PowerUpItem";

        _position = position;
    }

    public override void Draw(ScreenBuffer buffer)
    {
        buffer.SetCell(_position.X, _position.Y, k_Body, ConsoleColor.Cyan);
    }

    public override void Update(float deltaTime)
    {

    }
}

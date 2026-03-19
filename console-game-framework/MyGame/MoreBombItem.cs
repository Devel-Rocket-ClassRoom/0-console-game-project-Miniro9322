using System;
using System.Collections.Generic;
using System.Text;
using Framework.Engine;

class MoreBombItem : GameObject
{
    private const char k_Body = '◈';
    private (int X, int Y) _position;

    public MoreBombItem(Scene scene, (int, int) position) : base(scene)
    {
        Name = "PowerUpItem";

        _position = position;
    }

    public override void Draw(ScreenBuffer buffer)
    {
        buffer.SetCell(_position.X, _position.Y, k_Body, ConsoleColor.DarkCyan);
    }

    public override void Update(float deltaTime)
    {

    }
}

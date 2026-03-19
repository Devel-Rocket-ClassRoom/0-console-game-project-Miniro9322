using System;
using System.Collections.Generic;
using System.Text;
using Framework.Engine;

class SpeedUpItem : GameObject
{
    private const char k_Body = '♬';
    public (int X, int Y) Position { get; private set; }

    public SpeedUpItem(Scene scene, (int, int) position) : base(scene)
    {
        Name = "SpeedUpItem";

        Position = position;
    }

    public override void Draw(ScreenBuffer buffer)
    {
        buffer.SetCell(Position.X, Position.Y, k_Body, ConsoleColor.Magenta);
    }

    public override void Update(float deltaTime)
    {
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Framework.Engine;

class Enemy : GameObject
{
    private const char k_body = '●';
    public (int X, int Y) Position { get; private set; }

    public Enemy(Scene scene, (int, int) position) : base(scene)
    {
        Name = "Enemy";

        Position = position;
    }

    public override void Draw(ScreenBuffer buffer)
    {
        buffer.SetCell(Position.X, Position.Y, k_body, ConsoleColor.Red);
    }

    public override void Update(float deltaTime)
    {

    }
}

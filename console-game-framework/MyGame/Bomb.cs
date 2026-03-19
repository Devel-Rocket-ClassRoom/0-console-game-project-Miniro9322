using System;
using System.Collections.Generic;
using System.Text;
using Framework.Engine;

class Bomb : GameObject
{
    private const char k_body = '※';
    public (int X, int Y) Position { get; private set; }
    private const float k_BombInterval = 2.0f;
    private float _bombTimer;
    public ConsoleColor Color { get; private set; }

    public event GameAction<Bomb> Bombed;

    public Bomb(Scene scene, (int, int)position) : base(scene)
    {
        Name = "Bomb";

        _bombTimer = k_BombInterval;
        Position = position;
        Color = ConsoleColor.Green;
    }

    public override void Draw(ScreenBuffer buffer)
    {
        buffer.SetCell(Position.X, Position.Y, k_body, Color);
    }

    public override void Update(float deltaTime)
    {
        _bombTimer -= deltaTime;

        if( _bombTimer < 1.0f)
        {
            Color = ConsoleColor.Yellow;
        }
        if( _bombTimer < 0.5f)
        {
            Color = ConsoleColor.Red;
        }

        if(_bombTimer <= 0)
        {
            Bombed?.Invoke(this);
        }
    }
}

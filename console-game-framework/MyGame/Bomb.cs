using System;
using System.Collections.Generic;
using System.Text;
using Framework.Engine;

class Bomb : GameObject
{
    private const char k_body = '※';
    private (int X, int Y) _position;
    private const float k_BombInterval = 1.0f;
    private float _bombTimer;

    public event GameAction<(int, int)> Bombed;

    public Bomb(Scene scene, (int, int)position) : base(scene)
    {
        _bombTimer = k_BombInterval;
        _position = position;
    }

    public override void Draw(ScreenBuffer buffer)
    {
        buffer.SetCell(_position.X, _position.Y, k_body);
    }

    public override void Update(float deltaTime)
    {
        _bombTimer -= deltaTime;
        if(_bombTimer <= 0)
        {
            Bombed?.Invoke(_position);
        }
    }
}

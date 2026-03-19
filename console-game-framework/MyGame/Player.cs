using System;
using System.Collections.Generic;
using System.Text;
using Framework.Engine;

class Player : GameObject
{
    private float _moveInterval = 0.3f;
    private float _moveCoolTime;
    private const char k_body = '●';
    private bool _canMove;

    public (int X,  int Y) Position { get; private set; }
    public (int X, int Y) TempPosition { get; private set; }


    public Player(Scene scene, (int x, int y) position) : base(scene)
    {
        _moveCoolTime = _moveInterval;
        Position = position;
        TempPosition = Position;
        _canMove = false;
    }

    public override void Draw(ScreenBuffer buffer)
    {
        buffer.SetCell(Position.X, Position.Y, k_body, ConsoleColor.Green);
    }

    private void Move()
    {
        if (Input.IsKey(ConsoleKey.LeftArrow))
        {
            TempPosition = (Position.X - 1, Position.Y);
        }
        else if (Input.IsKey(ConsoleKey.UpArrow))
        {
            TempPosition = (Position.X, Position.Y - 1);
        }
        else if (Input.IsKey(ConsoleKey.RightArrow))
        {
            TempPosition = (Position.X + 1, Position.Y);
        }
        else if (Input.IsKey(ConsoleKey.DownArrow))
        {
            TempPosition = (Position.X, Position.Y + 1);
        }
    }

    public void CheckMoveable(bool isWall)
    {
        _canMove = !isWall;
        if (Position == TempPosition)
        {
            _canMove = false;
        }
    }

    public override void Update(float deltaTime)
    {
        if(_canMove == true)
        {
            Position = TempPosition;
            _moveCoolTime = _moveInterval;
        }

        _moveCoolTime -= deltaTime;
        if (_moveCoolTime <= 0)
        {
            Move();
        }
    }
}

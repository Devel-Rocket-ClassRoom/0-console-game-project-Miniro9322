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
    private Bomb _bomb;
    private bool _isDead = false;
    private int _power;

    public (int X,  int Y) Position { get; private set; }
    public (int X, int Y) TempPosition { get; private set; }

    public Player(Scene scene, (int x, int y) position) : base(scene)
    {
        _moveCoolTime = _moveInterval;
        Position = position;
        TempPosition = Position;
        _canMove = false;
        _power = 1;
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

    private void SetBomb()
    {
        if (Input.IsKeyDown(ConsoleKey.Z))
        {
            _bomb = new Bomb(base.Scene, Position);
            base.Scene.AddGameObject(_bomb);
            _bomb.Bombed += IsDead;
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

    public void IsDead((int X, int Y)position)
    {
        if(Position.X <= position.X + _power || Position.X >= position.X - _power && Position.Y <= position.Y + _power || Position.Y >= position.Y - _power)
        {
            _isDead = true;
        }
        base.Scene.RemoveGameObject(_bomb);
        _bomb = null;
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

        SetBomb();
    }
}

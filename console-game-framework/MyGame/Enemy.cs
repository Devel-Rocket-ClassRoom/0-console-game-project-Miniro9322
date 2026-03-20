using System;
using System.Collections.Generic;
using System.Text;
using Framework.Engine;

class Enemy : GameObject
{
    private float _moveInterval = 0.3f;
    private float _moveCoolTime;
    private const char k_body = '●';
    private bool _canMove;
    private bool _isDead = false;
    private int _power = 1;
    private int _bombCount = 1;
    private Random _random = new Random();
    private bool _isWarning;

    public (int X, int Y) Position { get; private set; }
    public (int X, int Y) TempPosition { get; private set; }
    public List<Bomb> Bombs { get; private set; } = new List<Bomb>();

    public event GameAction<(List<Bomb>, int)> BombSetted;

    public Enemy(Scene scene, (int x, int y) position) : base(scene)
    {
        Name = "Enemy";

        _moveCoolTime = _moveInterval;
        Position = position;
        TempPosition = Position;
        _canMove = false;
    }

    public override void Draw(ScreenBuffer buffer)
    {
        buffer.SetCell(Position.X, Position.Y, k_body, ConsoleColor.DarkRed);
    }

    private void Move()
    {
        int direction = _random.Next(4);

        switch (direction)
        {
            case 0:
                TempPosition = (Position.X - 1, Position.Y);
                break;
            case 1:
                TempPosition = (Position.X, Position.Y - 1);
                break;
            case 2:
                TempPosition = (Position.X + 1, Position.Y);
                break;
            case 3:
                TempPosition = (Position.X, Position.Y + 1);
                break;
        }
    }

    private void SetBomb()
    {
        if (_bombCount > 0)
        {
            var bomb = new Bomb(base.Scene, Position);

            Bombs.Add(bomb);
            base.Scene.AddGameObject(bomb);
            bomb.Bombed += DeleteBomb;
            bomb.Bombed += IsDead;

            _bombCount--;
        }
    }
    private void IsDead(Bomb bomb)
    {
        if (Position.X >= bomb.Position.X - _power && Position.X <= bomb.Position.X + _power && Position.Y == bomb.Position.Y || Position.Y >= bomb.Position.Y - _power && Position.Y >= bomb.Position.Y + _power && Position.X == bomb.Position.X)
        {
            if (_isWarning == true)
            {
                _isDead = true;
            }
        }
        else
        {
            _isDead = false;
        }
    }

    public void CheckWaringin(bool warning)
    {
        _isWarning = warning;
    }

    public void CheckMoveable(bool isWall)
    {
        _canMove = !isWall;
        if (Position == TempPosition)
        {
            _canMove = false;
        }
    }

    public void DeleteBomb(Bomb bomb)
    {
        base.Scene.RemoveGameObject(bomb);
        Bombs.Remove(bomb);
        _bombCount++;
    }

    public override void Update(float deltaTime)
    {
        if (_isDead == true)
        {
            return;
        }


        BombSetted?.Invoke((Bombs, _power));

        if (_canMove == true)
        {
            Position = TempPosition;
            _moveCoolTime = _moveInterval;
        }

        _moveCoolTime -= deltaTime;
        if (_moveCoolTime <= 0)
        {
            SetBomb();
            Move();
        }
    }

    public void GetSpeedItem()
    {
        if (_moveInterval > 0.1f)
        {
            _moveInterval -= 0.05f;
        }
    }

    public void GetPowerItem()
    {
        _power++;
    }

    public void GetBombItem()
    {
        _bombCount++;
    }
}

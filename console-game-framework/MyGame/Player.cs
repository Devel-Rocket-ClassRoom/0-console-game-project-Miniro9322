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
    public bool IsDead { get; private set; } = false;
    private int _power = 1;
    private int _bombCount = 1;
    private bool _isWarning;
    private (int X, int Y) _bombPosition;

    public (int X,  int Y) Position { get; private set; }
    public (int X, int Y) TempPosition { get; private set; }
    public List<Bomb> Bombs { get; private set; } = new List<Bomb>();

    public event GameAction<(List<Bomb>, int)> BombSetted;

    public Player(Scene scene, (int x, int y) position) : base(scene)
    {
        Name = "Player";

        _moveCoolTime = _moveInterval;
        Position = position;
        TempPosition = Position;
        _canMove = false;
    }

    public override void Draw(ScreenBuffer buffer)
    {
        buffer.SetCell(Position.X, Position.Y, k_body, ConsoleColor.Blue);
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
            if(_bombCount > 0)
            {
                if(_bombPosition == Position)
                {
                    return;
                }

                var bomb = new Bomb(base.Scene, Position);
                Bombs.Add(bomb);

                base.Scene.AddGameObject(bomb);
                bomb.Bombed += DeleteBomb;
                bomb.Bombed += IsBombed;

                _bombPosition = bomb.Position;

                BombSetted?.Invoke((Bombs, _power));

                _bombCount--;
            }
        }
    }

    public void CheckWarning(bool warning)
    {
        _isWarning = warning;
    }

    private void IsBombed(Bomb bomb)
    {
        if (Position.X >= bomb.Position.X - _power && Position.X <= bomb.Position.X + _power && Position.Y == bomb.Position.Y || Position.Y >= bomb.Position.Y - _power && Position.Y <= bomb.Position.Y + _power && Position.X == bomb.Position.X)
        {
            if(_isWarning == true)
            {
                IsDead = true;
            }
        }
        else
        {
            IsDead = false;
        }
    }

    public void CheckMoveable(bool isWall)
    {
        _canMove = !isWall;
        if (Position == TempPosition)
        {
            _canMove = false;
        }
        if(_bombPosition == TempPosition)
        {
            _canMove = false;
        }
    }

    public void DeleteBomb(Bomb bomb)
    {
        _bombPosition = default;
        base.Scene.RemoveGameObject(bomb);
        Bombs.Remove(bomb);
        _bombCount++;
    }

    public override void Update(float deltaTime)
    {
        if(IsDead == true)
        {
            return;
        }

        SetBomb();

        if (_canMove == true)
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

    public void GetSpeedItem()
    {
        if(_moveInterval > 0.1f)
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
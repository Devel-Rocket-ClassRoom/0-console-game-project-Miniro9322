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
    private bool _isDead = false;
    private int _power = 1;
    private int _bombCount = 1;

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
                Bombs.Add(new Bomb(base.Scene, Position));
                foreach (var bomb in Bombs)
                {
                    base.Scene.AddGameObject(bomb);
                    bomb.Bombed += IsDead;
                }

                _bombCount--;
            }
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

    public void IsDead(Bomb bomb)
    {
        if(Math.Abs(Position.X - bomb.Position.X) <= _power && Math.Abs(Position.Y - bomb.Position.Y) == 0 || Math.Abs(Position.X - bomb.Position.X) == 0 && Math.Abs(Position.Y - bomb.Position.Y) <= _power)
        {
            _isDead = true;
        }
        base.Scene.RemoveGameObject(bomb);
        Bombs.Remove(bomb);
        _bombCount++;
    }

    public override void Update(float deltaTime)
    {
        if(_isDead == true)
        {
            return;
        }

        SetBomb();

        BombSetted?.Invoke((Bombs, _power));

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
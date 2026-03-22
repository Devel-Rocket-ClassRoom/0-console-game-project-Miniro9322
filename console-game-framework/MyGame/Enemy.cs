using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Engine;

class Enemy : GameObject
{
    private float _moveInterval = 0.3f;
    private float _moveCoolTime;
    private const char k_body = '●';
    private bool _canMove;
    private int _bombCount = 1;
    private bool _isWarning;
    private (int X, int Y) _bombPosition;
    public List<(int, int)> Path;

    public bool IsDead { get; private set; } = false;
    public (int X, int Y) Position { get; private set; }
    public (int X, int Y) TempPosition { get; private set; }
    public List<Bomb> Bombs { get; private set; } = new List<Bomb>();
    public int Power { get; private set; }


    public event GameAction<(Bomb, int)> BombSetted;
    public event GameAction<Bomb> EnemyBombRequest;

    public Enemy(Scene scene, (int x, int y) position) : base(scene)
    {
        Name = "Enemy";

        _moveCoolTime = 0;
        Position = position;
        _canMove = false;
        TempPosition = Position;
    }

    public override void Draw(ScreenBuffer buffer)
    {
        buffer.SetCell(Position.X, Position.Y, k_body, ConsoleColor.DarkRed);
    }

    public void PathRequest(List<(int, int)> path)
    {
        Path = path;
    }

    private void Move()
    {
        if(Path?.Count > 0)
        {
            TempPosition = Path.First();
            Path.Remove(Path.First());
        }

        if(Path.Count == 0)
        {
            Path = null;
        }
    }

    public void SetBomb()
    {
        if (_bombCount > 0)
        {
            var bomb = new Bomb(base.Scene, Position);

            if (bomb.Position == _bombPosition)
            {
                return;
            }

            Bombs.Add(bomb);
            EnemyBombRequest?.Invoke(bomb);
            base.Scene.AddGameObject(bomb);
            bomb.Bombed += DeleteBomb;
            bomb.Bombed += IsBombed;

            BombSetted?.Invoke((bomb, Power));

            _bombPosition = bomb.Position;

            _bombCount--;
        }
    }

    public void EnemyBombSetted(Bomb bomb)
    {
        bomb.Bombed += IsBombed;
        _bombPosition = bomb.Position;
    }

    private void IsBombed(Bomb bomb)
    {
        if (Position.X >= bomb.Position.X - Power && Position.X <= bomb.Position.X + Power && Position.Y == bomb.Position.Y || Position.Y >= bomb.Position.Y - Power && Position.Y >= bomb.Position.Y + Power && Position.X == bomb.Position.X)
        {
            if (_isWarning == true)
            {
                IsDead = true;
            }
        }
        else
        {
            IsDead = false;
        }
    }

    public void CheckWarning(bool warning)
    {
        _isWarning = warning;
    }

    public void CheckMoveable(bool isWall)
    {
        _canMove = !isWall;

        if (_bombPosition == TempPosition)
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
        if (IsDead == true)
        {
            return;
        }

        _moveCoolTime -= deltaTime;
        if (_moveCoolTime <= 0)
        {
            if (_canMove == true)
            {
                Position = TempPosition;
                _moveCoolTime = _moveInterval;
            }
            else
            {
                SetBomb();
            }

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
        Power++;
    }

    public void GetBombItem()
    {
        _bombCount++;
    }

    public void ChasePlayer((int X, int Y)position)
    {

    }
}

using Framework.Engine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

class Tile : GameObject
{
    public bool IsDestroyable { get; private set; }
    public bool IsWall { get; private set; }

    public (int X, int Y) Position { get; private set; }

    private char _tile;
    private char _originalTile;

    private const float k_BombInterval = 2.0f;
    public bool IsBomb { get; private set; } = false;

    private ConsoleColor _color = ConsoleColor.Gray;

    public SpeedUpItem SpeedItem { get; private set; }
    public PowerUpItem PowerItem { get; private set; }
    public MoreBombItem BombItem { get; private set; }
    private Random _random = new Random();
    public bool IsWarning { get; private set; } = false;


    public Tile(Scene scene, (int x, int y) position, char type) : base(scene)
    {
        Name = "Tile";

        _tile = type;
        _originalTile = _tile;
        Position = position;

        switch (type)
        {
            case ' ':
                IsWall = false;
                IsDestroyable = false;
                break;
            case '█':
                IsWall = true;
                IsDestroyable = false;
                break;
            case '░':
                IsWall = true;
                IsDestroyable = true;
                break;
        }
    }

    public override void Update(float deltaTime)
    {

    }

    public override void Draw(ScreenBuffer buffer)
    {
        buffer.SetCell(Position.X, Position.Y, _tile, _color);
    }

    public void TileUpdate()
    {
        if(_tile == ' ')
        {
            _tile = '□';
            _color = ConsoleColor.Red;
        }
        IsWarning = true;
    }

    public void Bombset()
    {
        IsBomb = true;
    }

    public void SpeedItemGetted()
    {
        base.Scene.RemoveGameObject(SpeedItem);
        SpeedItem = null;
        
    }

    public void PowerItemGetted()
    {
        base.Scene.RemoveGameObject(PowerItem);
        PowerItem = null;

    }

    public void BombItemGetted()
    {
        base.Scene.RemoveGameObject(BombItem);
        BombItem = null;

    }

    public void OnBomebed(Bomb bomb)
    {
        _color = ConsoleColor.Gray;
        IsWarning = false;
        if (IsDestroyable == true)
        {
            _tile = ' ';
            _originalTile = _tile;
            int itemPercent = _random.Next(10);
            if(itemPercent < 3)
            {
                int itemNum = _random.Next(3);

                switch (itemNum)
                {
                    case 0:
                        SpeedItem = new SpeedUpItem(base.Scene, Position);
                        base.Scene.AddGameObject(SpeedItem);
                        break;
                    case 1:
                        PowerItem = new PowerUpItem(base.Scene, Position);
                        base.Scene.AddGameObject(PowerItem);
                        break;
                    case 2:
                        BombItem = new MoreBombItem(base.Scene, Position);
                        base.Scene.AddGameObject(BombItem);
                        break;
                }
            }
            IsWall = false;
            IsDestroyable = false;
            IsBomb = false;
        }
        else
        {
            _tile = _originalTile;
        }
    }
}
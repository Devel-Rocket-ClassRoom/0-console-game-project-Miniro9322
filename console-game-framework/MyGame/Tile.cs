using System;
using System.Collections.Generic;
using System.Text;
using Framework.Engine;

class Tile : GameObject
{
    private bool _isDestroyable;
    public bool IsWall { get; private set; }

    public (int X, int Y) Position { get; private set; }

    private char _tile;

    private ConsoleColor _color = ConsoleColor.Gray;

    private SpeedUpItem _speedItem;
    private PowerUpItem _powerItem;
    private MoreBombItem _bombItem;
    private Random _random = new Random();

    public Tile(Scene scene, (int x, int y) position, char type) : base(scene)
    {
        Name = "Tile";

        _tile = type;
        Position = position;

        switch (type)
        {
            case '□':
                IsWall = false;
                _isDestroyable = false;
                break;
            case '■':
                IsWall = true;
                _isDestroyable = false;
                break;
            case '▣':
                IsWall = true;
                _isDestroyable = true;
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

    public void TileUpdate(ConsoleColor color)
    {
        if(IsWall == false)
        {
            _color = color;
        }
        
    }

    public void OnBomebed(Bomb bomb)
    {
        _color = ConsoleColor.Gray;
        if(_isDestroyable == true)
        {
            int itemPercent = _random.Next(10);
            _tile = '□';
            if(itemPercent < 3)
            {
                int itemNum = _random.Next(3);

                switch (itemNum)
                {
                    case 0:
                        _speedItem = new SpeedUpItem(base.Scene, Position);
                        base.Scene.AddGameObject(_speedItem);
                        break;
                    case 1:
                        _powerItem = new PowerUpItem(base.Scene, Position);
                        base.Scene.AddGameObject(_powerItem);
                        break;
                    case 2:
                        _bombItem = new MoreBombItem(base.Scene, Position);
                        base.Scene.AddGameObject(_bombItem);
                        break;
                }
            }
            IsWall = false;
            _isDestroyable = false;
        }
    }
}
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

    public Tile(Scene scene, (int x, int y) position, char type) : base(scene)
    {
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

    public void ColorUpdate(ConsoleColor color)
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
            _tile = '□';
            IsWall = false;
        }
    }
}
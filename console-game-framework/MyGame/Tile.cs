using System;
using System.Collections.Generic;
using System.Text;
using Framework.Engine;

class Tile : GameObject
{
    private bool _isDestroyable;
    public bool IsWall { get; private set; }

    public (int X, int Y) Position { get; private set; }

    public char TileType { get; private set; }

    public Tile(Scene scene, (int x, int y) position, char type) : base(scene)
    {
        TileType = type;
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
        buffer.SetCell(Position.X, Position.Y, TileType);
    }
}
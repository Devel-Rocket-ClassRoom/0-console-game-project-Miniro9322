using System;
using System.Collections.Generic;
using System.Text;
using Framework.Engine;

class Tile
{
    private bool _isDestroyable = false;
    public char TileType { get; private set; }

    public Tile(string tileType = null)
    {
        switch (tileType)
        {
            case "Destroyable":
                TileType = '▣';
                _isDestroyable = true;
                break;
            case "NotDestroyable":
                TileType = '■';
                break;
            default:
                TileType = '□';
                break;
        }
    }
}
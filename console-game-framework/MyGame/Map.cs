using System;
using System.Collections.Generic;
using System.Text;
using Framework.Engine;

class Map : GameObject
{
    private List<Tile> _tiles;

    public Map(Scene scene) : base(scene)
    {
        Name = "Map";

        _tiles = new List<Tile>()
        {
            new Tile(), new Tile(), new Tile(), new Tile(), new Tile("NotDestroyable"), new Tile("NotDestroyable"), new Tile("NotDestroyable"), new Tile("NotDestroyable"), new Tile("NotDestroyable"), new Tile("Destroyable"), new Tile(), new Tile(), new Tile(),
            new Tile(), new Tile("NotDestroyable"), new Tile(), new Tile(), new Tile("NotDestroyable"), new Tile("NotDestroyable"), new Tile("NotDestroyable"), new Tile("NotDestroyable"), new Tile("NotDestroyable"), new Tile("NotDestroyable"), new Tile(), new Tile("NotDestroyable"), new Tile(),
            new Tile(), new Tile(), new Tile(), new Tile("Destroyable"), new Tile("Destroyable"), new Tile("Destroyable"), new Tile("Destroyable"), new Tile("Destroyable"), new Tile(), new Tile(), new Tile(), new Tile(), new Tile(),
            new Tile("Destroyable"), new Tile("NotDestroyable"), new Tile("Destroyable"), new Tile("NotDestroyable"), new Tile("Destroyable"), new Tile("NotDestroyable"), new Tile("Destroyable"), new Tile("NotDestroyable"), new Tile("Destroyable"), new Tile("NotDestroyable"), new Tile(), new Tile("NotDestroyable"), new Tile("Destroyable"),
            new Tile("Destroyable"), new Tile("Destroyable"), new Tile("Destroyable"), new Tile("Destroyable"), new Tile("Destroyable"), new Tile("Destroyable"), new Tile("Destroyable"), new Tile("Destroyable"), new Tile(), new Tile("Destroyable"), new Tile("Destroyable"), new Tile("Destroyable"), new Tile("Destroyable"),
            new Tile(), new Tile(), new Tile(), new Tile(), new Tile("Destroyable"), new Tile("NotDestroyable"), new Tile("Destroyable"), new Tile("NotDestroyable"), new Tile("Destroyable"), new Tile("NotDestroyable"), new Tile("Destroyable"), new Tile("NotDestroyable"), new Tile("Destroyable"),
            new Tile("Destroyable"), new Tile("Destroyable"), new Tile("Destroyable"), new Tile("Destroyable"), new Tile("Destroyable"), new Tile(), new Tile("Destroyable"), new Tile(), new Tile("Destroyable"), new Tile("Destroyable"), new Tile("Destroyable"), new Tile("Destroyable"), new Tile("Destroyable"),
            new Tile("Destroyable"), new Tile("NotDestroyable"), new Tile(), new Tile("NotDestroyable"), new Tile("Destroyable"), new Tile("NotDestroyable"), new Tile("Destroyable"), new Tile("NotDestroyable"), new Tile("Destroyable"), new Tile("NotDestroyable"), new Tile("Destroyable"), new Tile("NotDestroyable"), new Tile("Destroyable"),
            new Tile(), new Tile(), new Tile(), new Tile(), new Tile("NotDestroyable"), new Tile("NotDestroyable"), new Tile("NotDestroyable"), new Tile("NotDestroyable"), new Tile("NotDestroyable"), new Tile("Destroyable"), new Tile(), new Tile(), new Tile(),
            new Tile(), new Tile(), new Tile(), new Tile(), new Tile("NotDestroyable"), new Tile("NotDestroyable"), new Tile("NotDestroyable"), new Tile("NotDestroyable"), new Tile("NotDestroyable"), new Tile("Destroyable"), new Tile(), new Tile(), new Tile(),
            new Tile(), new Tile(), new Tile(), new Tile(), new Tile("NotDestroyable"), new Tile("NotDestroyable"), new Tile("NotDestroyable"), new Tile("NotDestroyable"), new Tile("NotDestroyable"), new Tile("Destroyable"), new Tile(), new Tile(), new Tile()

        };
    }

    public override void Draw(ScreenBuffer buffer)
    {
        for(int i = 0; i <  _tiles.Count; i++)
        {
            if(i % 13 == 0)
            {
                Console.WriteLine();
            }
            Console.Write(_tiles[i].TileType);
        }
    }

    public override void Update(float deltaTime)
    {

    }
}
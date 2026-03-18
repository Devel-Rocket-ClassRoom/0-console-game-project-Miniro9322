using System;
using System.Collections.Generic;
using System.Text;
using Framework.Engine;

class Map : GameObject
{
    private List<char> _tiles = new List<char>();

    public Map(Scene scene) : base(scene)
    {
        Name = "Map";

        for(int i = 0; i < 143; i++)
        {
            _tiles.Add('□');
        }
    }

    public override void Draw(ScreenBuffer buffer)
    {
        for(int i = 0; i <  _tiles.Count; i++)
        {
            if(i % 13 == 0)
            {
                Console.WriteLine();
            }
            Console.Write(_tiles[i]);
        }
    }

    public override void Update(float deltaTime)
    {

    }
}
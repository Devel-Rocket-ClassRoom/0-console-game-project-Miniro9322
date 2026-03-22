using Framework.Engine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;

class Map : GameObject 
{
    public List<Tile> Tiles { get; }

    public Map(Scene scene) : base(scene)
    {
        Name = "Map";

        Tiles = new List<Tile>()
        {
            new Tile(scene, (14, 5),' '), new Tile(scene, (15, 5),' '), new Tile(scene, (16, 5),' '), new Tile(scene, (17, 5),' '), new Tile(scene, (18, 5),'█'), new Tile(scene, (19, 5),'█'), new Tile(scene, (20, 5),'█'), new Tile(scene, (21, 5),'█'), new Tile(scene, (22, 5),'█'), new Tile(scene, (23, 5),'░'), new Tile(scene, (24, 5),' '), new Tile(scene, (25, 5),' '), new Tile(scene, (26, 5),' '),
            new Tile(scene, (14, 6),' '), new Tile(scene, (15, 6),'█'), new Tile(scene, (16, 6),' '), new Tile(scene, (17, 6),' '), new Tile(scene, (18, 6),'█'), new Tile(scene, (19, 6),'█'), new Tile(scene, (20, 6),'█'), new Tile(scene, (21, 6),'█'), new Tile(scene, (22, 6),'█'), new Tile(scene, (23, 6),'█'), new Tile(scene, (24, 6),' '), new Tile(scene, (25, 6),'█'), new Tile(scene, (26, 6),' '),
            new Tile(scene, (14, 7),' '), new Tile(scene, (15, 7),' '), new Tile(scene, (16, 7),' '), new Tile(scene, (17, 7),'░'), new Tile(scene, (18, 7),'░'), new Tile(scene, (19, 7),'░'), new Tile(scene, (20, 7),'░'), new Tile(scene, (21, 7),'░'), new Tile(scene, (22, 7),' '), new Tile(scene, (23, 7),' '), new Tile(scene, (24, 7),' '), new Tile(scene, (25, 7),' '), new Tile(scene, (26, 7),' '),
            new Tile(scene, (14, 8),' '), new Tile(scene, (15, 8),'█'), new Tile(scene, (16, 8),' '), new Tile(scene, (17, 8),'█'), new Tile(scene, (18, 8),'░'), new Tile(scene, (19, 8),'█'), new Tile(scene, (20, 8),'░'), new Tile(scene, (21, 8),'█'), new Tile(scene, (22, 8),'░'), new Tile(scene, (23, 8),'█'), new Tile(scene, (24, 8),' '), new Tile(scene, (25, 8),'█'), new Tile(scene, (26, 8),'░'),
            new Tile(scene, (14, 9),'░'), new Tile(scene, (15, 9),'░'), new Tile(scene, (16, 9),'░'), new Tile(scene, (17, 9),'░'), new Tile(scene, (18, 9),'░'), new Tile(scene, (19, 9),'░'), new Tile(scene, (20, 9),'░'), new Tile(scene, (21, 9),'░'), new Tile(scene, (22, 9),' '), new Tile(scene, (23, 9),'░'), new Tile(scene, (24, 9),'░'), new Tile(scene, (25, 9),'░'), new Tile(scene, (26, 9),'░'),
            new Tile(scene, (14, 10),' '), new Tile(scene, (15, 10),' '), new Tile(scene, (16, 10),' '), new Tile(scene, (17, 10),' '), new Tile(scene, (18, 10),'░'), new Tile(scene, (19, 10),'█'), new Tile(scene, (20, 10),'░'), new Tile(scene, (21, 10),'█'), new Tile(scene, (22, 10),'░'), new Tile(scene, (23, 10),'█'), new Tile(scene, (24, 10),'░'), new Tile(scene, (25, 10),'█'), new Tile(scene, (26, 10),'░'),
            new Tile(scene, (14, 11),'░'), new Tile(scene, (15, 11),'░'), new Tile(scene, (16, 11),'░'), new Tile(scene, (17, 11),'░'), new Tile(scene, (18, 11),'░'), new Tile(scene, (19, 11),' '), new Tile(scene, (20, 11),'░'), new Tile(scene, (21, 11),' '), new Tile(scene, (22, 11),'░'), new Tile(scene, (23, 11),'░'), new Tile(scene, (24, 11),'░'), new Tile(scene, (25, 11),'░'), new Tile(scene, (26, 11),'░'),
            new Tile(scene, (14, 12),'░'), new Tile(scene, (15, 12),'█'), new Tile(scene, (16, 12),' '), new Tile(scene, (17, 12),'█'), new Tile(scene, (18, 12),'░'), new Tile(scene, (19, 12),'█'), new Tile(scene, (20, 12),'░'), new Tile(scene, (21, 12),'█'), new Tile(scene, (22, 12),'░'), new Tile(scene, (23, 12),'█'), new Tile(scene, (24, 12),'░'), new Tile(scene, (25, 12),'█'), new Tile(scene, (26, 12),'░'),
            new Tile(scene, (14, 13),' '), new Tile(scene, (15, 13),' '), new Tile(scene, (16, 13),' '), new Tile(scene, (17, 13),' '), new Tile(scene, (18, 13),'░'), new Tile(scene, (19, 13),' '), new Tile(scene, (20, 13),'░'), new Tile(scene, (21, 13),' '), new Tile(scene, (22, 13),'░'), new Tile(scene, (23, 13),'░'), new Tile(scene, (24, 13),' '), new Tile(scene, (25, 13),' '), new Tile(scene, (26, 13),' '),
            new Tile(scene, (14, 14),' '), new Tile(scene, (15, 14),'█'), new Tile(scene, (16, 14),' '), new Tile(scene, (17, 14),'█'), new Tile(scene, (18, 14),'░'), new Tile(scene, (19, 14),'█'), new Tile(scene, (20, 14),'░'), new Tile(scene, (21, 14),'█'), new Tile(scene, (22, 14),'░'), new Tile(scene, (23, 14),'█'), new Tile(scene, (24, 14),' '), new Tile(scene, (25, 14),'█'), new Tile(scene, (26, 14),' '),
            new Tile(scene, (14, 15),' '), new Tile(scene, (15, 15),' '), new Tile(scene, (16, 15),' '), new Tile(scene, (17, 15),'░'), new Tile(scene, (18, 15),'░'), new Tile(scene, (19, 15),' '), new Tile(scene, (20, 15),'░'), new Tile(scene, (21, 15),' '), new Tile(scene, (22, 15),'░'), new Tile(scene, (23, 15),'░'), new Tile(scene, (24, 15),' '), new Tile(scene, (25, 15),' '), new Tile(scene, (26, 15),' ')
        };
    }

    public override void Draw(ScreenBuffer buffer)
    {
        foreach(var tile in Tiles)
        {
            tile.Draw(buffer);
        }
    }

    public bool OnWarning((int, int) position)
    {
        var tile = Tiles.Find(x => x.Position == position);

        if (tile == null)
        {
            return false;
        }

        return tile.IsWarning;
    }

    public void BombSetted((Bomb bomb, int power) info)
    {
        int index = 0;

        var tile = Tiles.Find(x => x.Position == info.bomb.Position);

        index = Tiles.IndexOf(tile);


        Tiles[index].TileUpdate();
        Tiles[index].Bombset();
        info.bomb.Bombed += Tiles[index].OnBomebed;

        for (int i = 1; i <= info.power; i++)
        {
            if(index - i < 0)
            {
                break;
            }

            if(Tiles[index - i].Position.Y != Tiles[index].Position.Y)
            {
                break;
            }

            Tiles[index - i].TileUpdate();
            info.bomb.Bombed += Tiles[index - i].OnBomebed;

            if (Tiles[index - i].IsWall == true)
            {
                break;
            }
        }

        for (int i = 1; i <= info.power; i++)
        {
            if(index + i >= Tiles.Count)
            {
                break;
            }

            if (Tiles[index + i].Position.Y != Tiles[index].Position.Y)
            {
                break;
            }

            Tiles[index + i].TileUpdate();
            info.bomb.Bombed += Tiles[index + i].OnBomebed;

            if (Tiles[index + i].IsWall == true)
            {
                break;
            }
        }

        for (int i = 1; i <= info.power; i++)
        {
            if(index - 13 * i < 0)
            {
                break;
            }

            Tiles[index - 13 * i].TileUpdate();
            info.bomb.Bombed += Tiles[index - 13 * i].OnBomebed;
            if (Tiles[index - 13 * i].IsWall == true)
            {
                break;
            }
        }

        for (int i = 1; i <= info.power; i++)
        {
            if (index + 13 * i >= Tiles.Count)
            {
                break;
            }

            Tiles[index + 13*i].TileUpdate();
            info.bomb.Bombed += Tiles[index + 13 * i].OnBomebed;
            if (Tiles[index + 13 * i].IsWall == true)
            {
                break;
            }
        }
    }

    public bool CheckWall((int X, int Y) position)
    {
        var tile = Tiles.Find(x => x.Position == position);

        if(tile == null)
        {
            return true;
        }
        if(tile.IsBomb == true)
        {
            return tile.IsBomb;
        }

        return tile.IsWall;
    }

    public bool CheckDestoryable((int X, int Y) position)
    {
        var tile = Tiles.Find(x => x.Position == position);

        if( tile == null)
        {
            return false;
        }
        return tile.IsDestroyable;
    }

    public void CheckItem(Player player)
    {
        foreach (var tile in Tiles)
        {
            if (tile.SpeedItem?.Position == player.Position)
            {
                player.GetSpeedItem();
                tile.SpeedItemGetted();
                break;
            }
            if (tile.PowerItem?.Position == player.Position)
            {
                player.GetPowerItem();
                tile.PowerItemGetted();
                break;
            }
            if (tile.BombItem?.Position == player.Position)
            {
                player.GetBombItem();
                tile.BombItemGetted();
                break;
            }
        }
    }

    public void CheckItem(Player2 player)
    {
        foreach (var tile in Tiles)
        {
            if (tile.SpeedItem?.Position == player.Position)
            {
                player.GetSpeedItem();
                tile.SpeedItemGetted();
                break;
            }
            if (tile.PowerItem?.Position == player.Position)
            {
                player.GetPowerItem();
                tile.PowerItemGetted();
                break;
            }
            if (tile.BombItem?.Position == player.Position)
            {
                player.GetBombItem();
                tile.BombItemGetted();
                break;
            }
        }
    }

    public void CheckItem(Enemy enemy)
    {
        foreach (var tile in Tiles)
        {
            if (tile.SpeedItem?.Position == enemy.Position)
            {
                enemy.GetSpeedItem();
                tile.SpeedItemGetted();
                break;
            }
            if (tile.PowerItem?.Position == enemy.Position)
            {
                enemy.GetPowerItem();
                tile.PowerItemGetted();
                break;
            }
            if (tile.BombItem?.Position == enemy.Position)
            {
                enemy.GetBombItem();
                tile.BombItemGetted();
                break;
            }
        }
    }

    public override void Update(float deltaTime)
    {

    }

    public List<(int, int)> ChasePlayer((int x, int y) start, (int x, int y) goal)
    {
        var first = Tiles.Find(x => x.Position == start);
        
        Queue<Tile> bfs = new Queue<Tile>();
        HashSet<Tile> visited = new HashSet<Tile>();
        Dictionary<Tile, Tile> parent = new Dictionary<Tile, Tile>();

        bfs.Enqueue(first);
        visited.Add(first);

        while (bfs.Count > 0)
        {
            var current = bfs.Dequeue();

            if(current.Position == goal)
            {
                List<(int, int)> path = new List<(int, int)> ();

                while (parent.ContainsKey(current))
                {
                    path.Add(current.Position);
                    current = parent[current];
                }

                path.Reverse();
                return path;
            }

            var index = Tiles.IndexOf(current);

            if (index + 1 < Tiles.Count && visited.Contains(Tiles[index + 1]) == false && Tiles[index + 1].Position.Y == current.Position.Y && (Tiles[index + 1].IsWall != true || Tiles[index + 1].IsWall == true && Tiles[index + 1].IsDestroyable == true))
            {
                bfs.Enqueue(Tiles[index + 1]);
                visited.Add(Tiles[index + 1]);
                parent[Tiles[index + 1]] = current;
            }

            if (index - 1 >= 0 && visited.Contains(Tiles[index - 1]) == false && Tiles[index - 1].Position.Y == current.Position.Y && (Tiles[index - 1].IsWall != true || Tiles[index - 1].IsWall == true && Tiles[index - 1].IsDestroyable == true))
            {
                bfs.Enqueue(Tiles[index - 1]);
                visited.Add(Tiles[index - 1]);
                parent[Tiles[index - 1]] = current;
            }

            if (index + 13 < Tiles.Count && visited.Contains(Tiles[index + 13]) == false && Tiles[index + 13].Position.X == current.Position.X && (Tiles[index + 13].IsWall != true || Tiles[index + 13].IsWall == true && Tiles[index + 13].IsDestroyable == true))
            {
                bfs.Enqueue(Tiles[index + 13]);
                visited.Add(Tiles[index + 13]);
                parent[Tiles[index + 13]] = current;
            }

            if (index - 13 >=0 && visited.Contains(Tiles[index - 13]) == false && Tiles[index - 13].Position.X == current.Position.X && (Tiles[index - 13].IsWall != true || Tiles[index - 13].IsWall == true && Tiles[index - 13].IsDestroyable == true))
            {
                bfs.Enqueue(Tiles[index - 13]);
                visited.Add(Tiles[index - 13]);
                parent[Tiles[index - 13]] = current;
            }
        }
        return null;
    }

    public List<(int, int)> FindSafe((int x, int y) start)
    {
        var first = Tiles.Find(x => x.Position == start);

        Queue<Tile> bfs = new Queue<Tile>();
        HashSet<Tile> visited = new HashSet<Tile>();
        Dictionary<Tile, Tile> parent = new Dictionary<Tile, Tile>();

        bfs.Enqueue(first);
        visited.Add(first);

        while (bfs.Count > 0)
        {
            var current = bfs.Dequeue();
            
            var index = Tiles.IndexOf(current);

            if (Tiles[index].IsWall == false && Tiles[index].IsWarning == false)
            {
                List<(int, int)> path = new List<(int, int)>();
                
                while (parent.ContainsKey(current))
                {
                    path.Add(current.Position);
                    current = parent[current];    
                }

                path.Reverse();
                return path;
            }

            if (index + 1 < Tiles.Count && visited.Contains(Tiles[index + 1]) == false && Tiles[index + 1].Position.Y == current.Position.Y && Tiles[index + 1].IsWall != true)
            {
                bfs.Enqueue(Tiles[index + 1]);
                visited.Add(Tiles[index + 1]);
                parent[Tiles[index + 1]] = current;
            }

            if (index - 1 >= 0 && visited.Contains(Tiles[index - 1]) == false && Tiles[index - 1].Position.Y == current.Position.Y && Tiles[index - 1].IsWall != true)
            {
                bfs.Enqueue(Tiles[index - 1]);
                visited.Add(Tiles[index - 1]);
                parent[Tiles[index - 1]] = current;
            }

            if (index + 13 < Tiles.Count && visited.Contains(Tiles[index + 13]) == false && Tiles[index + 13].Position.X == current.Position.X && Tiles[index + 13].IsWall != true)
            {
                bfs.Enqueue(Tiles[index + 13]);
                visited.Add(Tiles[index + 13]);
                parent[Tiles[index + 13]] = current;
            }

            if (index - 13 >= 0 && visited.Contains(Tiles[index - 13]) == false && Tiles[index - 13].Position.X == current.Position.X && Tiles[index - 13].IsWall != true)
            {
                bfs.Enqueue(Tiles[index - 13]);
                visited.Add(Tiles[index - 13]);
                parent[Tiles[index - 13]] = current;
            }
        }
        return null;
    }
}
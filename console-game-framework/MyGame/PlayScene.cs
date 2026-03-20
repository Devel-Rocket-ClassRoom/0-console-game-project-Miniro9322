using System;
using System.Collections.Generic;
using System.Text;
using Framework.Engine;

class PlayScene : Scene
{
    public event GameAction PlayAganRequested;
    private Map map;
    private Enemy enemy;
    private Player player;

    public override void Draw(ScreenBuffer buffer)
    {
        DrawGameObjects(buffer);
    }

    public override void Load()
    {
        map = new Map(this);
        enemy = new Enemy(this, (14, 5));
        player = new Player(this, (26, 5));

        player.BombSetted += map.BombSetted;
        enemy.BombSetted += map.BombSetted;

        AddGameObject(map);
        AddGameObject(enemy);
        AddGameObject(player);
    }

    public override void Unload()
    {

    }

    public override void Update(float deltaTime)
    {
        player.CheckMoveable(map.CheckWall(player.TempPosition));
        enemy.CheckMoveable(map.CheckWall(enemy.TempPosition));
        player.CheckWaringin(map.OnWarning(player.Position));
        enemy.CheckWaringin(map.OnWarning(enemy.Position));
        map.CheckItem(player);
        map.CheckItem(enemy);


        UpdateGameObjects(deltaTime);
    }
}

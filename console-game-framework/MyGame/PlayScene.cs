using System;
using System.Collections.Generic;
using System.Text;
using Framework.Engine;

class PlayScene : Scene
{
    public event GameAction PlayAganRequested;
    private Map map;

    public override void Draw(ScreenBuffer buffer)
    {
        DrawGameObjects(buffer);
    }

    public override void Load()
    {
        map = new Map(this);

        AddGameObject(map);
    }

    public override void Unload()
    {

    }

    public override void Update(float deltaTime)
    {

    }
}

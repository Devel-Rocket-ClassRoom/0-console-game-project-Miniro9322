using System;
using System.Collections.Generic;
using System.Text;
using Framework.Engine;

class SelectModeScene : Scene
{
    public event GameAction ModeRequested;
    public event GameAction ModeRequested2;

    public override void Draw(ScreenBuffer buffer)
    {
        buffer.WriteTextCentered(4, "ModeSelect", ConsoleColor.Yellow);
        buffer.WriteTextCentered(10, "1. vs AI");
        buffer.WriteTextCentered(12, "2. vs Human");
    }

    public override void Load()
    {

    }

    public override void Unload()
    {

    }

    public override void Update(float deltaTime)
    {
        if (Input.IsKeyDown(ConsoleKey.D1))
        {
            ModeRequested?.Invoke();
        }
        if (Input.IsKeyDown(ConsoleKey.D2))
        {
            ModeRequested2?.Invoke();
        }
    }


}
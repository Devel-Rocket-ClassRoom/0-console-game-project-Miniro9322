using System;
using System.Collections.Generic;
using System.Text;
using Framework.Engine;

class TitleScene : Scene
{
    public event GameAction StartRequested;

    public override void Load() { }

    public override void Unload() { }

    public override void Update(float deltaTime)
    {
        if (Input.IsKeyDown(ConsoleKey.Enter))
        {
            StartRequested?.Invoke();
        }
    }

    public override void Draw(ScreenBuffer buffer)
    {
        buffer.WriteTextCentered(4, "BomberMan", ConsoleColor.Yellow);
        buffer.WriteTextCentered(8, "Arrows Keys: Move");
        buffer.WriteTextCentered(10, "Z: Bomb");
        buffer.WriteTextCentered(12, "ESC: Quit");
        buffer.WriteTextCentered(15, "Press ENTER to Start", ConsoleColor.Green);
    }
}
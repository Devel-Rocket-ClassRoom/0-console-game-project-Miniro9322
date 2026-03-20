using System;
using System.Collections.Generic;
using System.Text;
using Framework.Engine;

class BomberMan : GameApp
{
    private readonly SceneManager<Scene> _scenes = new SceneManager<Scene>();

    public BomberMan() : base(40, 20) { }

    public BomberMan(int width, int height) : base(width, height) { }

    protected override void Initialize()
    {
        ChangeToTitle();
    }

    protected override void Draw()
    {
        _scenes.CurrentScene?.Draw(Buffer);
    }

    protected override void Update(float deltaTime)
    {
        if (Input.IsKeyDown(ConsoleKey.Escape))
        {
            Quit();
            return;
        }

        _scenes.CurrentScene?.Update(deltaTime);
    }

    private void ChangeToTitle()
    {
        var title = new TitleScene();
        title.StartRequested += ChangeToPlay;
        Console.Clear();
        _scenes.ChangeScene(title);
    }

    private void ChangeToPlay()
    {
        var play = new PlayScene();
        play.PlayAgainRequested += ChangeToTitle;
        _scenes.ChangeScene(play);
    }
}
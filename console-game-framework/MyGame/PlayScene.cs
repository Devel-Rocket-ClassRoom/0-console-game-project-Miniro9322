using System;
using System.Collections.Generic;
using System.Text;
using Framework.Engine;

class PlayScene : Scene
{
    public event GameAction PlayAgainRequested;
    private Map map;
    private Enemy enemy;
    private Player player;
    private bool _isGameOver;
    private string _gameResult;

    public override void Draw(ScreenBuffer buffer)
    {
        DrawGameObjects(buffer);

        buffer.WriteText(1, 0, $"★ : 폭탄 범위 증가 ♬ : 이동 속도 증가 ◈ : 폭탄 설치 가능 개수 증가", ConsoleColor.Cyan);
        buffer.WriteText(1, 19, "Arrow Keys: Move Z: SetBomb", ConsoleColor.DarkGray);

        if (_isGameOver == true)
        {
            RemoveGameObject(map);
            buffer.WriteTextCentered(8, "GAME OVER", ConsoleColor.Red);
            buffer.WriteTextCentered(10, $"{_gameResult}", ConsoleColor.Yellow);
            buffer.WriteTextCentered(12, "Press ENTER to Retry", ConsoleColor.White);
        }
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
        if (_isGameOver)
        {
            if (Input.IsKeyDown(ConsoleKey.Enter))
            {
                PlayAgainRequested?.Invoke();
            }
            return;
        }

        if (enemy.IsDead == true)
        {
            _isGameOver = true;
            _gameResult = "You Win!";
            return;
        }

        if (player.IsDead == true)
        {
            _isGameOver = true;
            _gameResult = "You Lose...";
            return;
        }

        player.CheckMoveable(map.CheckWall(player.TempPosition));
        enemy.CheckMoveable(map.CheckWall(enemy.TempPosition));
        player.CheckWaringin(map.OnWarning(player.Position));
        enemy.CheckWaringin(map.OnWarning(enemy.Position));
        map.CheckItem(player);
        map.CheckItem(enemy);


        UpdateGameObjects(deltaTime);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Framework.Engine;

class PlayScene2 : Scene
{
    public event GameAction PlayAgainRequested;
    private Map map;
    private Player2 player2;
    private Player player;
    private bool _isGameOver;
    private string _gameResult;
    private int _gamemode;

    public override void Draw(ScreenBuffer buffer)
    {
        DrawGameObjects(buffer);

        buffer.WriteText(1, 0, $"★ : 폭탄 범위 증가 ♬ : 이동 속도 증가 ◈ : 폭탄 개수 증가", ConsoleColor.Cyan);
        buffer.WriteText(1, 1, $"█ : 벽 ░ : 상자", ConsoleColor.Cyan);
        buffer.WriteText(1, 18, "1P Arrows Keys: Move NumPad 0: Bomb", ConsoleColor.DarkGray);
        buffer.WriteText(1, 19, "2P WASD: Move Spaceber: Bomb", ConsoleColor.DarkGray);

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
        player2 = new Player2(this, (14, 5));
        player = new Player(this, (26, 5));

        player.BombSetted += map.BombSetted;
        player2.BombSetted += map.BombSetted;
        player.EnemyBombRequest += player2.EnemyBombSetted;
        player2.EnemyBombRequest += player.EnemyBombSetted;


        AddGameObject(map);
        AddGameObject(player2);
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

        if (player2.IsDead == true)
        {
            _isGameOver = true;
            _gameResult = "1P Win!";
            return;
        }

        if (player.IsDead == true)
        {
            _isGameOver = true;
            _gameResult = "2P Win!";
            return;
        }

        player.CheckMoveable(map.CheckWall(player.TempPosition));
        player2.CheckMoveable(map.CheckWall(player2.TempPosition));
        player.CheckWarning(map.OnWarning(player.Position));
        player2.CheckWarning(map.OnWarning(player2.Position));
        map.CheckItem(player);
        map.CheckItem(player2);

        UpdateGameObjects(deltaTime);

    }
}

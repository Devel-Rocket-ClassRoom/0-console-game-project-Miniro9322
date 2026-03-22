using System;
using Framework.Engine;

class PlayScene : Scene
{
    public event GameAction PlayAgainRequested;
    private Map map;
    private Enemy enemy;
    private Player player;
    private bool _isGameOver;
    private string _gameResult;
    private int _gamemode;

    public override void Draw(ScreenBuffer buffer)
    {
        DrawGameObjects(buffer);

        buffer.WriteText(1, 0, $"★ : 폭탄 범위 증가 ♬ : 이동 속도 증가 ◈ : 폭탄 개수 증가", ConsoleColor.Cyan);
        buffer.WriteText(1, 1, $"█ : 벽 ░ : 상자", ConsoleColor.Cyan);
        buffer.WriteText(1, 19, "Arrow Keys: Numpad 0: SetBomb", ConsoleColor.DarkGray);

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
        player.EnemyBombRequest += enemy.EnemyBombSetted;
        enemy.EnemyBombRequest += player.EnemyBombSetted;


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

        if(enemy.Path == null)
        {
            enemy.PathRequest(map.ChasePlayer(enemy.Position, player.Position));
        }

        if (map.OnWarning(enemy.Position) == true)
        {
            enemy.PathRequest(map.FindSafe(enemy.Position));
        }

        player.CheckMoveable(map.CheckWall(player.TempPosition));
        enemy.CheckMoveable(map.CheckWall(enemy.TempPosition));

        if(player.Position.Y == enemy.Position.Y && player.Position.X >= enemy.Position.X - enemy.Power && player.Position.X <= enemy.Position.X + enemy.Power || player.Position.X == enemy.Position.X && player.Position.Y >= enemy.Position.Y - enemy.Power && player.Position.Y <= enemy.Position.Y + enemy.Power)
        {
            enemy.SetBomb();
        }

        player.CheckWarning(map.OnWarning(player.Position));
        enemy.CheckWarning(map.OnWarning(enemy.Position));
        map.CheckItem(player);
        map.CheckItem(enemy);

        UpdateGameObjects(deltaTime);

    }
}

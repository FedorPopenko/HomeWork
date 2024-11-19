public class Sticks
{
    public enum PlayerType
    {
        None,
        Human,
        Computer
    };

    public class GameState
    {
        public PlayerType[] Players { get; set; }
        public int TotalSticks { get; set; }
        public PlayerType Winner { get; set; }
    }

    public GameState State { get; private set; }

    public Sticks(PlayerType firstPlayer, int totalSticks)
    {
        State = new GameState
        {
            Players = [
                firstPlayer,
                firstPlayer == PlayerType.Human ?
                    PlayerType.Computer :
                    PlayerType.Human
            ],
            TotalSticks = totalSticks,
            Winner = PlayerType.None
        };
    }

    public void MakeTurn(PlayerType player)
    {
        switch (player)
        {
            case PlayerType.Human:
                ActionHuman();
                break;
            case PlayerType.Computer:
                ActionMachine();
                break;
            default:
                throw new ArgumentException("Player not known.");
        }
        CalculateWinner(player);
    }

    void CalculateWinner(PlayerType player)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{State.TotalSticks} sticks left");
        Console.ResetColor();
        if (State.TotalSticks > 0)
            return;
        State.Winner = player;
        switch (State.Winner)
        {
            case PlayerType.Human:
                Console.WriteLine("Congratulations, you won!");
                break;
            case PlayerType.Computer:
                Console.WriteLine("Sorry, you lost!");
                break;
            default:
                throw new ArgumentException("Player not known.");
        }
        Console.ReadLine();
    }

    void ActionHuman()
    {
        Console.WriteLine("Your move:");
        int quantitySticks = int.Parse(Console.ReadLine());
        if (quantitySticks > 0 && quantitySticks < 4)
            State.TotalSticks -= quantitySticks;
        else
        {
            Console.WriteLine("Enter a number from 1 to 3");
            ActionHuman();
        }
    }

    void ActionMachine()
    {
        Console.WriteLine("My move:");
        Random random = new Random();
        int quantitySticks = random.Next(1, 3);
        State.TotalSticks -= quantitySticks;
        Console.WriteLine($"{quantitySticks}");
    }
}

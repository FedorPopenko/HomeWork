public class Sticks
{
    int totalSticks;

    public delegate void Remainger(int sticksLeft);

    private Remainger _remainger;
    public void Start()
    {
        totalSticks = int.Parse(Console.ReadLine());
    }
    public void Stop()
    {
        totalSticks = 0;
        System.Environment.Exit(0);
        Console.ReadLine();
    }
    public void actionHuman()
    {
        int quantitySticks = int.Parse(Console.ReadLine());
        if (quantitySticks > 0 && quantitySticks < 4)
        {
            totalSticks -= quantitySticks;
            if (totalSticks > 0)
                _remainger(totalSticks);
            if (totalSticks <= 0)
                _remainger(0);
        }
        else
        {
            throw new ArgumentException("Enter a number from 1 to 3");
        }
    }
    public void actionMachine()
    {
        Random random = new Random();
        int quantitySticks = random.Next(1, 3);
        totalSticks -= quantitySticks;
        Console.WriteLine($"{quantitySticks}");
        if (totalSticks > 0)
            _remainger(totalSticks);
        if (totalSticks <= 0)
            _remainger(0);

    }
    public void RegisterRemainger(Remainger remainger)
    {
        this._remainger = remainger;
    }
}

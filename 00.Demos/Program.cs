namespace _00.Demos;

internal class Program
{
    static void Main(string[] args)
    {
        IFlyable plane = new Plane
        {
            Engine = "Jet Engine",
            Wings = new string[] { "Left Wing", "Right Wing" }
        };

        IMammal duck = new Duck
        {
            Wings = new string[] { "Left Wing", "Right Wing" },
            Lungs = new string[] { "Left Lung", "Right Lung" }
        };
    }
}


public interface IFlyable
{
    string[] Wings { get; set; }
}

public interface IMammal
{
    string[] Lungs { get; set; }
}

public class Plane : IFlyable
{
    public string Engine { get; set; }
    public string[] Wings { get; set; }
}

public class Duck : IFlyable, IMammal
{
    public string[] Wings { get; set; }
    public string[] Lungs { get; set; }
}

namespace Robots.Contracts
{
    public interface IRobot
    {
        string Heading { get; }
        ILocation Location { get; set; }
        void Turn(string turn);
        void Move();
        void Instructions(string instructionString);
    }
}
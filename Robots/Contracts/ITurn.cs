namespace Robots.Contracts
{
    public interface ITurn
    {
        void Turn(string turn);
    }

    public interface IReceiveInstruction
    {
        void Instructions(string instructionString);
    }
}
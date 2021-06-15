namespace ToolBox.Signals
{
    public interface IReceiver<S>
    {
        void Receive(in S value);
    }
}
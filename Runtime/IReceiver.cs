namespace ToolBox.Signals
{
    public interface IReceiver<S> where S : struct, ISignal
    {
        void Receive(in S value);
    }
}
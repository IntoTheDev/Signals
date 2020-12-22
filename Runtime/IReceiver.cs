namespace ToolBox.Signals
{
	public interface IReceiver { }

	public interface IReceiver<T> : IReceiver
	{
		void Receive(in T value);
	}
}
	

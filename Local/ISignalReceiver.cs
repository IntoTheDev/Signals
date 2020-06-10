namespace ToolBox.Signals.Local
{
	public interface ISignalReceiver
	{
		void Receive();
	}

	public interface ISignalReceiver<T>
	{
		void Receive(T value);
	}
}

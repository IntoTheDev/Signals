namespace ToolBox.Observer
{
	public interface IReceiver<T>
	{
		void OnSignalDispatched(T value);
	}

	public interface IReceiver
	{
		void OnSignalDispatched();
	}
}
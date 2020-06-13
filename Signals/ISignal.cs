namespace ToolBox.Signals
{
	public interface ISignal<T>
	{
		void Dispatch(T value);
		void Add(IReceiver<T> listener);
		void Remove(IReceiver<T> listener);
	}

	public interface ISignal
	{
		void Dispatch();
		void Add(IReceiver listener);
		void Remove(IReceiver listener);
	}
}

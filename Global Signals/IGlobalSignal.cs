namespace ToolBox.Observer
{
	public interface IGlobalSignal<T>
	{
		void Dispatch(T value);
		void Add(IReceiver<T> listener);
		void Remove(IReceiver<T> listener);
	}

	public interface IGlobalSignal
	{
		void Dispatch();
		void Add(IReceiver listener);
		void Remove(IReceiver listener);
	}
}

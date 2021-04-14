using System;
using System.Collections.Generic;

namespace ToolBox.Signals
{// Updater test
	public static class Hub
	{
		private static Dictionary<int, List<IReceiver>> _signals = new Dictionary<int, List<IReceiver>>();

		public static void Dispatch<T>(in T value)
		{
			int hash = typeof(T).GetHashCode();

			if (!_signals.TryGetValue(hash, out var receivers))
				return;

			int count = receivers.Count;

			for (int i = count - 1; i >= 0; i--)
				(receivers[i] as IReceiver<T>).Receive(in value);
		}

		public static void Add<T>(IReceiver<T> receiver)
		{
			int hash = typeof(T).GetHashCode();

			if (_signals.TryGetValue(hash, out List<IReceiver> receivers) && !receivers.Contains(receiver))
			{
				receivers.Add(receiver);

				return;
			}

			_signals.Add(hash, new List<IReceiver> { receiver });
		}

		public static void Remove<T>(IReceiver<T> receiver)
		{
			int hash = typeof(T).GetHashCode();

			if (_signals.TryGetValue(hash, out List<IReceiver> receivers) && receivers.Contains(receiver))
				receivers.Remove(receiver);
		}
	}
}

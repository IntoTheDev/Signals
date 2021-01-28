using System;
using System.Collections.Generic;

namespace ToolBox.Signals
{
	public static class Hub
	{
		private static Dictionary<int, List<IReceiver>> _signals = new Dictionary<int, List<IReceiver>>();
		private static Dictionary<string, List<IReceiver>> _readableSignals = new Dictionary<string, List<IReceiver>>();

		public static event Action<string, string> OnSignalDispatched = null;
		public static IReadOnlyDictionary<string, List<IReceiver>> ReadableSignals => _readableSignals;

		public static void Dispatch<T>(in T value)
		{
			int hash = typeof(T).GetHashCode();
#if UNITY_EDITOR && ODIN_INSPECTOR
			OnSignalDispatched?.Invoke(typeof(T).Name, value.ToString());
#endif

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

#if UNITY_EDITOR && ODIN_INSPECTOR
				_readableSignals.TryGetValue(typeof(T).Name, out var value);
				value.Add(receiver);
#endif

				return;
			}

			_signals.Add(hash, new List<IReceiver> { receiver });
#if UNITY_EDITOR && ODIN_INSPECTOR
			_readableSignals.Add(typeof(T).Name, new List<IReceiver> { receiver });
#endif
		}

		public static void Remove<T>(IReceiver<T> receiver)
		{
			int hash = typeof(T).GetHashCode();

			if (_signals.TryGetValue(hash, out List<IReceiver> receivers) && receivers.Contains(receiver))
			{
				receivers.Remove(receiver);

#if UNITY_EDITOR && ODIN_INSPECTOR
				_readableSignals.TryGetValue(typeof(T).Name, out var value);
				value.Remove(receiver);
#endif
			}
		}
	}
}

using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ToolBox.Signals
{
	[AssetSelector]
	public abstract class GenericSignal<T> : BaseSignal, ISignal<T>
	{
		[NonSerialized, ShowInInspector, ReadOnly] private int _receiversCount = 0;
		[SerializeField] private T _debugValue = default;

		[NonSerialized, ShowInInspector, ReadOnly] private List<IReceiver<T>> _receivers = new List<IReceiver<T>>();

		public void Dispatch(T value)
		{
			for (int i = _receiversCount - 1; i >= 0; i--)
				_receivers[i].OnSignalDispatched(value);
		}

#if UNITY_EDITOR
		[Button("Raise")]
		public void DebugDispatch()
		{
			for (int i = _receiversCount - 1; i >= 0; i--)
				_receivers[i].OnSignalDispatched(_debugValue);
		}
#endif

		public void Add(IReceiver<T> listener)
		{
			if (!_receivers.Contains(listener))
			{
				_receivers.Add(listener);
				_receiversCount++;
			}
		}

		public void Remove(IReceiver<T> listener)
		{
			if (_receivers.Contains(listener))
			{
				_receivers.Remove(listener);
				_receiversCount--;
			}
		}
	}
}

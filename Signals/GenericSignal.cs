using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ToolBox.Signals
{
	[AssetSelector]
	public abstract class GenericSignal<T> : BaseSignal, ISignal<T>
	{
		[NonSerialized, ShowInInspector, ReadOnly] private int receiversCount = 0;
		[SerializeField] private T debugValue = default;

		[NonSerialized, ShowInInspector, ReadOnly] private List<IReceiver<T>> receivers = new List<IReceiver<T>>();

		public void Dispatch(T value)
		{
			for (int i = receiversCount - 1; i >= 0; i--)
				receivers[i].OnSignalDispatched(value);
		}

#if UNITY_EDITOR
		[Button("Raise")]
		public void DebugDispatch()
		{
			for (int i = receiversCount - 1; i >= 0; i--)
				receivers[i].OnSignalDispatched(debugValue);
		}
#endif

		public void Add(IReceiver<T> listener)
		{
			if (!receivers.Contains(listener))
			{
				receivers.Add(listener);
				receiversCount++;
			}
		}

		public void Remove(IReceiver<T> listener)
		{
			if (receivers.Contains(listener))
			{
				receivers.Remove(listener);
				receiversCount--;
			}
		}
	}
}

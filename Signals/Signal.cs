using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ToolBox.Signals
{
	[CreateAssetMenu(menuName = "ToolBox/Signals/Signal"), AssetSelector]
	public class Signal : BaseSignal, ISignal
	{
		[NonSerialized, ShowInInspector, ReadOnly] private int receiversCount = 0;
		[NonSerialized, ShowInInspector, ReadOnly] private List<IReceiver> receivers = new List<IReceiver>();

		[Button("Raise")]
		public void Dispatch()
		{
			for (int i = receiversCount - 1; i >= 0; i--)
				receivers[i].OnSignalDispatched();
		}

		public void Add(IReceiver listener)
		{
			if (!receivers.Contains(listener))
			{
				receivers.Add(listener);
				receiversCount++;
			}
		}

		public void Remove(IReceiver listener)
		{
			if (receivers.Contains(listener))
			{
				receivers.Remove(listener);
				receiversCount--;
			}
		}
	}
}



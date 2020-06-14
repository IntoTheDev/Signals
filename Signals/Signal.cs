using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ToolBox.Signals
{
	[CreateAssetMenu(menuName = "ToolBox/Signals/Signal"), AssetSelector]
	public class Signal : BaseSignal, ISignal
	{
		[NonSerialized, ShowInInspector, ReadOnly] private int _receiversCount = 0;
		[NonSerialized, ShowInInspector, ReadOnly] private List<IReceiver> _receivers = new List<IReceiver>();

		[Button("Raise")]
		public void Dispatch()
		{
			for (int i = _receiversCount - 1; i >= 0; i--)
				_receivers[i].OnSignalDispatched();
		}

		public void Add(IReceiver listener)
		{
			if (!_receivers.Contains(listener))
			{
				_receivers.Add(listener);
				_receiversCount++;
			}
		}

		public void Remove(IReceiver listener)
		{
			if (_receivers.Contains(listener))
			{
				_receivers.Remove(listener);
				_receiversCount--;
			}
		}
	}
}



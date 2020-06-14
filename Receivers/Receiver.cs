using Sirenix.OdinInspector;
using ToolBox.Reactors;
using UnityEngine;

namespace ToolBox.Signals
{
	public class Receiver : BaseReceiver, IReceiver
	{
		[SerializeField, AssetSelector] private Signal _signal = null;
		[SerializeField, Required] private Reactor _reactor = default;

		private void Awake()
		{
			if (_signal == null)
			{
				Debug.LogWarning("Attach Signal to " + name);
				enabled = false;
			}

			_signal.Add(this);
		}

		private void OnEnable() =>
			_signal.Add(this);

		private void OnDisable() =>
			_signal.Remove(this);

		public void OnSignalDispatched() =>
			_reactor.SendReaction();
	}
}


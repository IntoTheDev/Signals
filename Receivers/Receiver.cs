using Sirenix.OdinInspector;
using ToolBox.Reactors;
using UnityEngine;

namespace ToolBox.Signals
{
	public class Receiver : BaseReceiver, IReceiver
	{
		[SerializeField, AssetSelector] private Signal signal = null;
		[SerializeField, Required] private Reactor reactor = default;

		private void Awake()
		{
			if (signal == null)
			{
				Debug.LogWarning("Attach Signal to " + name);
				enabled = false;
			}

			signal.Add(this);
		}

		private void OnEnable() =>
			signal.Add(this);

		private void OnDisable() =>
			signal.Remove(this);

		public void OnSignalDispatched() =>
			reactor.SendReaction();
	}
}


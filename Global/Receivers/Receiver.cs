using Sirenix.OdinInspector;
using ToolBox.Signals.Local;
using UnityEngine;

namespace ToolBox.Signals.Global
{
	public class Receiver : BaseReceiver, IReceiver
	{
		[SerializeField, AssetSelector] private GlobalSignal globalSignal = null;
		[SerializeField, Required] private LocalSignal localSignal = default;

		private void Awake()
		{
			if (globalSignal == null)
			{
				Debug.LogWarning("Attach Global Signal to " + name);
				enabled = false;
			}

			globalSignal.Add(this);
			localSignal.Initialize();
		}

		private void OnEnable() =>
			globalSignal.Add(this);

		private void OnDisable() =>
			globalSignal.Remove(this);

		public void OnSignalDispatched() =>
			localSignal.Dispatch();
	}
}


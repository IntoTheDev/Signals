using Sirenix.OdinInspector;
using ToolBox.Modules;
using UnityEngine;

namespace ToolBox.Observer
{
	public class Receiver : BaseReceiver, IReceiver
	{
		[SerializeField, AssetSelector] private GlobalSignal globalSignal = null;
		[SerializeField, Required] private ModulesContainer responseToGlobalSignal = default;

		private void Awake()
		{
			if (globalSignal == null)
			{
				Debug.LogWarning("Attach Global Signal to " + name);
				enabled = false;
			}

			globalSignal.Add(this);
		}

		private void OnEnable() =>
			globalSignal.Add(this);

		private void OnDisable() =>
			globalSignal.Remove(this);

		public void OnSignalDispatched() =>
			responseToGlobalSignal.Process();
	}
}


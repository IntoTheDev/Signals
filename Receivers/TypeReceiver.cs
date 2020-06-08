using Sirenix.OdinInspector;
using ToolBox.Modules;
using UnityEngine;

namespace ToolBox.Observer
{
	[DefaultExecutionOrder(-95)]
	public class TypeReceiver<TType, TEvent> : BaseReceiver, IReceiver<TType> where TEvent : TypeGlobalSignal<TType>
	{
		[SerializeField, AssetSelector] private TEvent globalSignal = null;
		[SerializeField, Required] private ModulesContainer responseToGlobalSignal = default;
		[SerializeField, Required] private ModulesContainer<TType> responseToGlobalSignalGeneric = default;

		public TEvent GameEvent => globalSignal;

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

		public void OnSignalDispatched(TType value)
		{
			responseToGlobalSignal.Process();
			responseToGlobalSignalGeneric.Process(value);
		}
	}
}

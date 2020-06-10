using Sirenix.OdinInspector;
using ToolBox.Signals.Local;
using UnityEngine;

namespace ToolBox.Signals.Global
{
	[DefaultExecutionOrder(-95)]
	public class TypeReceiver<TType, TEvent, TSignal> : BaseReceiver, IReceiver<TType> 
		where TEvent : TypeGlobalSignal<TType>
		where TSignal : LocalSignal<TType>
	{
		[SerializeField, AssetSelector] private TEvent globalSignal = null;
		[SerializeField, Required] private LocalSignal responseToGlobalSignal = default;
		[SerializeField, Required] private TSignal responseToGlobalSignalGeneric = default;

		private void Awake()
		{
			if (globalSignal == null)
			{
				Debug.LogWarning("Attach Global Signal to " + name);
				enabled = false;
			}

			responseToGlobalSignal.Initialize();
			responseToGlobalSignalGeneric.Initialize();

			globalSignal.Add(this);
		}

		private void OnEnable() =>
			globalSignal.Add(this);

		private void OnDisable() =>
			globalSignal.Remove(this);

		public void OnSignalDispatched(TType value)
		{
			responseToGlobalSignal.Dispatch();
			responseToGlobalSignalGeneric.Dispatch(value);
		}
	}
}

using Sirenix.OdinInspector;
using ToolBox.Reactors;
using UnityEngine;

namespace ToolBox.Signals
{
	[DefaultExecutionOrder(-95)]
	public class GenericReceiver<TType, TEvent, TIReactor, TReactor> : BaseReceiver, IReceiver<TType> 
		where TEvent : GenericSignal<TType>
		where TIReactor : IReactor<TType>
		where TReactor : Reactor<TType, TIReactor>
	{
		[SerializeField] private TEvent signal = null;
		[SerializeField, Required] private Reactor signalReactor = default;
		[SerializeField, Required] private TReactor genericSignalReactor = default;

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

		public void OnSignalDispatched(TType value)
		{
			signalReactor.SendReaction();
			genericSignalReactor.SendReaction(value);
		}
	}
}

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
		[SerializeField] private TEvent _signal = null;
		[SerializeField, Required] private Reactor _signalReactor = default;
		[SerializeField, Required] private TReactor _genericSignalReactor = default;

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

		public void OnSignalDispatched(TType value)
		{
			_signalReactor.SendReaction();
			_genericSignalReactor.SendReaction(value);
		}
	}
}

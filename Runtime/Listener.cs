using UnityEngine;
using UnityEngine.Events;

namespace ToolBox.Signals
{
	public abstract class Listener<S> : MonoBehaviour, IReceiver<S> where S : struct, ISignal
	{
		[SerializeField] private UnityEvent<S> _onDispatched = null;

		private void OnEnable() =>
			Hub<S>.Add(this);

		private void OnDisable() =>
			Hub<S>.Remove(this);

		public void Receive(in S value) =>
			_onDispatched?.Invoke(value);
	}
}

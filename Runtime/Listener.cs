using UnityEngine;
using UnityEngine.Events;

namespace ToolBox.Signals
{
	public abstract class Listener<S> : MonoBehaviour, IReceiver<S>
	{
		[SerializeField] private UnityEvent<S> _onDispatched = null;

		private void OnEnable() =>
			Signal<S>.AddReceiver(this);

		private void OnDisable() =>
			Signal<S>.RemoveReceiver(this);

		public void Receive(in S value) =>
			_onDispatched?.Invoke(value);
	}
}

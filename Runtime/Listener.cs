using UnityEngine;
using UnityEngine.Events;

namespace ToolBox.Signals
{
	public abstract class Listener<T> : MonoBehaviour, IReceiver<T>
	{
		[SerializeField] private UnityEvent<T> _onDispatched = null;

		private void OnEnable() =>
			Hub.Add(this);

		private void OnDisable() =>
			Hub.Remove(this);

		public void Receive(in T value) =>
			_onDispatched?.Invoke(value);
	}
}

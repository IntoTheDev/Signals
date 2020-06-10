using Sirenix.OdinInspector;
using ToolBox.Signals.Global;
using UnityEngine;

namespace ToolBox.Signals.Local
{
	public class GlobalSignalDispatcher : MonoBehaviour, ISignalReceiver
	{
		[SerializeField, Required, AssetSelector] private GlobalSignal globalSignal = null;

		public void Receive() =>
			globalSignal.Dispatch();
	}

	public abstract class GlobalSignalDispatcher<T, K> : MonoBehaviour, ISignalReceiver, ISignalReceiver<T> where K : TypeGlobalSignal<T>
	{
		[SerializeField, Required, AssetSelector] private K globalSignal = null;
		[SerializeField] private T value = default;

		public void Receive() =>
			globalSignal.Dispatch(value);

		public void Receive(T value) =>
			globalSignal.Dispatch(value);
	}
}

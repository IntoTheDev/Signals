using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ToolBox.Signals.Local
{
	[System.Serializable]
	public class LocalSignal
	{
		[SerializeField] private Transform root = null;
		[SerializeField, ValueDropdown("GetReceivers"), OnValueChanged("OnReceiversChanged")] private MonoBehaviour[] potentialReceivers = null;
		[ShowInInspector, ReadOnly] private List<ISignalReceiver> receivers = null;

		private int count = 0;
		private bool isInitialized = false;

		public void Initialize()
		{
			count = potentialReceivers.Length;
			receivers = new List<ISignalReceiver>(count);

			for (int i = 0; i < count; i++)
				receivers.Add(potentialReceivers[i] as ISignalReceiver);

			isInitialized = true;
		}

		[Button]
		public void Dispatch()
		{
#if UNITY_EDITOR
			if (!isInitialized)
				Debug.Log($"Local Signal on {root.name} is not initialized");
#endif
			for (int i = 0; i < count; i++)
				receivers[i].Receive();
		}

		public void Add(ISignalReceiver signalReceiver)
		{
			if (!receivers.Contains(signalReceiver))
			{
				receivers.Add(signalReceiver);
				count++;
			}
		}

		public void Remove(ISignalReceiver signalReceiver)
		{
			if (receivers.Contains(signalReceiver))
			{
				receivers.Remove(signalReceiver);
				count--;
			}
		}

#if UNITY_EDITOR
		private IEnumerable<ISignalReceiver> GetReceivers()
		{
			if (root == null)
				return null;

			ISignalReceiver[] receivers = root.GetComponentsInChildren<ISignalReceiver>();	

			for (int i = 0; i < receivers.Length; i++)
			{
				ISignalReceiver receiver = receivers[i];

				if (ArrayUtility.Contains(potentialReceivers, receiver as MonoBehaviour))
					ArrayUtility.Remove(ref receivers, receiver);
			}

			return receivers;
		}

		private void OnReceiversChanged()
		{
			for (int i = 0; i < potentialReceivers.Length; i++)
			{
				bool isReceiver = potentialReceivers[i] is ISignalReceiver;

				if (!isReceiver)
					ArrayUtility.Remove(ref potentialReceivers, potentialReceivers[i]);
			}
		}
#endif
	}

	[System.Serializable]
	public class LocalSignal<T>
	{
		[SerializeField] private Transform root = null;
		[SerializeField, ValueDropdown("GetReceivers"), OnValueChanged("OnReceiversChanged")] private MonoBehaviour[] potentialReceivers = null;
		[ShowInInspector, ReadOnly] private List<ISignalReceiver<T>> receivers = null;

		private int count = 0;
		private bool isInitialized = false;

		public void Initialize()
		{
			count = potentialReceivers.Length;
			receivers = new List<ISignalReceiver<T>>(count);

			for (int i = 0; i < count; i++)
				receivers.Add(potentialReceivers[i] as ISignalReceiver<T>);

			isInitialized = true;
		}

		[Button]
		public void Dispatch(T value)
		{
#if UNITY_EDITOR
			if (!isInitialized)
				Debug.Log($"Local Signal on {root.name} is not initialized");
#endif

			for (int i = 0; i < count; i++)
				receivers[i].Receive(value);
		}

		public void Add(ISignalReceiver<T> signalReceiver)
		{
			if (!receivers.Contains(signalReceiver))
			{
				receivers.Add(signalReceiver);
				count++;
			}
		}

		public void Remove(ISignalReceiver<T> signalReceiver)
		{
			if (receivers.Contains(signalReceiver))
			{
				receivers.Remove(signalReceiver);
				count--;
			}
		}

#if UNITY_EDITOR
		private IEnumerable<ISignalReceiver<T>> GetReceivers()
		{
			if (root == null)
				return null;

			ISignalReceiver<T>[] receivers = root.GetComponentsInChildren<ISignalReceiver<T>>();

			for (int i = 0; i < receivers.Length; i++)
			{
				ISignalReceiver<T> receiver = receivers[i];

				if (ArrayUtility.Contains(potentialReceivers, receiver as MonoBehaviour))
					ArrayUtility.Remove(ref receivers, receiver);
			}

			return receivers;
		}

		private void OnReceiversChanged()
		{
			for (int i = 0; i < potentialReceivers.Length; i++)
			{
				bool isReceiver = potentialReceivers[i] is ISignalReceiver<T>;

				if (!isReceiver)
					ArrayUtility.Remove(ref potentialReceivers, potentialReceivers[i]);
			}
		}
#endif
	}
}

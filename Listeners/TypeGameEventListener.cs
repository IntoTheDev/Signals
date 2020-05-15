using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;
using UnityEngine.Events;

namespace ToolBox.Observer
{
	[DefaultExecutionOrder(-95)]
	public class TypeGameEventListener<TType, TEvent, TResponse> : BaseGameEventListener, IGameEventListener<TType>
		where TEvent : TypeGameEvent<TType>
		where TResponse : UnityEvent<TType>
	{
		public TEvent GameEvent => gameEvent;

		[SerializeField, AssetSelector] private TEvent gameEvent = null;
		[OdinSerialize, Required] private IReactor[] responseToGameEvent = null;
		[OdinSerialize, Required] private IReactor<TType>[] responseToGameEventGeneric = null;

		private void Awake()
		{
			if (gameEvent == null)
			{
				Debug.LogWarning("Attach Game Event to " + name);
				enabled = false;
			}

			gameEvent.AddListener(this);
		}

		private void OnEnable() =>
			gameEvent.AddListener(this);

		private void OnDisable() =>
			gameEvent.RemoveListener(this);

		public void OnEventRaised(TType value)
		{
			responseToGameEvent.Dispatch();
			responseToGameEventGeneric.Dispatch(value);
		}

#if UNITY_EDITOR
		public override BaseGameEvent GetEvent() =>
			gameEvent as BaseGameEvent;
#endif
	}
}

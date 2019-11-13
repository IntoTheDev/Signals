using UnityEngine;
using UnityEngine.Events;

namespace ToolBox.Observer
{
	public class TypeGameEventListener<TType, TEvent, TResponse> : BaseGameEventListener, IGameEventListener<TType>
		where TEvent : TypeGameEvent<TType>
		where TResponse : UnityEvent<TType>
	{
		public TEvent GameEvent => gameEvent;

		[SerializeField] private TEvent gameEvent = null;

		public TResponse responseToGameEvent = null;

		private void Awake()
		{
			if (gameEvent == null)
			{
				Debug.LogWarning("Attach Game Event to " + name);
				enabled = false;
			}
		}

		private void OnEnable() => gameEvent.AddListener(this);

		private void OnDisable() => gameEvent.RemoveListener(this);

		public void OnEventRaised(TType value) => responseToGameEvent.Invoke(value);

#if UNITY_EDITOR
		public override BaseGameEvent GetEvent() => gameEvent as BaseGameEvent;
#endif
	}
}

using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;
using UnityEngine.Events;

namespace ToolBox.Observer
{
	[DefaultExecutionOrder(-95)]
	public class TypeGameEventListener<TType, TEvent> : BaseGameEventListener, IGameEventListener<TType> where TEvent : TypeGameEvent<TType>
	{
		[SerializeField, AssetSelector] private TEvent gameEvent = null;
		[OdinSerialize, Required] private ModulesContainer responseToGameEvent = null;
		[OdinSerialize, Required] private ModulesContainer<TType> responseToGameEventGeneric = null;

		public TEvent GameEvent => gameEvent;

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
			responseToGameEvent.Process();
			responseToGameEventGeneric.Process(value);
		}

#if UNITY_EDITOR
		public override BaseGameEvent GetEvent() =>
			gameEvent as BaseGameEvent;
#endif
	}
}

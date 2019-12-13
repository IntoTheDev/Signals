using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace ToolBox.Observer
{
	public class GameEventListener : BaseGameEventListener, IGameEventListener
	{
		public GameEvent GameEvent => gameEvent;

		[SerializeField, AssetSelector] private GameEvent gameEvent = null;
		[SerializeField] private UnityEvent responseToGameEvent = null;

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

		public void OnEventRaised() => responseToGameEvent.Invoke();

#if UNITY_EDITOR
		public override BaseGameEvent GetEvent() => gameEvent as BaseGameEvent;
#endif
	}
}


using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace ToolBox.Observer
{
	public class GameEventListener : BaseGameEventListener, IGameEventListener
	{
		[SerializeField, AssetSelector] private GameEvent gameEvent = null;
		[OdinSerialize, Required] private ModulesContainer responseToGameEvent = null;

		public GameEvent GameEvent => gameEvent;

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

		public void OnEventRaised() =>
			responseToGameEvent.Process();

#if UNITY_EDITOR
		public override BaseGameEvent GetEvent() =>
			gameEvent as BaseGameEvent;
#endif
	}
}


using Sirenix.OdinInspector;
using UnityEngine;

namespace ToolBox.Observer
{
	public class GameEventRaising : MonoBehaviour
	{
		public GameEvent GameEvent => gameEvent;

		[SerializeField, AssetSelector] private GameEvent gameEvent = null;

		private void Awake()
		{
			if (gameEvent == null)
				enabled = false;
		}

		public void RaiseGameEvent() => gameEvent.Raise();
	}
}


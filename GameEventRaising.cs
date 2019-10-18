using UnityEngine;

namespace ToolBox.Observer
{
	public class GameEventRaising : MonoBehaviour
	{
		[SerializeField] private GameEvent gameEvent = null;

		private void Awake()
		{
			if (gameEvent == null)
				enabled = false;
		}

		public void RaiseGameEvent() => gameEvent.Raise();
	}
}


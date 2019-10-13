using UnityEngine;
using System.Collections.Generic;
using ToolBox.Attributes;

namespace ToolBox.Events
{
	[CreateAssetMenu(menuName = "ToolBox/Game Event")]
	public class GameEvent : ScriptableObject
	{
		[SerializeField, ReadOnly] private int gameEventListenersCount = 0;

		private List<GameEventListener> listeners = new List<GameEventListener>();

		[Button("Raise")]
		public void Raise()
		{
			for (int i = gameEventListenersCount - 1; i >= 0; i--)
				listeners[i].Response();
		}

		public void AddListener(GameEventListener listener)
		{
			if (!listeners.Contains(listener))
			{
				listeners.Add(listener);
				gameEventListenersCount++;
			}
		}

		public void RemoveListener(GameEventListener listener)
		{
			if (listeners.Contains(listener))
			{
				listeners.Remove(listener);
				gameEventListenersCount--;
			}
		}
	}
}



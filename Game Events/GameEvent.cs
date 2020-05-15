using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace ToolBox.Observer
{
	[CreateAssetMenu(menuName = "ToolBox/Game Events/Game Event")]
	public class GameEvent : BaseGameEvent, IGameEvent
	{
		[NonSerialized, ShowInInspector, ReadOnly] private int gameEventListenersCount = 0;
		[NonSerialized, ShowInInspector, ReadOnly] private List<IGameEventListener> listeners = new List<IGameEventListener>();

		[Button("Raise")]
		public void Raise()
		{
			for (int i = gameEventListenersCount - 1; i >= 0; i--)
				listeners[i].OnEventRaised();
		}

		public void AddListener(IGameEventListener listener)
		{
			if (!listeners.Contains(listener))
			{
				listeners.Add(listener);
				gameEventListenersCount++;
			}
		}

		public void RemoveListener(IGameEventListener listener)
		{
			if (listeners.Contains(listener))
			{
				listeners.Remove(listener);
				gameEventListenersCount--;
			}
		}

		[Button("Clear")]
		private void Clear()
		{
			listeners.Clear();
			gameEventListenersCount = 0;
		}
	}
}



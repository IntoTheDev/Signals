﻿using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace ToolBox.Observer
{
	public abstract class TypeGameEvent<T> : BaseGameEvent, IGameEvent<T>
	{
		[SerializeField, ReadOnly] private int gameEventListenersCount = 0;
#if UNITY_EDITOR
		[SerializeField] private T debugValue = default;
#endif

		private List<IGameEventListener<T>> listeners = new List<IGameEventListener<T>>();


		public void Raise(T value)
		{
			for (int i = gameEventListenersCount - 1; i >= 0; i--)
				listeners[i].OnEventRaised(value);
		}

#if UNITY_EDITOR
		[Button("Raise")]
		public void DebugRaise()
		{
			for (int i = gameEventListenersCount - 1; i >= 0; i--)
				listeners[i].OnEventRaised(debugValue);
		}
#endif

		public void AddListener(IGameEventListener<T> listener)
		{
			if (!listeners.Contains(listener))
			{
				listeners.Add(listener);
				gameEventListenersCount++;
			}
		}

		public void RemoveListener(IGameEventListener<T> listener)
		{
			if (listeners.Contains(listener))
			{
				listeners.Remove(listener);
				gameEventListenersCount--;
			}
		}
	}
}
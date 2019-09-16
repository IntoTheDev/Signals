using UnityEngine;
using System.Collections.Generic;
using ToolBox.Attributes;

[CreateAssetMenu(menuName = "ToolBox/Game Event")]
public class GameEvent : ScriptableObject
{
	[SerializeField, ReadOnly] private int gameEventListenersCount = 0;

	private List<GameEventListener> listeners = new List<GameEventListener>();

	[Button("Raise")]
	public void Raise()
	{
		for (int i = 0; i < gameEventListenersCount; i++)
			listeners[i].Response();
	}

	public void AddListener(GameEventListener listener)
	{
		listeners.Add(listener);
		gameEventListenersCount++;
	}

	public void RemoveListener(GameEventListener listener)
	{
		listeners.Remove(listener);
		gameEventListenersCount--;
	}
}


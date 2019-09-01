using UnityEngine;
using System.Collections.Generic;
using NaughtyAttributes;

[CreateAssetMenu(menuName = "ToolBox/Game Event")]
public class GameEvent : ScriptableObject
{
	private List<GameEventListener> listeners = new List<GameEventListener>();
	
	[SerializeField, ReadOnly]
	private int gameEventListenersCount = 0;

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

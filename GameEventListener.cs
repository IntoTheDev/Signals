using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
	[SerializeField]
	private GameEvent gameEvent;
	[SerializeField]
	private UnityEvent responseToGameEvent;

	private bool isGameEventAttached = true;

	private void Awake()
	{
		if (gameEvent == null)
		{
			Debug.LogWarning("Attach Game Event to " + name);
			isGameEventAttached = false;
			enabled = false;
		}
		else
		{
			isGameEventAttached = true;
		}
	}

	private void OnEnable()
	{
		if (isGameEventAttached)
			gameEvent.AddListener(this);
	}

	private void OnDisable()
	{
		if (isGameEventAttached)
			gameEvent.RemoveListener(this);
	}

	public void Response()
	{
		responseToGameEvent.Invoke();
	}
}

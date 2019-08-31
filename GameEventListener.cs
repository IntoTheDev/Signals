using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
	public GameEvent gameEvent;
	[SerializeField]
	private UnityEvent responseToGameEvent;

	private void OnEnable()
	{
		gameEvent.AddListener(this);
	}

	private void OnDisable()
	{
		gameEvent.RemoveListener(this);
	}

	public void Response()
	{
		responseToGameEvent.Invoke();
	}
}

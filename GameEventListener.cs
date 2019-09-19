using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
	[SerializeField] private GameEvent gameEvent = null;
	[SerializeField] private UnityEvent responseToGameEvent = null;

	private void Awake()
	{
		if (gameEvent == null)
		{
			Debug.LogWarning("Attach Game Event to " + name);
			enabled = false;
		}
	}

	private void OnEnable() => gameEvent.AddListener(this);

	private void OnDisable() => gameEvent.RemoveListener(this);

	public void Response() => responseToGameEvent.Invoke();
}

# Signals
Lightweight type-safe messaging system.

## Example
```csharp
	public class SignalPlayerCreated { }

	public class SignalPlayerDestroyed 
	{
		public float LifeTime { get; } = 0f;

		public SignalPlayerDestroyed(float lifeTime) =>
			LifeTime = lifeTime;
	}

	public class Player : MonoBehaviour
	{
		private void Awake() =>
			Hub.Dispatch(new SignalPlayerCreated());

		private void OnDestroy() =>
			Hub.Dispatch(new SignalPlayerDestroyed(Time.realtimeSinceStartup));
	}

	public class Enemy : MonoBehaviour, IReceiver<SignalPlayerCreated>, IReceiver<SignalPlayerDestroyed>
	{
		private void OnEnable()
		{
			Hub.Add<SignalPlayerCreated>(this);
			Hub.Add<SignalPlayerDestroyed>(this);
		}

		private void OnDisable()
		{
			Hub.Remove<SignalPlayerCreated>(this);
			Hub.Remove<SignalPlayerDestroyed>(this);
		}

		public void Receive(SignalPlayerCreated value)
		{
			// Do something 
		}

		public void Receive(SignalPlayerDestroyed value)
		{
			// Do something 
		}
	}

	public class ResultUI : MonoBehaviour, IReceiver<SignalPlayerDestroyed>
	{
		private void OnEnable() =>
			Hub.Add(this);

		private void OnDisable() =>
			Hub.Remove(this);

		public void Receive(SignalPlayerDestroyed value) =>
			Debug.Log($"Player's life time: {value.LifeTime}");
	}
```

# Signals

### TODO
- [ ] Abstract signals

## Features
- Type-safe
- Very fast in terms of performance
- Allows you to get last dispatched signal

## How to Install
### Git Installation (Best way to get latest version)

If you have Git on your computer, you can open Package Manager indside Unity, select "Add package from Git url...", and paste link ```https://github.com/IntoTheDev/Signals.git```

or

Open the manifest.json file of your Unity project.
Add ```"com.intothedev.signals": "https://github.com/IntoTheDev/Signals.git"```

### Manual Installation (Version can be outdated)
Download latest package from the Release section.
Import Signals.unitypackage to your Unity Project

## Usage

### How to create a signal

Create a plain C# class or struct. I prefer to use readonly structs.

```csharp
public readonly struct PlayerCreated
{
	public readonly string Name;
	public readonly GameObject StartWeapon;

	public PlayerCreated(string name, GameObject startWeapon)
	{
		Name = name;
		StartWeapon = startWeapon;
	}
}
```

### How to send a signal

You need to call `Signal<S>.Dispatch(new S())`. Instead of `S` you need to pass in type of your signal.

```csharp
public class Player : MonoBehaviour
{
	[SerializeField] private string _name = "";
	[SerializeField] private GameObject _weapon = null;

	private void Start()
	{
		Signal<PlayerCreated>.Dispatch(new PlayerCreated(_name, _weapon));
	}
}
```

### How to receive a signal

Your class/struct must implement `IReceiver<S>` interface. Instead of `S` you need to pass in type of your signal.

```csharp
public class PlayerUI : MonoBehaviour, IReceiver<PlayerCreated>
{
	[SerializeField] private TMP_Text _playerName = null;
	[SerializeField] private Image _weaponIcon = null;

	private void Awake()
    	{
		// You can get last dispatched signal like this
		// This is useful if for example UI was created later then the player
		if (Signal<PlayerCreated>.TryGetLast(out var last))
        		Receive(last);
    	}

	private void OnEnable()
	{
		// Subscribing to signal
		Signal<PlayerCreated>.AddReceiver(this);
	}

	private void OnDisable()
	{
		// Unsubscribing from signal
		Signal<PlayerCreated>.RemoveReceiver(this);
	}

	// Receiving the signal
	public void Receive(in PlayerCreated value)
	{
		_playerName.text = value.Name;
		_weaponIcon.sprite = value.StartWeapon.GetComponent<Weapon>().Icon;
	}
}
```

### UnityEvent

Create a class that inherits from `Listener<SignalType>` and attach it to any game object you want. Now you can invoke UnityEvent to corresponding Signal.

```csharp
public class PlayerCreatedListener : Listener<PlayerCreated> { }
```

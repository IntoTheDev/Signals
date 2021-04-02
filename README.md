# Signals
Lightweight type-safe messaging system.

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

Just create a plain C# class.

```csharp
public class SignalPlayerCreated
{
	public string Name { get; }
	public GameObject StartWeapon { get; }

	public SignalPlayerCreated(string name, GameObject startWeapon)
	{
		Name = name;
		StartWeapon = startWeapon;
	}
}
```

### How to send a signal

You need to call `Hub.Dispatch` and pass in instance of signal.

```csharp
public class Player : MonoBehaviour
{
	[SerializeField] private string _name = "";
	[SerializeField] private GameObject _weapon = null;

	private void Start()
	{
		Hub.Dispatch(new SignalPlayerCreated(_name, _weapon));
	}
}
```

### How to receive a signal

Your class/struct should implement `IReceiver<T>` interface. Pass in Signal instead of T.

```csharp
public class PlayerUI : MonoBehaviour, IReceiver<SignalPlayerCreated>
{
	[SerializeField] private TMP_Text _playerName = null;
	[SerializeField] private Image _weaponIcon = null;

	private void OnEnable()
	{
		// Subscribing to signal
		Hub.Add<SignalPlayerCreated>(this);
	}

	private void OnDisable()
	{
		// Unsubscribing from signal
		Hub.Remove<SignalPlayerCreated>(this);
	}

	// Receiving the signal
	public void Receive(in SignalPlayerCreated value)
	{
		_playerName.text = value.Name;
		_weaponIcon.sprite = value.StartWeapon.GetComponent<Weapon>().Icon;
	}
}
```

using UnityEngine;

namespace ToolBox.Signals
{
	[CreateAssetMenu(menuName = "ToolBox/Signals/GameObject Signal")]
	public sealed class GameObjectSignal : GenericSignal<GameObject> { }
}

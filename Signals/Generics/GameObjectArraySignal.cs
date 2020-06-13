using UnityEngine;

namespace ToolBox.Signals
{
	[CreateAssetMenu(menuName = "ToolBox/Signals/GameObjectArray Signal")]
	public sealed class GameObjectArraySignal : GenericSignal<GameObject[]> { }
}

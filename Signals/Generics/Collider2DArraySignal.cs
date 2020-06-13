using UnityEngine;

namespace ToolBox.Signals
{
	[CreateAssetMenu(menuName = "ToolBox/Signals/Collider2DArray Signal")]
	public sealed class Collider2DArraySignal : GenericSignal<Collider2D[]> { }
}

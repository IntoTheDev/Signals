using UnityEngine;

namespace ToolBox.Signals
{
	[CreateAssetMenu(menuName = "ToolBox/Signals/Transform Signal")]
	public sealed class TransformSignal : GenericSignal<Transform> { }
}

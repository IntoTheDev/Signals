using UnityEngine;

namespace ToolBox.Signals
{
	[CreateAssetMenu(menuName = "ToolBox/Signals/TransformArray Signal")]
	public sealed class TransformArraySignal : GenericSignal<Transform[]> { }
}

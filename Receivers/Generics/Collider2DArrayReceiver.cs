using ToolBox.Reactors;
using UnityEngine;

namespace ToolBox.Signals
{
	public sealed class Collider2DArrayReceiver : GenericReceiver<Collider2D[], Collider2DArraySignal, ICollider2DArrayReactor, Collider2DArrayReactor> { }
}

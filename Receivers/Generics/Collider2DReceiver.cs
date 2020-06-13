using ToolBox.Reactors;
using UnityEngine;

namespace ToolBox.Signals
{
	public sealed class Collider2DReceiver : GenericReceiver<Collider2D, Collider2DSignal, ICollider2DReactor, Collider2DReactor> { }
}

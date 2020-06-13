using ToolBox.Reactors;
using UnityEngine;

namespace ToolBox.Signals
{
	public sealed class TransformReceiver : GenericReceiver<Transform, TransformSignal, ITransformReactor, TransformReactor> { }
}

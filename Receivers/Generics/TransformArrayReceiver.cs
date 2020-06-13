using ToolBox.Reactors;
using UnityEngine;

namespace ToolBox.Signals
{
	public sealed class TransformArrayReceiver : GenericReceiver<Transform[], TransformArraySignal, ITransformArrayReactor, TransformArrayReactor> { }
}

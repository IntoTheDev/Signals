using ToolBox.Signals.Local;
using UnityEngine;

namespace ToolBox.Signals.Global
{
	public class TransformReceiver : TypeReceiver<Transform, TransformGlobalSignal, TransformLocalSignal> { }
}

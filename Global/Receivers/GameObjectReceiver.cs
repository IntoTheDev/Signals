using ToolBox.Signals.Local;
using UnityEngine;

namespace ToolBox.Signals.Global
{
	public class GameObjectReceiver : TypeReceiver<GameObject, GameObjectGlobalSignal, GameObjectLocalSignal> { }
}

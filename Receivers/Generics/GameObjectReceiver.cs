using ToolBox.Reactors;
using UnityEngine;

namespace ToolBox.Signals
{
	public sealed class GameObjectReceiver : GenericReceiver<GameObject, GameObjectSignal, IGameObjectReactor, GameObjectReactor> { }
}

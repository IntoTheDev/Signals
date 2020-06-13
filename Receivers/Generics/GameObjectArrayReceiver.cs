using ToolBox.Reactors;
using UnityEngine;

namespace ToolBox.Signals
{
	public sealed class GameObjectArrayReceiver : GenericReceiver<GameObject[], GameObjectArraySignal, IGameObjectArrayReactor, GameObjectArrayReactor> { }
}

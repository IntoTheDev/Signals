using System;
using UnityEngine.Events;

namespace ToolBox.Observer
{
	[Serializable]
	public sealed class EntityUnityEvent : UnityEvent<Entity> { }
}


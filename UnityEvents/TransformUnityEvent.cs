using System;
using UnityEngine;
using UnityEngine.Events;

namespace ToolBox.Observer
{
	[Serializable]
	public sealed class TransformUnityEvent : UnityEvent<Transform> { }
}


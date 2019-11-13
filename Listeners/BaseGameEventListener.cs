using UnityEngine;

namespace ToolBox.Observer
{
	public abstract class BaseGameEventListener : MonoBehaviour
	{
#if UNITY_EDITOR
		public abstract BaseGameEvent GetEvent();
#endif 
	}
}

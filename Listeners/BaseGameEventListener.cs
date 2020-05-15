using Sirenix.OdinInspector;

namespace ToolBox.Observer
{
	public abstract class BaseGameEventListener : SerializedMonoBehaviour
	{
#if UNITY_EDITOR
		public abstract BaseGameEvent GetEvent();
#endif 
	}
}

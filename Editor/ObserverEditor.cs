using System.Collections.Generic;
using ToolBox.Observer;
using UnityEditor;
using UnityEngine;

public class ObserverEditor : EditorWindow
{
	private GameEvent gameEvent = null;

	private List<GameEventListener> scene = null;
	private List<GameEventListener> assets = null;

	private int sceneCount = 0;
	private int assetsCount = 0;

	private Vector2 scrollPosition = Vector2.zero;

	[MenuItem("Window/ToolBox/Observer")]
	public static void ShowWindow()
	{
		GetWindow<ObserverEditor>("Observer Window");
	}

	private void OnGUI()
	{
		scrollPosition = GUILayout.BeginScrollView(scrollPosition, false, true);

		MainDraw();
		FindListeners();

		GUILayout.Space(50f);

		GUILayout.Label("Game Event Listeners in Assets", EditorStyles.boldLabel);

		EditorGUI.BeginDisabledGroup(true);
		DrawListeners(assetsCount, assets);
		EditorGUI.EndDisabledGroup();

		GUILayout.Space(50f);

		GUILayout.Label("Game Event Listeners in Scene", EditorStyles.boldLabel);

		EditorGUI.BeginDisabledGroup(true);
		DrawListeners(sceneCount, scene);
		EditorGUI.EndDisabledGroup();

		GUILayout.EndScrollView();
	}

	private void MainDraw()
	{
		GUILayout.Label("Game Event", EditorStyles.boldLabel);
		gameEvent = EditorGUILayout.ObjectField("", gameEvent, typeof(GameEvent), true) as GameEvent;
	}

	private void FindListeners()
	{
		if (gameEvent == null)
		{
			if (scene != null)
				scene.Clear();

			if (assets != null)
				assets.Clear();

			sceneCount = 0;
			assetsCount = 0;

			return;
		}

		GameEventListener[] listeners = Resources.FindObjectsOfTypeAll<GameEventListener>();

		scene = new List<GameEventListener>();
		assets = new List<GameEventListener>();

		int listenersCount = listeners.Length;

		for (int i = 0; i < listenersCount; i++)
		{
			GameEventListener listener = listeners[i];

			if (listener.GameEvent == gameEvent)
			{
				if (listener.gameObject.scene.IsValid())
					scene.Add(listener);
				else
					assets.Add(listener);
			}
		}

		sceneCount = scene.Count;
		assetsCount = assets.Count;
	}

	private void DrawListeners(int count, List<GameEventListener> collection)
	{
		for (int i = 0; i < count; i++)
			collection[i] = EditorGUILayout.ObjectField("", collection[i], typeof(GameEventListener), true) as GameEventListener;
	}
}

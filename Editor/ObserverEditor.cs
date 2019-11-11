using System.Collections.Generic;
using ToolBox.Observer;
using UnityEditor;
using UnityEngine;

public class ObserverEditor : EditorWindow
{
	private GameEvent gameEvent = null;

	private List<GameEventListener> scene = null;
	private List<GameEventListener> assets = null;
	private List<GameEventRaising> raiseScene = null;
	private List<GameEventRaising> raiseAssets = null;

	private int sceneCount = 0;
	private int assetsCount = 0;
	private int raiseSceneCount = 0;
	private int raiseAssetsCount = 0;

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

		GUILayout.Label("Game Event Raisers in Assets", EditorStyles.boldLabel);

		EditorGUI.BeginDisabledGroup(true);
		DrawRaisers(raiseAssetsCount, raiseAssets);
		EditorGUI.EndDisabledGroup();

		GUILayout.Space(50f);

		GUILayout.Label("Game Event Raisers in Scene", EditorStyles.boldLabel);

		EditorGUI.BeginDisabledGroup(true);
		DrawRaisers(raiseSceneCount, raiseScene);
		EditorGUI.EndDisabledGroup();

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

			if (raiseScene != null)
				raiseScene.Clear();

			sceneCount = 0;
			assetsCount = 0;
			raiseSceneCount = 0;
			raiseAssetsCount = 0;

			return;
		}

		GameEventListener[] listeners = Resources.FindObjectsOfTypeAll<GameEventListener>();
		GameEventRaising[] raisers = Resources.FindObjectsOfTypeAll<GameEventRaising>();

		scene = new List<GameEventListener>();
		assets = new List<GameEventListener>();
		raiseScene = new List<GameEventRaising>();
		raiseAssets = new List<GameEventRaising>();

		int listenersCount = listeners.Length;
		int raisersCount = raisers.Length;

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

		for (int i = 0; i < raisersCount; i++)
		{
			GameEventRaising raiser = raisers[i];

			if (raiser.GameEvent == gameEvent)
			{
				if (raiser.gameObject.scene.IsValid())
					raiseScene.Add(raiser);
				else
					raiseAssets.Add(raiser);
			}
		}

		sceneCount = scene.Count;
		assetsCount = assets.Count;
		raiseSceneCount = raiseScene.Count;
		raiseAssetsCount = raiseAssets.Count;
	}

	private void DrawListeners(int count, List<GameEventListener> collection)
	{
		for (int i = 0; i < count; i++)
			collection[i] = EditorGUILayout.ObjectField("", collection[i], typeof(GameEventListener), true) as GameEventListener;
	}

	private void DrawRaisers(int count, List<GameEventRaising> collection)
	{
		for (int i = 0; i < count; i++)
			collection[i] = EditorGUILayout.ObjectField("", collection[i], typeof(GameEventRaising), true) as GameEventRaising;
	}
}

using System.Collections.Generic;
using ToolBox.Observer;
using UnityEditor;
using UnityEngine;

public class ObserverEditor : EditorWindow
{
	private BaseGameEvent gameEvent = null;

	private List<BaseGameEventListener> scene = null;
	private List<BaseGameEventListener> assets = null;
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
		DrawRaisers(raiseAssetsCount, raiseAssets);

		GUILayout.Space(50f);

		GUILayout.Label("Game Event Raisers in Scene", EditorStyles.boldLabel);
		DrawRaisers(raiseSceneCount, raiseScene);

		GUILayout.Space(50f);

		GUILayout.Label("Game Event Listeners in Assets", EditorStyles.boldLabel);
		DrawListeners(assetsCount, assets);

		GUILayout.Space(50f);

		GUILayout.Label("Game Event Listeners in Scene", EditorStyles.boldLabel);
		DrawListeners(sceneCount, scene);

		GUILayout.EndScrollView();
	}

	private void MainDraw()
	{
		GUILayout.Label("Game Event", EditorStyles.boldLabel);
		gameEvent = EditorGUILayout.ObjectField("", gameEvent, typeof(BaseGameEvent), true) as BaseGameEvent;
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

		scene = new List<BaseGameEventListener>();
		assets = new List<BaseGameEventListener>();
		raiseScene = new List<GameEventRaising>();
		raiseAssets = new List<GameEventRaising>();

		BaseGameEventListener[] listeners = Resources.FindObjectsOfTypeAll<BaseGameEventListener>();
		GameEventRaising[] raisers = Resources.FindObjectsOfTypeAll<GameEventRaising>();

		int listenersCount = listeners.Length;
		int raisersCount = raisers.Length;

		for (int i = 0; i < listenersCount; i++)
		{
			BaseGameEventListener listener = listeners[i];
			BaseGameEvent listenerEvent = listener.GetEvent();	

			if (listenerEvent == gameEvent)
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

	private void DrawListeners(int count, List<BaseGameEventListener> collection)
	{
		EditorGUI.BeginDisabledGroup(true);

		for (int i = 0; i < count; i++)
			collection[i] = EditorGUILayout.ObjectField("", collection[i], typeof(BaseGameEventListener), true) as BaseGameEventListener;

		EditorGUI.EndDisabledGroup();
	}

	private void DrawRaisers(int count, List<GameEventRaising> collection)
	{
		for (int i = 0; i < count; i++)
			collection[i] = EditorGUILayout.ObjectField("", collection[i], typeof(GameEventRaising), true) as GameEventRaising;
	}
}

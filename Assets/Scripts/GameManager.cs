using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public List<string> Shapes = new List<string>();
	public static GameManager Instance;
	void Start()
	{
		Instance = this;
	}

	public void LoadScene(string scene)
	{
		SceneManager.LoadScene(scene);
	}
	public void SetStartShape()
	{
		PlayerPrefs.SetString("shape", Shapes[0]);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
#else
			Application.Quit();

#endif
		}
	}
}

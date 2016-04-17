using UnityEngine;
using UnityEngine.SceneManagement;

public class KillVolume : MonoBehaviour
{
	public void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			TriggerSceneChange();
		}
	}
	[ContextMenu("Change Scenes")]
	private void TriggerSceneChange()
	{
		var shapes = GameManager.Instance.Shapes;
		try
		{
			PlayerPrefs.SetString("shape", shapes[shapes.IndexOf(PlayerPrefs.GetString("shape", shapes[0])) + 1]);
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
		catch
		{
			SceneManager.LoadScene("GameOver");
		}
	}
}

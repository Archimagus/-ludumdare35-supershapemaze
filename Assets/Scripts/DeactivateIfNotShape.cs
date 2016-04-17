using UnityEngine;

public class DeactivateIfNotShape : MonoBehaviour 
{
	[SerializeField]
	string _shape;
	void Start()
	{
		if (_shape != PlayerPrefs.GetString("shape", GameManager.Instance.Shapes[0]))
		{
			gameObject.SetActive(false);
		}
	}
}

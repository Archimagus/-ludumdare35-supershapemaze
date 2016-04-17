using UnityEngine;

public class GamePieceTracker : MonoBehaviour
{
	[SerializeField]
	Transform _targetTransform;
	void Start()
	{

	}
	void Update()
	{
		if (_targetTransform == null)
		{
			Destroy(gameObject);
			return;
		}
		transform.localPosition = _targetTransform.localPosition;
		transform.localRotation = _targetTransform.localRotation;// Quaternion.Euler(transform.localRotation.eulerAngles.x, _targetTransform.localRotation.eulerAngles.y, transform.localRotation.eulerAngles.z);
	}
}

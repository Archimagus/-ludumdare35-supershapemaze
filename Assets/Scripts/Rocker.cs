using UnityEngine;

public class Rocker : MonoBehaviour
{
	[SerializeField]
	Rigidbody[] _remotePieces;
	[SerializeField]
	float _tiltCap = 25;
	[SerializeField]
	float _tiltSensitivity = 0.25f;
	Vector3 _dragStartPos;
	void Start()
	{
	}
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			_dragStartPos = Input.mousePosition;
		}
		if (Input.GetMouseButton(0))
		{
			var tilt = Input.mousePosition - _dragStartPos;
			tilt *= _tiltSensitivity;
			tilt.x = Mathf.Clamp(tilt.x, -_tiltCap, _tiltCap);
			tilt.y = Mathf.Clamp(tilt.y, -_tiltCap, _tiltCap);
			tilt.z = Mathf.Clamp(tilt.z, -_tiltCap, _tiltCap);
			transform.rotation = Quaternion.Euler(tilt.y, 0, -tilt.x);
		}
	}
	void FixedUpdate()
	{
		foreach (var r in _remotePieces)
		{
			if (r != null && r.gameObject.activeInHierarchy)
			{
				float forward = Vector3.Dot(Vector3.forward, transform.up);
				float right = Vector3.Dot(Vector3.right, transform.up);

				r.AddForce(new Vector3(right, 0, forward) * Physics.gravity.magnitude, ForceMode.Acceleration);
			}
		}
	}
}

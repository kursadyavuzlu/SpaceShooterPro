using UnityEngine;

public class Laser : MonoBehaviour
{
	[SerializeField] private float _speed = 1f;

	private void Update()
	{
		transform.Translate(Vector3.up * Time.deltaTime * _speed);

		if(transform.position.y > 8f)
		{
			Destroy(this.gameObject);
		}
	}
}

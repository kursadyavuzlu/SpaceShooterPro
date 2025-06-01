using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private float _speed = 1.0f;

	private void Awake()
	{
		transform.position = new Vector3(0f, 0f , 0f);
	}

	private void Update()
	{
		CalculateMovement();
	}

	void CalculateMovement()
	{
		float horizontalInput = Input.GetAxis("Horizontal");
		float verticalInput = Input.GetAxis("Vertical");

		Vector3 direction = new Vector3(horizontalInput, verticalInput, 0f);

		transform.Translate(direction * Time.deltaTime * _speed);

		transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.85f, 0f), 0);

		if (transform.position.x > 11.26f)
		{
			transform.position = new Vector3(-11.26f, transform.position.y, 0f);
		}
		else if (transform.position.x < -11.26f)
		{
			transform.position = new Vector3(11.26f, transform.position.y, 0f);
		}
	}
}

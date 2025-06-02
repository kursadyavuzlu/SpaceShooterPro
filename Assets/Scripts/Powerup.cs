using UnityEngine;

public class Powerup : MonoBehaviour
{
	[SerializeField] private float _speed = 3f;

	private void Update()
	{
		transform.Translate(Vector3.down * Time.deltaTime * _speed);
		if (transform.position.y < -8)
		{
			Destroy(this.gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			Player player = other.GetComponent<Player>();
			if (player != null)
			{
				player.TripleShotActive();
			}

			Destroy(this.gameObject );
		}
	}
}

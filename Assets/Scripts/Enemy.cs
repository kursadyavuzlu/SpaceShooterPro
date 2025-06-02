using UnityEngine;

public class Enemy : MonoBehaviour
{
	private float _speed = 5f;



	private void Update()
	{
		transform.Translate(Vector3.down * Time.deltaTime * _speed);

		if (transform.position.y < -5.3f)
		{
			float randomX = Random.Range(-11.26f, 11.26f);
			transform.position = new Vector3(randomX, 7.3f, 0f);
		}

	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
		{
			Player player = other.transform.GetComponent<Player>();

			if (player != null) 
			{
				player.Damage();
			}

			Destroy(this.gameObject);
		}
		else if(other.CompareTag("Laser"))
		{
			Destroy(other.gameObject);
			Destroy(this.gameObject);
		}
	}


}

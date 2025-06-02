using UnityEngine;

public class Powerup : MonoBehaviour
{
	[SerializeField] private float _speed = 3f;
	[SerializeField] private float _powerUpID;

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
				switch (_powerUpID)
				{
					case 0:
						player.TripleShotActive();
						break;
					case 1:
						player.SpeedPowerupActive();
						break;
					case 2:
						player.ShieldPowerupActive();
						break;
					default:
						Debug.Log("DEFAULT VALUE !");
						break;
				}
			}

			Destroy(this.gameObject );
		}
	}
}

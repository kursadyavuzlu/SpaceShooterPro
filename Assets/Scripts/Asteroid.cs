using UnityEngine;

public class Asteroid : MonoBehaviour
{
	[SerializeField] private float _rotateSpeed = 3.0f;
	[SerializeField] private GameObject _explosionPrefab;
	private SpawnManager _spawnManager;




	private void Start()
	{
		_spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
	}


	private void Update()
	{
		transform.Rotate(Vector3.forward * Time.deltaTime * _rotateSpeed);
	}


	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Laser"))
		{
			Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
			Destroy(other.gameObject);
			_spawnManager.StartSpawning();
			Destroy(this.gameObject, 0.25f);
		}
	}



}

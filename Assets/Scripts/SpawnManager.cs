using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	[SerializeField] private GameObject _enemyPrefab;
	[SerializeField] private GameObject _enemyContainer;
	[SerializeField] private GameObject[] _powerups;

	private bool _stopSpawning = false;


	private void Start()
	{
		
	}

	public void StartSpawning()
	{
		StartCoroutine(SpawnEnemyRoutine());
		StartCoroutine(SpawnPowerUpRoutine());
	}


	IEnumerator SpawnEnemyRoutine()
	{
		yield return new WaitForSeconds(3.0f);
		while (_stopSpawning == false)
		{
			Vector3 spawnPos = new Vector3(Random.Range(-11.26f, 11.26f), 7.3f, 0f);
			GameObject newEnemy = Instantiate(_enemyPrefab, spawnPos , Quaternion.identity);
			newEnemy.transform.parent = _enemyContainer.transform;
			yield return new WaitForSeconds(5.0f);
		}
	}

	public void OnPlayerDeath()
	{
		_stopSpawning = true;
	}

	IEnumerator SpawnPowerUpRoutine()
	{
		yield return new WaitForSeconds(3.0f);
		while (_stopSpawning == false)
		{
			Vector3 spawnPos = new Vector3(Random.Range(-11.26f, 11.26f), 7.3f, 0f);
			int randomPowerup = Random.Range(0, 3);
			Instantiate(_powerups[randomPowerup], spawnPos , Quaternion.identity);
			yield return new WaitForSeconds(Random.Range(7.7f, 16.7f));
		}
	}
}

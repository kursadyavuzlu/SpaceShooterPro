using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	[SerializeField] private GameObject _enemyPrefab;
	[SerializeField] private GameObject _enemyContainer;
	[SerializeField] private GameObject _tripleShotPowerupPrefab;

	private bool _stopSpawning = false;


	private void Start()
	{
		StartCoroutine(SpawnEnemyRoutine());
		StartCoroutine(SpawnPowerUpRoutine());
	}


	IEnumerator SpawnEnemyRoutine()
	{
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
		while (_stopSpawning == false)
		{
			Vector3 spawnPos = new Vector3(Random.Range(-11.26f, 11.26f), 7.3f, 0f);
			Instantiate(_tripleShotPowerupPrefab, spawnPos , Quaternion.identity);
			yield return new WaitForSeconds(Random.Range(7.7f, 16.6f));
		}
	}
}

using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	[SerializeField] private GameObject _enemyPrefab;
	[SerializeField] private GameObject _enemyContainer;

	private bool _stopSpawning = false;


	private void Start()
	{
		StartCoroutine(SpawnRoutine());
	}


	IEnumerator SpawnRoutine()
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
}

using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private float _speed = 1.0f;
	private float _speedMultiplier = 2.5f;
	[SerializeField] private GameObject _laserPrefab;

	[SerializeField] private float _fireRate = 0.5f;
	private float _canFire = -1f;

	[SerializeField] private int _lives = 3;

	private SpawnManager _spawnManager;

	private bool _isTripleShotActive = false;
	[SerializeField] private GameObject _tripleLaserPrefab;

	private bool _isSpeedPowerupActive = false;
	private bool _isShieldPowerupActive = false;

	[SerializeField] private GameObject _shield;








	private void Awake()
	{
		transform.position = new Vector3(0f, 0f, 0f);
	}

	private void Start()
	{
		_spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();

		if (_spawnManager == null)
		{
			Debug.LogError("The Spawn Manager is NULL !!! ");
		}
	}

	private void Update()
	{
		CalculateMovement();

		if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
		{
			FireLaser();
		}
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

	void FireLaser()
	{
		_canFire = Time.time + _fireRate;
		Vector3 offset = new Vector3(0f, 0.8f, 0f);


		if (_isTripleShotActive == true)
		{
			Instantiate(_tripleLaserPrefab, transform.position + offset, Quaternion.identity);
		}
		else
		{
			Instantiate(_laserPrefab, transform.position + offset, Quaternion.identity);
		}

	}

	public void Damage()
	{
		if (_isShieldPowerupActive == true) 
		{
			_isShieldPowerupActive = false;
			_shield.SetActive(false);
		}
		else
		{
			_lives--;

			if (_lives < 1)
			{
				_spawnManager.OnPlayerDeath();
				Destroy(this.gameObject);
			}
		}

		
	}


	public void TripleShotActive()
	{
		_isTripleShotActive = true;
		StartCoroutine(TripleShotPowerDownRoutine());
	}

	IEnumerator TripleShotPowerDownRoutine()
	{
		yield return new WaitForSeconds(5.0f);
		_isTripleShotActive = false;
	}

	public void SpeedPowerupActive()
	{
		_isSpeedPowerupActive = true;
		_speed *= _speedMultiplier;
		StartCoroutine(SpeedPowerDownRoutine());
	}

	IEnumerator SpeedPowerDownRoutine()
	{
		yield return new WaitForSeconds(5.0f);
		_isSpeedPowerupActive = false;
		_speed /= _speedMultiplier;
	}

	public void ShieldPowerupActive()
	{
		_shield.SetActive(true);
		_isShieldPowerupActive = true;
	}
}

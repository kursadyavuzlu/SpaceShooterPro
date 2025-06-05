using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _scoreText;
	[SerializeField] private Image _livesImg;
	[SerializeField] private Sprite[] _liveSprites;
	[SerializeField] private TextMeshProUGUI _gameOverText;
	[SerializeField] private TextMeshProUGUI _restartText;
	private GameManager _gameManager;

	private void Awake()
	{
		_scoreText.text = "Score: " + 0;
		_gameOverText.gameObject.SetActive(false);
		_gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();

		if ( _gameManager == null)
		{
			Debug.LogError("GameManager is NULL !!!");
		}
	}

	public void UpdateScore(int playerScore)
	{
		_scoreText.text = "Score: " + playerScore.ToString();
	}

	public void UpdateLives(int currentLives)
	{
		_livesImg.sprite = _liveSprites[currentLives];

		if (currentLives == 0)
		{
			GameOverSequence();
		}
	}

	void GameOverSequence()
	{
		_gameManager.GameOver();
		_gameOverText.gameObject.SetActive(true);
		_restartText.gameObject.SetActive(true);
		StartCoroutine(GameOverFlickerRoutine());
	}

	IEnumerator GameOverFlickerRoutine()
	{
		while (true)
		{
			_gameOverText.text = "GAME OVER";
			yield return new WaitForSeconds(0.5f);
			_gameOverText.text = " ";
			yield return new WaitForSeconds(0.5f);
		}
	}

}
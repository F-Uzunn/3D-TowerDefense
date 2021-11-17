using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerr : MonoBehaviour
{

	public static bool GameIsOver;
	public GameObject gameOverUI;
	public GameObject completeLevelUI;

	void Start()
	{
		GameIsOver = false;
	}

	void Update()
	{
		if (GameIsOver)
			return;

        if (Input.GetKeyDown("r"))
        {
			EndGame();
        }

		if (Input.GetKey("q"))
		{
			PlayerPrefs.DeleteAll();
		}

		if (PlayerStats.Lives <= 0)
		{
			EndGame();
		}
	}

	void EndGame()
	{
		GameIsOver = true;
		gameOverUI.SetActive(true);
	}

	public void WinLevel()
	{
		Debug.Log("LEVEL WON!");
		GameIsOver = true;
		completeLevelUI.SetActive(true);
	}

}
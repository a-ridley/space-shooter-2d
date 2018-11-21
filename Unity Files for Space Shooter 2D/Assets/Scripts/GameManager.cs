using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	bool gameOver = false;
	bool bossDefeated = false;

	public float restartDelay = 5f;

	public GameObject completeLevelUI;

	public void GameOver() {
		// Player died before defeating the boss
		Debug.Log ("Game over");
		Invoke ("RestartLevel", restartDelay);
	}

	public void BossDefeated() {
		// Boss is defeated -> start next level
		Debug.Log ("Boss defeated");
		completeLevelUI.SetActive (true);
	}

	void RestartLevel() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	void NextLevel() {

	}
}

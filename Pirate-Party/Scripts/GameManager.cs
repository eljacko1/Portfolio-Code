using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    bool gameHasEnded = false;

    public float restartDelay = 1f;
    public GameObject GameEndUI;
    public GameObject playerManager;

    public void GameEnd()
    {
        GameEndUI.SetActive(true);
        playerManager.SetActive(false);
    }

    public void EndGame ()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game End");
            Invoke("Restart", restartDelay);
        }
    }
 
}

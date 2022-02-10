using UnityEngine;
using TMPro;

public class Endtrigger : MonoBehaviour
{
    public GameManager gameManager;
    public TMP_Text Victory;

    public AudioClip VictorySound;
    public AudioClip Firework;
    public AudioSource Source;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player1")
        {
            gameManager.GameEnd();
            Victory.text = "Player 1 Wins!";
        }
        if (other.gameObject.tag == "Player2")
        {
            gameManager.GameEnd();
            Victory.text = "Player 2 Wins!";
        }
    }

}

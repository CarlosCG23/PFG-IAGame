using Grpc.Core;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    // VARIABLES GLOBALES
    public GameObject starManagerObject;
    public TextMeshProUGUI GameStatusTMP;
    public static int gameStatus;

    private void Update()
    {
        if (gameStatus == -1)
        {
            GameStatusTMP.text = "Game in Progress";
        }
        else if (gameStatus == 0)
        {
            GameStatusTMP.text = "You Win";
        }
        else if (gameStatus == 1)
        {
            GameStatusTMP.text = "You Lose";
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // obtiene el script asociado al objeto
        StarManagerScript starManagerScript = starManagerObject.GetComponent<StarManagerScript>();

        // si la colision es con el player cargara la escena nuevamente
        if (collision.CompareTag("Player"))
        {
            PlayerMove player = collision.GetComponent<PlayerMove>();
           
            // si el objeto existe entonces e añadirá una estrella
            if (starManagerScript != null)
            {
                starManagerScript.StarAdd();
            }
            gameStatus = 0;

            //player.ResetPlayer();
            Invoke("LoadScene", 1f);
            //SceneManager.LoadScene("SampleScene");
        }
    }

    private void LoadScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}

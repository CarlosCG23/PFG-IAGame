using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    // VARIABLES GLOBALES
    public GameObject starManagerObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // obtiene el script asociado al objeto
        StarManagerScript starManagerScript = starManagerObject.GetComponent<StarManagerScript>();

        // si la colision es con el player cargara la escena nuevamente
        if (collision.CompareTag("Player"))
        {
            // si el objeto existe entonces e añadirá una estrella
            if (starManagerScript != null)
            {
                starManagerScript.StarAdd();
            }
            SceneManager.LoadScene("SampleScene");
        }
    }
}

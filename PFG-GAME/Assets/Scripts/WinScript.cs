using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    public GameObject starManagerObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StarManagerScript starManagerScript = starManagerObject.GetComponent<StarManagerScript>();

        if (collision.CompareTag("Player"))
        {
            if (starManagerScript != null)
            {
                starManagerScript.StarAdd();
            }
            SceneManager.LoadScene("SampleScene");
        }
    }
}

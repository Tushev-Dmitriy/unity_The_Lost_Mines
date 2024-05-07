using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public GameObject InGameCanvas;
    public int number;
    public void GoToLevel(int number)
    {
        SceneManager.LoadScene(number, LoadSceneMode.Single);
        InGameCanvas.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        GoToLevel(number);
    }
}

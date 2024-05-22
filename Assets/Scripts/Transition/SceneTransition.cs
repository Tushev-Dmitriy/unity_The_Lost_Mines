using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public int number;
    public GameObject start;
    public GameObject mine;

    private GameObject player;
    private Vector3[] positions = new Vector3[2] { new Vector3(0, 12.3f, 0), new Vector3(103, 12.3f, 0) };

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void GoInside()
    {
        int i = number;

        if (i == 0)
        {
            start.SetActive(true);
            mine.SetActive(false);
            player.transform.position = positions[i];
        }
        else if (i == 1)
        {
            start.SetActive(false);
            mine.SetActive(true);
            player.transform.position = positions[i];
        }
    }
}

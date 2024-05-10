using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public int number;
    public GameObject start;
    public GameObject[] mine;

    private GameObject player;
    private Vector3[] positions = new Vector3[7] { new Vector3(0, 12.3f, 0), new Vector3(103, 12.3f, 0),
                                                   new Vector3(103, 12.3f, 15), new Vector3(103, 12.3f, 30), 
                                                   new Vector3(103, 12.3f, 45), new Vector3(103, 12.3f, 60),
                                                   new Vector3(103, 12.3f, 75) };

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
            for (int j = 0; j < mine.Length; j++)
            {
                mine[j].SetActive(false);
            }
            player.transform.position = positions[i];
        }
        else if (i >= 1 && i <= 6)
        {
            start.SetActive(false);
            mine[i-1].SetActive(true);
            player.transform.position = positions[i];
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public int number;
    public GameObject start;
    public GameObject mine;
    public GameObject directLight;

    private GameObject player;
    private Vector3[] positions = new Vector3[2] { new Vector3(0, 12.3f, 0), new Vector3(103, 12.3f, 0)};

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int i = number;
            switch (i)
            {
                case 0:
                    start.SetActive(true);
                    mine.SetActive(false);
                    directLight.SetActive(true);
                    player.transform.position = positions[i];
                    break;
                case 1:
                    start.SetActive(false);
                    mine.SetActive(true);
                    directLight.SetActive(false);
                    player.transform.position = positions[i];
                    break;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToMine : MonoBehaviour
{
    public SceneTransition sceneTransition;
    public int num;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            sceneTransition.number = num;
            sceneTransition.GoInside();
        }
    }
}
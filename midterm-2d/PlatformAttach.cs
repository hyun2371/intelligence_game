using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttach : MonoBehaviour
{
    GameObject player;

    private void Start()
    {
        player = GameObject.Find("player");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("triggerEntered");
        if (other.gameObject == player)
        {
            player.transform.parent = transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        player.transform.parent = null;
    }
}

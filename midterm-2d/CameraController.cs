using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        this.player = GameObject.Find("player");
    }

    void Update()
    {
        transform.position = new Vector3(this.player.transform.position.x, transform.position.y, transform.position.z);
    }
    
}

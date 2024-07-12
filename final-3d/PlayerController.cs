using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameObject terrain;
    bool isTriggered;
    void Start()
    {
        this.terrain = GameObject.Find("Terrain");
    }

    private void Update() // 시연용
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            MovePlayer(0, 1, -3);
        }

        // 숫자 2 키를 누르는 경우
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            MovePlayer(452, 10, 327);
        }

        // 숫자 3 키를 누르는 경우
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            MovePlayer(153, 1, 337);
        }
    }
    // AppleZone 안에 들어가면 카메라 활성화 
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "AppleZone")
        {
            terrain.GetComponent<CameraController>().ActivateAppleZoneCamera();
        }

    }

    public void MovePlayer(float x, float y, float z)
    {
        this.transform.position = new Vector3(x, y, z);
    }
}

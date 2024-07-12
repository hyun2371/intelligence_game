using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 카메라, 사람 시점 변환 제어 
public class CameraController : MonoBehaviour
{
    GameObject mainCamera;
    GameObject player;
    GameObject bamsongiGenerator;
    public bool isAppleZoneActivated = false; // apple zone에 있을 때 true (-> 해당 구역에만 밤송이 던지려고 )

    void Start()
    {
        this.mainCamera = GameObject.Find("Main Camera");
        this.mainCamera.SetActive(false);
        this.player = GameObject.Find("FirstPersonController");
        this.bamsongiGenerator = GameObject.Find("BamsongiGenerator");
    }

    private void Update()
    {
        // P 버튼 입력 시 AppleZone 빠져나옴 
        if (Input.GetKeyDown(KeyCode.P))
        {
            InactivateAppleZoneCamera();
        }

        // 클릭 시 밤송이 활성화
        if (Input.GetMouseButtonDown(0)&& isAppleZoneActivated)
        {
            bamsongiGenerator.GetComponent<BamsongiGenerator>().Generate();
        }
    }

    // 카메라 활성화 && AppleZone으로 이동
    public void ActivateAppleZoneCamera()
    {
        ActivateCamera();
        this.mainCamera.transform.position = new Vector3(0, 4, -3.8f);
        isAppleZoneActivated = true;
    }

    // 플레이어 활성화 && AppleZone 밖으로 이동
    public void InactivateAppleZoneCamera()
    {
        InactivateCamera();
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().MovePlayer(0, 2, 3);
        isAppleZoneActivated = false;
    }

    // 카메라 활성화 && player 비활성화 
    public void ActivateCamera()
    {
        this.mainCamera.SetActive(true);
        this.player.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // 카메라 비활성화 && player 활성화 
    public void InactivateCamera()
    {
        Debug.Log("Inactivate Camera");
        this.mainCamera.SetActive(false);
        this.player.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerController : MonoBehaviour
{
    int direction = 1;
    public float tigerSpeed; //generator로부터 가져옴

    // 활성화되었을 때 실행되는 콜백함수 
    private void OnEnable()
    {
        this.tigerSpeed = GameObject.Find("AppleTrees").GetComponent<AppleTreeGenerator>().obstacleSpeed;
    }

    void Update()
    {
        TranslateHorizontal();
    }

    void TranslateHorizontal()
    {
        // 현재 위치에 따라 방향을 조정
        if (transform.position.x >= 7)
        {
            direction = -1;  // 오른쪽 경계에 도달하면 왼쪽으로 방향 전환
        }
        else if (transform.position.x <= -10)
        {
            direction = 1;  // 왼쪽 경계에 도달하면 오른쪽으로 방향 전환
        }

        // 방향에 따라 오브젝트 이동
        transform.Translate(direction * tigerSpeed * Time.deltaTime, 0, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bamsongi")
        {
            GameObject.Find("GameDirector").GetComponent<GameDirector>().ResetAppleGame();
        }
    }
    
}

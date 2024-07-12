using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// speed만큼 나무를 좌우로 이동시킴
public class AppleTreeMovingController : MonoBehaviour
{
    public float speed; // generator로부터 가져오는 변수 
    int direction = 1;
    GameObject appleTree;
    

    private void Start()
    {   this.appleTree = GameObject.Find("AppleTrees");
        this.speed = appleTree.GetComponent<AppleTreeGenerator>().treeSpeed;
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
        transform.Translate(direction * speed * Time.deltaTime, 0, 0);
    }
}

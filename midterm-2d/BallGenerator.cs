using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerator : MonoBehaviour
{
    public GameObject ballPrefab;
    float span = 2.0f;
    float delta = 0;

    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span) 
        {
            this.delta = 0; 
            for (int i = 0; i < 15; i++)
            {
                GameObject go = Instantiate(ballPrefab) as GameObject; // GameObject 타입으로 인스턴스화
                int px = Random.Range(11, 29); // 랜덤 x 좌표
                go.transform.position = new Vector3(px, 3, 0);
            }  
        }
    }
}

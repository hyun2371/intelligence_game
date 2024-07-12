using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BamsongiGenerator : MonoBehaviour
{
    public GameObject bamsongiPrefab;

    
    public void Generate()
    {
        GameObject bamsongi = Instantiate(bamsongiPrefab) as GameObject;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 worldDir = ray.direction; // 카메라에서 탭한 좌표로 향하는 벡터

        //direction 방향으로 힘을 2000 가함
        bamsongi.GetComponent<BamsongiController>().Shoot(worldDir.normalized * 2000);
    }

}

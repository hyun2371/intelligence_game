using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 사과 나무 생성 및 레벨 제어 
public class AppleTreeGenerator : MonoBehaviour
{

    public GameObject treePrefab;
    GameObject level1, level2, level3, level4, level5;
    public float treeSpeed = 0, obstacleSpeed = 7;
    GameObject chicken, tiger;
    /*
     * level1: 멈춰있는 나무
     * level2: 나무 움직임 
     * level3: 나무 움직임 & 닭 (속도 증가)
     * level4: 나무 움직임 & 닭 (속도 증가)
     */
    private void Start()
    {
        this.tiger = GameObject.Find("tiger");
        this.tiger.SetActive(false);
        this.chicken = GameObject.Find("chicken");
        this.chicken.SetActive(false);
    }
    public void GenerateLevel1() //초기상태
    {
        this.treeSpeed = 0;
        this.level1 = Instantiate(treePrefab, transform.position, Quaternion.identity, transform) as GameObject;
    }

    public void GenerateLevel2() //level1 클리어
    {
        Destroy(this.level1);
        this.treeSpeed = 5;
        this.level2 = Instantiate(treePrefab, transform.position, Quaternion.identity, transform) as GameObject;
    }

    public void GenerateLevel3() //level2 클리어 
    {
        Destroy(this.level2);
        this.treeSpeed += 2; // 트리 이동 속도 증가
        this.level3 = Instantiate(treePrefab) as GameObject;
        this.chicken.SetActive(true);
        this.obstacleSpeed = 5.5f;
    }

    public void GenerateLevel4() // level3 클리어
    {
        Destroy(this.level3);
        this.treeSpeed += 2;
        this.level4 = Instantiate(treePrefab) as GameObject;
        this.obstacleSpeed = 10;
    }

    public void GenerateLevel5() // level4 클리어 
    {
        Destroy(this.level4);
        this.level5 = Instantiate(treePrefab) as GameObject;
        this.chicken.SetActive(false);
        this.tiger.SetActive(true);
        this.obstacleSpeed = 7;

    }

    public void EndGame()
    {
        Destroy(this.level5);
        this.tiger.SetActive(false);
    }
}

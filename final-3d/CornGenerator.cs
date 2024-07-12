using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornGenerator : MonoBehaviour
{
    public GameObject cornPrefab;

    private void Start()
    {
        for (int i = 0; i < 5; i++) Generate();
    }

    public void Generate()
    {
        float randomX = Random.Range(150f, 160f);
        float randomZ = Random.Range(340f, 350f);
        Vector3 newPosition = new Vector3(randomX, transform.position.y, randomZ);
        GameObject corn = Instantiate(cornPrefab, newPosition, cornPrefab.transform.rotation) as GameObject;
        
    }
}

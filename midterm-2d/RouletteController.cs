using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteController : MonoBehaviour
{
    float rotSpeed = 0;
    float angle = 0;
    bool isRotating = false;
    bool isLocked = false;
    public GameObject potion1, potion2, potion3;
    
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !isLocked)
        {
            this.rotSpeed = Random.Range(8, 15);
            isRotating = true;
        }

        // 회전 속도만큼 룰렛 회전
        transform.Rotate(0, 0, this.rotSpeed);

        //감속
        this.rotSpeed *= 0.96f;
        
        if (this.rotSpeed < 0.01f && isRotating)
        {
            this.rotSpeed = 0;
            float angle = transform.eulerAngles.z;
            if (330 <= angle && angle < 30|| 150 <= angle && angle < 210)
            {
                isLocked = true;
                potion1.SetActive(true);
            }
            else if (30 <= angle && angle < 90|| 210 <= angle && angle < 270)
            {
                isLocked = true;
                potion2.SetActive(true);
            }
            else if (90 <= angle && angle < 150|| 270 <= angle && angle < 330)
            {
                isLocked = true;
                potion3.SetActive(true);
            }
            
            if (isRotating)
            {
                isRotating = false;
            }
           

        }
        

    }
}

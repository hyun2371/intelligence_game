using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fish1Controller : MonoBehaviour
{
    GameObject fishDead, fishAlive, fishGauge, fishBar;
    float span = 0.5f;
    float delta = 0;
    bool isTriggered = false;
    bool isAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        this.fishAlive = GameObject.Find("Fish1Alive");
        this.fishDead = GameObject.Find("Fish1Dead");
        this.fishDead.SetActive(false);
        this.fishGauge = GameObject.Find("fish1Gauge");
        this.fishBar = GameObject.Find("fish1Bar");
        this.fishBar.SetActive(false);
    }

    public void Die()
    {
        this.fishAlive.SetActive(false);
        this.fishDead.SetActive(true);
        isAlive = false;
    }

    private void Update()
    {
        if (isTriggered)
        {
            this.fishBar.SetActive(true);
            if (isAlive)
            {
                GameObject.Find("fish1Body").GetComponent<ParticleSystem>().Play();
                ManageFishGauge();
            }
            
        }
        else
        {
            this.fishBar.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TriggerEnter");
        isTriggered = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("TriggerExit");
        isTriggered = false;
    }

    private void ManageFishGauge()
    {
        this.delta += Time.deltaTime; // 전 프레임과 현재 프레임간 시간 차이
        if (this.delta > this.span) // 1초가 지나면
        {
            this.delta = 0; // 다시 1초 세기 위해 delta값 초기화
            this.fishGauge.GetComponent<Image>().fillAmount += 0.05f;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            this.fishGauge.GetComponent<Image>().fillAmount -= 0.06f;
        }

        if (this.fishGauge.GetComponent<Image>().fillAmount == 0)
        {
            Die();
        }
    }

}
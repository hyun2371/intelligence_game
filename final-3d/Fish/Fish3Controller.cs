using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fish3Controller : MonoBehaviour
{
    GameObject fishDead, fishAlive, fishGauge, fishBar;
    float span = 0.5f;
    float delta = 0;
    bool isTriggered = false, isAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        this.fishAlive = GameObject.Find("Fish3Alive");
        this.fishDead = GameObject.Find("Fish3Dead");
        this.fishDead.SetActive(false);
        this.fishGauge = GameObject.Find("fish3Gauge");
        this.fishBar = GameObject.Find("fish3Bar");
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
            if (isAlive)
            {
                GameObject.Find("fish3Body").GetComponent<ParticleSystem>().Play();
            }
            this.fishBar.SetActive(true);
            this.delta += Time.deltaTime; // 전 프레임과 현재 프레임간 시간 차이
            if (this.delta > this.span) // 1초가 지나면
            {
                this.delta = 0; // 다시 1초 세기 위해 delta값 초기화
                this.fishGauge.GetComponent<Image>().fillAmount += 0.05f;
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                this.fishGauge.GetComponent<Image>().fillAmount -= 0.02f;
            }

            if (this.fishGauge.GetComponent<Image>().fillAmount == 0)
            {
                Die();
            }
        }
        else
        {
            this.fishBar.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isTriggered = true; // 한 번만이 아니라 계속 수행되어야 하므로 변수로 빼고 update 안에 분기문 걸음 
    }

    private void OnTriggerExit(Collider other)
    {
        isTriggered = false;
    }
}

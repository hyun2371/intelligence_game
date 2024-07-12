using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    GameObject appleRoundText, appleCountText, fishCountText, cornCountText;
    GameObject infoText, infoPanel;
    int infoPageCount = 1;
    int fishCount = 0,cornCount = 0;
    public int appleCount = 0; //debug
    GameObject appleTreeGenerator;
    GameObject terrain;
    int currentLevel = 1;
    int currentAppleRound = 1;
    bool isLocked = false;
    void Start()
    {
        this.appleCountText = GameObject.Find("AppleCountText");
        this.fishCountText = GameObject.Find("FishCountText");
        this.cornCountText = GameObject.Find("CornCountText");
        this.appleRoundText = GameObject.Find("RoundText");
        this.appleTreeGenerator = GameObject.Find("AppleTrees");
        this.infoText = GameObject.Find("InfoText");
        this.infoPanel = GameObject.Find("InfoPanel");
        appleTreeGenerator.GetComponent<AppleTreeGenerator>().GenerateLevel1();
        this.terrain = GameObject.Find("Terrain");
    }

    void Update()
    {
        ManageAppleGame();
        DisplayGameInfo();
    }

    // 다음 라운드 이동 ( AppleZone 활성, 레벨 증가 )
    private void AppleNextRound()
    {
        terrain.GetComponent<CameraController>().ActivateAppleZoneCamera();
        currentAppleRound++;
        DisplayRoundText();
    }

    private void AppleGameClear()
    {
        appleTreeGenerator.GetComponent<AppleTreeGenerator>().EndGame(); // 나무, 장애물 파괴 
        isLocked = true;
        terrain.GetComponent<CameraController>().InactivateAppleZoneCamera();
        GameObject.Find("RoundText").GetComponent< TextMeshProUGUI > ().text = "사과를 모두 획득했구나!\n 덕분에 사과잼을 만들 수 있겠어";
        Invoke("MoveLevel2", 2f); // 2초 후 해당 함수 호출 
    }


    public void ResetAppleGame()
    {
        this.appleCount = 0;
        this.currentAppleRound = 1;
        DisplayAppleCountText();
        DisplayRoundText();
        GameObject.Find("tiger").SetActive(false);
        Destroy(GameObject.FindGameObjectWithTag("Tree"));
        appleTreeGenerator.GetComponent<AppleTreeGenerator>().GenerateLevel1();
    }

    private void DisplayFishCountText()
    {
        this.fishCountText.GetComponent<TextMeshProUGUI>().text = "Fish X " + fishCount;
    }

    private void DisplayAppleCountText()
    {
        this.appleCountText.GetComponent<TextMeshProUGUI>().text = "Apple X " + appleCount;
    }

    private void DisplayCornCountText()
    {
        this.cornCountText.GetComponent<TextMeshProUGUI>().text = "Corn X " + cornCount;
    }

    private void DisplayRoundText()
    {
       this.appleRoundText.GetComponent<TextMeshProUGUI>().text = "Round " + currentAppleRound;
    }

    public void IncreaseAppleCount()
    {
        appleCount++;
        DisplayAppleCountText();
    }

    public void IncreaseFishCount()
    {
        fishCount++;
        DisplayFishCountText();
        if (fishCount == 3)
        {
            GameObject.Find("RoundText").GetComponent<TextMeshProUGUI>().text = "물고기를 다 잡았구나!\n 이제 재료를 하나만 더 구해면 돼~";
            Invoke("MoveLevel3", 2f);
        }
    }

    public void IncreaseCornCount()
    {
        cornCount++;
        DisplayCornCountText();
        if (cornCount == 5)
        {
            GameObject.Find("RoundText").GetComponent<TextMeshProUGUI>().text = "고마워 덕분에 재료를 모두 준비해서 맛있는 샌드위치를 먹을 수 있게 되었어 ";
        }
    }

    private void DisplayGameInfo()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            infoPanel.SetActive(true);
            infoText.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.N)){
            infoPageCount++;
        }
        switch (infoPageCount)
        {
            case 1:
                this.infoText.GetComponent<TextMeshProUGUI>().text = "안녕, 내 이름은 안나야!\n\n나는 1일 1샌드위치 없이는 살 수 없어\n\n근데 샌드위치 재료가 다 떨어졌지 뭐야\n애플잼을 위한 사과 32개, 물고기 3마리, 그리고 옥수수빵을 위한 옥수수 5개가 필요해\n\n날 도와주겠니? 방법은 어렵지 않아!\n\n각 미니게임을 플레이해서 재료를 수급해보자:)\n\nn을 누르면 각 게임별 방법을 설명해줄게!";
                break;
            case 2:
                this.infoText.GetComponent<TextMeshProUGUI>().text = "<사과 채집하기>\n밤송이를 던져 사과 나무의 사과를 채집하자!\n사격 지점에서 왼쪽 마우스 버튼을 누르면 밤송이를 던질 수 있어\n사격 지점에서 벗어나려면 p 버튼을 누르면 돼!\n각 라운드마다 사과 8개를 획득하면 다음 라운드로 넘어갈거야\n\nn을 누르면 다른 게임들도 알려줄게";
                break;
            case 3:
                this.infoText.GetComponent<TextMeshProUGUI>().text = "<물고기 수렵하기>\n각 물고기 앞 가서 f 버튼을 빠르게 눌러 쉽게 잡을 수 있어\n\n<옥수수 캐기>\ng 버튼을 5번 누르면 옥수수가 자랄거야\n\nn 눌러 게임을 시작해볼까?";
                break;
            default:
                infoPanel.SetActive(false);
                infoText.SetActive(false);
                infoPageCount = 1;
                break;
        }

    }

    private void ManageAppleGame()
    {
        if (this.appleCount == 8 * currentAppleRound && currentAppleRound == 1) // 레벨 승급 조건 만족
        {
            AppleNextRound();
            appleTreeGenerator.GetComponent<AppleTreeGenerator>().GenerateLevel2();

        }
        if (this.appleCount == 8 * currentAppleRound && currentAppleRound == 2)
        {
            AppleNextRound();
            appleTreeGenerator.GetComponent<AppleTreeGenerator>().GenerateLevel3();
        }
        if (this.appleCount == 8 * currentAppleRound && currentAppleRound == 3)
        {
            AppleNextRound();
            appleTreeGenerator.GetComponent<AppleTreeGenerator>().GenerateLevel4();
        }
        if (this.appleCount == 8 * currentAppleRound && currentAppleRound == 4)
        {
            AppleNextRound();
            appleTreeGenerator.GetComponent<AppleTreeGenerator>().GenerateLevel5();
        }
        if (this.appleCount == 8 * currentAppleRound && currentAppleRound == 5 && !isLocked)
        {
            AppleGameClear();
        }
    }

    private void MoveLevel2()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().MovePlayer(452, 10, 327);
        GameObject.Find("RoundText").GetComponent<TextMeshProUGUI>().text = "강 안에 들어가보자 ";
    }

    private void MoveLevel3()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().MovePlayer(153, 1, 337);
        GameObject.Find("RoundText").GetComponent<TextMeshProUGUI>().text = "G를 누르면 옥수수를 기를 수 있어!";
    }
}

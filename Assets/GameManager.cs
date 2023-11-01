using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject CoverImage;

    int count;  //초콜릿 개수  
    public TextMeshProUGUI ChocolateCount;

    
    void Start()
    {
        ChocolateEvent.EatChocolate -= CountChocolate;  // 개수가 감소되는 메소드
    }

    public void OnClickStartButton()    // Start버튼 눌렀을 때
    {
        CoverImage.SetActive(false); //배경 사라짐

        // 게임 시작되는 코드 들어가야함
    }

    public void CountChocolate()
    {
        count--;    //개수 감소
        ChocolateCount.text = string.Format($": {count}");  // 텍스트로 출력
    }

    void Eat()      //먹을 때 실행하는 메소	
    {
        ChocolateEvent.RunEatChocolate();   //사라지기 전 이벤트를 실행하도록 
        Destroy(this.gameObject);   //초콜릿 사라짐(gameObject를 적는게 맞는지 모르겠)
    }

    public void OnClickQuitButton() //Quit 버튼 눌렀을 때
    {
        #if UNITY_EDITOR    // 유니티에서는 플레이 종료되게 실행
            UnityEditor.EditorApplication.isPlaying = false;
        #else       // 앱이면 앱이 종료되게 실행
            Application.Quit();
        #endif

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

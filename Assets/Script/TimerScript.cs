using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float timerDuration = 300f; // 타이머 지속 시간 (5분 = 300초)
    public Text timerText; // 타이머를 표시할 UI 텍스트
    public GameObject nowPanel;
    //public GameObject otherPanel; // 타이머 종료 후 활성화할 다른 UI 패널

    private float timer; // 현재 타이머 값
    private bool isTimerRunning; // 타이머가 실행 중인지 여부

    private void Start()
    {
        // 타이머 초기화
        timer = timerDuration;
        isTimerRunning = true;
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            // 타이머 감소
            timer -= Time.deltaTime;

            // 타이머가 0 이하로 내려가면 종료
            if (timer <= 0f)
            {
                timer = 0f;
                isTimerRunning = false;

                // 다른 UI 패널 활성화
                nowPanel.SetActive(false);
                //otherPanel.SetActive(true);
            }

            // 타이머 텍스트 업데이트
            UpdateTimerText();
        }
    }

    private void UpdateTimerText()
    {
        // 분과 초 계산
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);

        // 텍스트 업데이트
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

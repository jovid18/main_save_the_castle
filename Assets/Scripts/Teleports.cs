using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Teleports : MonoBehaviour
{
    public InputActionReference triggerAction; // 트리거 입력 액션에 대한 레퍼런스
    public Transform loc1;
    public Transform loc2;
    public GameObject spot1;
    public GameObject spot2;
    bool pos = false;
    float span = 1.0f;
    float time = 0;
    private void Start()
    {
        Application.targetFrameRate = 60;
        // 트리거 입력 액션을 활성화
        triggerAction.action.Enable();
    }

    private void Update()
    {
        this.time += Time.deltaTime;
        // 트리거 입력 확인
        if (this.time>this.span)
        {
            if (triggerAction.action.ReadValue<float>() > 0.5f)
            {
                // 트리거 버튼이 눌렸을 때 수행할 동작을 추가
                if (pos)
                {
                    Tele1(); // 텔레포트 함수 호출
                    spot1.SetActive(false); //spot1 숨기기
                    spot2.SetActive(true); //spot2 보이기
                    pos = false;
                }
                else
                {
                    Tele2(); // 텔레포트 함수 호출
                    spot1.SetActive(true); //spot1 보이기
                    spot2.SetActive(false); //spot2 숨기기
                    pos = true;
                }
                this.time = 0;
            }

        }

    }
    void Tele1()
    {
        // 텔레포트할 위치로 이동
        transform.position = loc1.position;
        transform.rotation = loc1.transform.rotation;
    }

    void Tele2()
    {
        // 텔레포트할 위치로 이동
        transform.position = loc2.position;
        transform.rotation = loc2.transform.rotation;
    }
}
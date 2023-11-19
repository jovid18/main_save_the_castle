using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Teleports : MonoBehaviour
{
    public InputActionReference triggerAction; // 트리거 입력 액션에 대한 레퍼런스
    public Transform loc1;
    public Transform loc2;
    bool pos = false;
    int checktime = 30;
    private void Start()
    {
        Application.targetFrameRate = 60;
        // 트리거 입력 액션을 활성화
        triggerAction.action.Enable();
    }

    private void Update()
    {
        // 트리거 입력 확인
        if (checktime > 0)
        {
            checktime--;
        }
        else
        {
            if (triggerAction.action.ReadValue<float>() > 0.5f)
            {
                // 트리거 버튼이 눌렸을 때 수행할 동작을 추가
                if (pos)
                {
                    Tele1(); // 텔레포트 함수 호출
                    pos = false;
                }
                else
                {
                    Tele2(); // 텔레포트 함수 호출
                    pos = true;
                }
                checktime = 30;
            }

        }

    }
    void Tele1()
    {
        // 텔레포트할 위치로 이동
        transform.position = loc1.position;
    }

    void Tele2()
    {
        // 텔레포트할 위치로 이동
        transform.position = loc2.position;
    }
}
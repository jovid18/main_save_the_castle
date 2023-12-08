using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    void Start()
    {
        // 게임 시작 시 AudioManager의 PlayIntroAndMainMusic 메서드 호출
        AudioManager.instance.PlayIntroAndMainMusic();
    }
}

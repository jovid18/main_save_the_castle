using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : MonoBehaviour
{
    public void lv2(bool isOn)
    {
        if (isOn)
        {
            GameDirector.lv = GameDirector.level.Medium;
        }
    }
}

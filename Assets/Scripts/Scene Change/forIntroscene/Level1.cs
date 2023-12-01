using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    public void lv1(bool isOn)
    {
        if (isOn)
        {
            GameDirector.lv = GameDirector.level.Easy;
        }
    }
}

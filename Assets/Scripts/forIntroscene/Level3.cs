using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : MonoBehaviour
{
    public void lv3(bool isOn)
    {
        if (isOn)
        {
            GameDirector.lv = GameDirector.level.Hard;
        }

    }
}

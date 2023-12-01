using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill1 : MonoBehaviour
{
    public void skill1(bool isOn)
    {
        if (isOn)
        {
            GameDirector.skill[0] = true;
        }
        else
        {
            GameDirector.skill[0] = false;
        }
    }
}

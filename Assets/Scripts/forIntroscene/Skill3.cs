using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill3 : MonoBehaviour
{
    public void skill3(bool isOn)
    {
        if (isOn)
        {
            GameDirector.skill[2] = true;
        }
        else
        {
            GameDirector.skill[2] = false;
        }
    }
}

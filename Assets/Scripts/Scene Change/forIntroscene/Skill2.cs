using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Skill2 : MonoBehaviour
{
    public void skill2(bool isOn)
    {
        if (isOn)
        {
            GameDirector.skill[1] = true;
        }
        else
        {
            GameDirector.skill[1]= false;
        }
    }
}

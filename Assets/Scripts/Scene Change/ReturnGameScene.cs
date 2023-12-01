using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ReturnGameScene : MonoBehaviour
{
    public InputActionReference[] triggerActions;
    // Start is called before the first frame update
    void Start()
    {
        for (int i =0; i < triggerActions.Length; i++)
        {
            triggerActions[i].action.Enable();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        for (int i = 0; i < triggerActions.Length; i++)
        {
            if (triggerActions[i].action.ReadValue<float>() > 0.5f)
            {
                AudioManager.instance.PlayIntroAndMainMusic();
                SceneManager.LoadScene("Intro Scene");
            }
        }
    }
}

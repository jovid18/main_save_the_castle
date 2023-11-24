using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class ReturnGameScene : MonoBehaviour
{
    public InputActionReference triggerActioni;
    // Start is called before the first frame update
    void Start()
    {
        triggerActioni.action.Enable();   
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerActioni.action.ReadValue<float>() > 0.5f)
        {
            SceneManager.LoadScene("Seonghyeon Scene");
        }
    }
}

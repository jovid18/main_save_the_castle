using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

/// <summary>
/// 1. Force to grab a bow.
/// 2. Do always grab animate
/// </summary>
public class LeftHandControl : MonoBehaviour
{
    public InputActionProperty[] toDisableInputs;
    public Animator handAnimator;
    public XRDirectInteractor leftHandInteractor;  // 왼손 컨트롤러의 XR Direct Interactor
    public XRGrabInteractable objectToGrab;       // 자동으로 그랩할 오브젝트

    void Start()
    {
        if (leftHandInteractor == null || objectToGrab == null)
        {
            Debug.LogError("References not set in the AutoGrabObject script");
            return;
        }
        
        //// Call SelectEnter with the eventArgs
        leftHandInteractor.interactionManager.SelectEnter(leftHandInteractor, objectToGrab);

        // override onSelectExit event to force grab
        objectToGrab.selectExited.AddListener(ForceMaintainGrab);

        for (int i = 0; i < toDisableInputs.Length; i++)
        {
            toDisableInputs[i].action.Disable();
        }
    }

    
    void Update()
    {
        // Always animate by giving max float value to animator.
        float value = 0.99f;
        handAnimator.SetFloat("Trigger", value);
        handAnimator.SetFloat("Grip", value);


        // debug
        //float value1 = toDisableInput.action.ReadValue<float>();
        //Debug.Log(value1);
        // disable disired input
        // this time: left hand activate value 
        //for (int i=0; i<toDisableInputs.Length;i++)
        //{
        //    toDisableInputs[i].action.Disable();
        //}
    }

    private void ForceMaintainGrab(SelectExitEventArgs args)
    {
         leftHandInteractor.interactionManager.SelectEnter(leftHandInteractor, objectToGrab);
    }
}

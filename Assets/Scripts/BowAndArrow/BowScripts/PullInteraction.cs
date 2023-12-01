using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;

/// <summary>
/// Checks for a "grab"(push a button like the trigger button) in a trigger collider and tracks the movement of your hand to "pull" in a direction and for a distance.
/// I made it to pull a bowstring here, but could be used to pull open a menu, move a joystick, pull a rope, scale objects, even a pull to move locomotion system if the trigger was placed around the player
/// Has exposed events for entering and exiting the triggerCollider, starting (must be in trigger collider) and releasing the grab. 
/// Also exposes event that fires a normalised float each frame of the %distance between the initial grab and the new position of the pullTransform.
/// </summary>
public class PullInteraction : MonoBehaviour
{
    public Transform pullTransform; // pull transform

    public float maxDistance = 0.5f;

    // left controlloer 의 트리거 버튼 (검지 ) 을 받 
    public InputActionReference triggerActionL;
    public InputActionReference triggerActionR;

    public UnityEvent enteredGrabTrigger;
    public UnityEvent exitedGrabTrigger;
    // started grab event: instantiate arrow prefab.
    public UnityEvent startedGrabEvent;
    // ended grab event: launcher arrow, reset pivot rotation, reset grab point z position
    // convey the amount of pulling bowstring to parameter 
    public UnityEvent<float> endedGrabEvent;
    // pulling event: pivot rotation toward global target vector, translation grab point along z-axis
    // convey the amount of pulling bowstring to parameter 
    public UnityEvent<float> pullEvent;

    Vector3 _initGrabPos;
    bool _canGrab;
    bool _isGrabbing;
    
    XRBaseInteractor interactor;
    Transform grabberTransform;

    void Start()
    {
        _initGrabPos = pullTransform.localPosition;
        _canGrab = false;
        _isGrabbing = false;

        triggerActionL.action.started += StartGrab;
        triggerActionL.action.canceled += EndGrab;
        triggerActionR.action.started += StartGrab;
        triggerActionR.action.canceled += EndGrab;
        
    }

    void OnDestroy()
    {
        triggerActionL.action.started -= StartGrab;
        triggerActionL.action.canceled -= EndGrab;
        triggerActionR.action.started -= StartGrab;
        triggerActionR.action.canceled -= EndGrab;
    }

    void Update()
    {
        if (_isGrabbing && grabberTransform)
        {
            pullTransform.position = grabberTransform.position;
            //********//
            pullEvent?.Invoke(CalculatePullAmount());
            //********//
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactor = other.GetComponent<XRBaseInteractor>();
            if (interactor)
            {
                grabberTransform = interactor.attachTransform;   
            }

            enteredGrabTrigger?.Invoke();
            _canGrab = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _canGrab = false;
            exitedGrabTrigger?.Invoke();
        }
    }

    // start grab
    void StartGrab(InputAction.CallbackContext ctx)
    {
        if(_isGrabbing || !_canGrab)
            return;

        _isGrabbing = true;
        startedGrabEvent?.Invoke();
    }

    // release arrow
    void EndGrab(InputAction.CallbackContext ctx)
    {
        if (!_isGrabbing)
            return;
        _isGrabbing = false;
        //********//
        endedGrabEvent?.Invoke(CalculatePullAmount());
        //********//
        pullTransform.localPosition = _initGrabPos;
        grabberTransform = null;
        
    }

    float CalculatePullAmount()
    {
        float pullAmount = Vector3.Distance(_initGrabPos, pullTransform.localPosition) / maxDistance;
        pullAmount = Mathf.Clamp(pullAmount, 0.0f, 1.0f);
        return pullAmount;
    }

}

using UnityEngine;
using UnityEngine.Events;


/// <summary>
/// on collision makes kinematic and fires event. if iskinematic does nothing
/// made for arrow on impact to get locked in world and play hit sound. could also work for dart or stickymine
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class NonKineCollision : MonoBehaviour
{
    public UnityEvent collisionEvent;
    public bool hasCollided = false;
    Rigidbody _rigBod;
    Collider _collider;


    void Start()
    {
        _rigBod = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_rigBod.isKinematic)
            return;
        
        _rigBod.isKinematic = true;
        // if collision occurs,
        hasCollided = true;
        collisionEvent?.Invoke();
        _collider.enabled = false;

        //_collider.enabled = false;
        //Debug.Log($"Object: {gameObject.name}, collider enabled: {_collider.enabled}");

    }

}
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (_rigBod.isKinematic)
    //        return;

    //    _rigBod.isKinematic = true;
    //    // if collision occurs, destroy itself
    //    _collider.enabled = false;
    //    //Debug.Log($"Object: {gameObject.name}, collider enabled: {_collider.enabled}");
    //}

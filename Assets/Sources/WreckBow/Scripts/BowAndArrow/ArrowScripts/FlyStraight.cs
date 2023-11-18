using UnityEngine;

/// <summary>
/// rotates transform so that it is pointed in the direction it is moving. Doesn't do anything if the rigidbody is kinematic
/// made for arrows flight on bow and arrow
///
/// 화살이 처음에 instantiate 되면 isKinematic=false, 즉 bow랑 collision이 없음 . 하지만 날아가는 순간 isKinematic이 되어 충돌 개념이 생김.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class FlyStraight : MonoBehaviour
{
    Rigidbody _rigBod;
    Transform _trans;

    void Start()
    {
        _rigBod = GetComponent<Rigidbody>();
        _trans = transform; // arrow
    }

    private void FixedUpdate()
    {
        if (_rigBod.isKinematic)
            return;

            SetDirection();
    }

    void SetDirection()
    {
        // Look in the direction we are moving
        if (_rigBod.velocity.z > 0.5f)
            _trans.forward = _rigBod.velocity;
    }
}

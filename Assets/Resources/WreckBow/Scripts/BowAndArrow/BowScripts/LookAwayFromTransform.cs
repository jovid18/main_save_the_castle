using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Given a transform our transform will look away from it. Also can reset to an init rot.
/// This script was made to have the bow work similarly to RecRoom's Bow where the bow rotates to line up the arrow across your hands instead of wherever the bow holding hand is facing.
/// This mechanic allows for much more comfortable wrist positioning especially when trying to aim over or around something. 
/// It allows for the control of the direction of the arrow to be based on the angle between both hands instead of the angle your jiggly hand is pointing.
/// Though unrealistic and cartoony this gives much greater accuracy and control in xr.
/// </summary>
/// Pivot에 붙는 script 
public class LookAwayFromTransform : MonoBehaviour
{
    public Transform targetTransform; // pull transform
    public Transform upTransform; // bow
    Transform _trans;
    Quaternion _resetRotation;

    // unity method
    void Start()
    {
        _trans = transform; // transform(위치 회전 scale) of current object(pivot)
        _resetRotation = _trans.localRotation; // 부모 좌표계 기준 회전량 
        //Debug.Log($"intial transform.position: {_trans.position}");
    }
    public void LookAway()

    {
        // 줄 당긴 위치에서 활의 위치를 이은 벡터 (world coordinates)
        Vector3 targetDirection = _trans.position - targetTransform.position;
        // pivot이 target vector을 향하도록 rotate한다. 
        _trans.rotation = Quaternion.LookRotation(targetDirection, upTransform.up);
        //Debug.Log($"target: {targetDirection}");
    }
    public void ResetLook()
    {
        _trans.localRotation = _resetRotation;
    }

    
}

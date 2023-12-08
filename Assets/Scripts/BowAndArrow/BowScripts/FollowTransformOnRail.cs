//using UnityEngine;


///// <summary>
///// snaps our transform to the target trans, position but restricts position to be 0,0 x,y and between min and max on z when FireOnRail is fired.
///// Is reset to init pos when ResetPosition is fired.
///// Script was made to keep a bowstring only moving in one axis between 2 positions. Could be used to make slider.
/////
///// Attached to `grab point`
///// </summary>
//public class FollowTransformOnRail : MonoBehaviour
//{

//    public Transform targetTransform; // pull transform

//    public float railMin = -0.7f;
//    public float railMax = 0;

//    Transform _trans;
//    Vector3 _resetPosition;


//    void Start()
//    {
//        _trans = transform; // grab point
//        _resetPosition = _trans.localPosition;
//    }


//    // Called when pulling bowstring
//    public void FollowOnRail()
//    {

//        _trans.position = targetTransform.position;
//        // Makd grab point local coordinate move only on z-axis
//        // bound local z position rainMin, railMax 사이에 있도록 함.
//        // Mathf.Clamp: bound result between min and max.
//        _trans.localPosition = new Vector3(0, 0, Mathf.Clamp(_trans.localPosition.z, railMin, railMax));
//    }

//    // Called when grab ended
//    public void ResetPosition()
//    {
//        _trans.localPosition = _resetPosition;
//    }
//}

using UnityEngine;


/// <summary>
/// snaps our transform to the target trans, position but restricts position to be 0,0 x,y and between min and max on z when FireOnRail is fired.
/// Is reset to init pos when ResetPosition is fired.
/// Script was made to keep a bowsting only moving in one axis between 2 positions. Could be used to make slider.
/// </summary>
public class FollowTransformOnRail : MonoBehaviour
{

    public Transform targetTransform;

    public float railMin = -0.7f;
    public float railMax = 0;

    Transform _trans;
    Vector3 _resetPosition;


    void Start()
    {
        _trans = transform;
        _resetPosition = _trans.localPosition;
    }


    public void FollowOnRail()
    {
        _trans.position = targetTransform.position;
        _trans.localPosition = new Vector3(0, 0, Mathf.Clamp(_trans.localPosition.z, railMin, railMax));
    }

    public void ResetPosition()
    {
        _trans.localPosition = _resetPosition;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Instantiates Prefab and launches in our forward direction using rigbody force
/// </summary>
public class PrefabLauncher2 : MonoBehaviour
{
    public GameObject prefab;
    public float forceMultiplier = 500f;

    Rigidbody _bodyToLaunch1;
    Rigidbody _bodyToLaunch2;
    public Transform _trans1;
    public Transform _trans2;

    private void Start()
    {
        // _trans = transform; // GrabPoint
    }

    // called when started grab event
    public void InstantiatePrefab()
    {
        // arrow1
        GameObject g1 = Instantiate(prefab, _trans1.position, _trans1.rotation, _trans1);
        _bodyToLaunch1 = g1.GetComponent<Rigidbody>();
        if (_bodyToLaunch1 == null)
        {
            Debug.Log("prefab has no rigbod so well add one");
            _bodyToLaunch1 = g1.AddComponent<Rigidbody>();
        }
        // arrow2
        GameObject g2 = Instantiate(prefab, _trans2.position, _trans2.rotation, _trans2);
        _bodyToLaunch2 = g2.GetComponent<Rigidbody>();
        if (_bodyToLaunch2 == null)
        {
            Debug.Log("prefab has no rigbod so well add one");
            _bodyToLaunch2 = g2.AddComponent<Rigidbody>();
        }
    }

    // release arrow
    public void LaunchPrefab(float forceAmount)
    {
        _bodyToLaunch1.isKinematic = false;
        _bodyToLaunch1.transform.parent = null;
        Vector3 force1 = _trans1.forward * (forceAmount * forceMultiplier);
        _bodyToLaunch1.AddForce(force1);

        _bodyToLaunch2.isKinematic = false;
        _bodyToLaunch2.transform.parent = null;
        Vector3 force2 = _trans2.forward * (forceAmount * forceMultiplier);
        _bodyToLaunch2.AddForce(force2);
    }
}

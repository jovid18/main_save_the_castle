using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Instantiates Prefab and launches in our forward direction using rigbody force
/// </summary>
public class PrefabLauncher : MonoBehaviour
{
    public GameObject prefab;
    public float forceMultiplier = 500f;

    Rigidbody _bodyToLaunch;
    Transform _trans;

    private void Start()
    {
        _trans = transform;
    }

    // called when started grab event
    public void InstantiatePrefab()
    {
        // arrow
        GameObject g = Instantiate(prefab, _trans.position, _trans.rotation, _trans);
        _bodyToLaunch = g.GetComponent<Rigidbody>();
        if(_bodyToLaunch == null)
        {
            Debug.Log("prefab has no rigbod so well add one");
            _bodyToLaunch = g.AddComponent<Rigidbody>();
        }
    }

    // release arrow
    public void LaunchPrefab(float forceAmount)
    {
        _bodyToLaunch.isKinematic = false;
        _bodyToLaunch.transform.parent = null;
        Vector3 force = _trans.forward * (forceAmount * forceMultiplier);
        _bodyToLaunch.AddForce(force);
    }
}

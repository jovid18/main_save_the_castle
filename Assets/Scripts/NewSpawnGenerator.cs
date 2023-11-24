using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnGenerator : MonoBehaviour
{
    public GameObject[] prefabs;
    private List<GameObject> spawnedGameObjects = new List<GameObject>();

    public BoxCollider area1;
    public BoxCollider area2;
    private BoxCollider area;

    public int count;

    public Transform targetDestination;

    void Start()
    {
        for (int i = 0; i < count; ++i) { Spawn(); }

        area1.enabled = false;
        area2.enabled = false;
    }

    private void Spawn()
    {
        int selection = Random.Range(0, prefabs.Length);
        GameObject selectedPrefab = prefabs[selection];
        Vector3 spawnPos = GetRandomPosition();

        GameObject instance = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);
        spawnedGameObjects.Add(instance);

        // NavMeshAgent를 찾아서 설정
        NavMeshAgent navMeshAgent = instance.GetComponent<NavMeshAgent>();
        if (navMeshAgent != null)
        {
            // 이동할 목적지 설정
            Vector3 destination = GetRandomPosition();
            navMeshAgent.SetDestination(destination);
        }
        else
        {
            Debug.LogWarning("NavMeshAgent not found on the instantiated object.");
        }

        MoveToDestination(navMeshAgent);

    }

    private Vector3 GetRandomPosition()
    {
        Vector3 basePosition = transform.position;
        int select = Random.Range(0, 2);
        if (select == 0) { area = area1; }
        else { area = area2; }

        Vector3 size = area.bounds.size;

        float posX = basePosition.x + Random.Range(-size.x / 2f, size.x / 2f);
        float posY = basePosition.y + Random.Range(-size.y / 2f, size.y / 2f);
        float posZ = basePosition.z + Random.Range(-size.z / 2f, size.z / 2f);

        Vector3 spawnPos = new Vector3(posX, posY, posZ);

        return spawnPos;
    }

    private void MoveToDestination(NavMeshAgent navMeshAgent)
    {
        navMeshAgent.SetDestination(targetDestination.position);
    }
}
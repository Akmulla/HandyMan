using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour, IInteractable
{
    [SerializeField] Pool[] trashPools;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float spawnDuration;
    [SerializeField] float spawnDelay;
    [SerializeField] Vector2 startImpulseDirection;
    [SerializeField] float startImpulsePower;
    bool spawning;

    void Start()
    {
        spawning = false;
    }

    IEnumerator SpawnCor()
    {
        transform.localScale = new Vector3(-1, 1, 1);
        spawning = true;
        float startTime = Time.time;
        while (Time.time - startTime < spawnDuration)
        {
            Spawn();
            yield return new WaitForSeconds(spawnDelay);
        }
        spawning = false;
        transform.localScale = new Vector3(1, 1, 1);
    }

    void Spawn()
    {
        Pool pool = trashPools[Random.Range(0, trashPools.Length)];
        GameObject obj = pool.Activate(spawnPoint.position, spawnPoint.rotation);
        obj.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        obj.GetComponent<Rigidbody2D>().AddForce(startImpulseDirection.normalized * startImpulsePower, ForceMode2D.Impulse);
    }

    public void Interact()
    {
        if (spawning)
            return;

        StartCoroutine(SpawnCor());
    }
}

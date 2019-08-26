using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour, IInteractable
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] float spawnDuration;
    [SerializeField] float spawnDelay;
    [SerializeField] Vector2 startImpulseDirection;
    [SerializeField] float startImpulsePower;
    [SerializeField] SpriteRenderer spriteRend;
    //Pool[] foodPools;
    bool spawning;

    void Start()
    {
        spawning = false;
    }

    IEnumerator SpawnCor()
    {
        // transform.localScale = new Vector3(-1, 1, 1);
        spriteRend.flipX = true;
        spawning = true;
        float startTime = Time.time;
        while (Time.time - startTime < spawnDuration)
        {
            Spawn();
            yield return new WaitForSeconds(spawnDelay);
        }
        spawning = false;
        spriteRend.flipX = false;
        //transform.localScale = new Vector3(1, 1, 1);
    }

    void Spawn()
    {
        Pool pool = Toolbox.Instance.poolManager.foodPools[Random.Range(0, Toolbox.Instance.poolManager.foodPools.Length)];
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

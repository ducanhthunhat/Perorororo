using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSpawn : MonoBehaviour
{
    bool spawned = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (spawned) return;
        if (!collision.CompareTag("Player")) return;

        spawned = true;

        for (int i = 0; i < 2; i++)
        {
            Vector3 offset = new Vector3(i * 0.5f, 0, 0);
            GameManager.Instance.objectPool.GetBat(transform.position + offset, Quaternion.identity, null);
        }
    }


}

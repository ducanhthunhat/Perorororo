using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    private Transform player;
    public float speed = 3f;

    void Start()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p != null)
            player = p.transform;
    }

    void Update()
    {
        if (player == null) return;

        Vector3 dir = (player.position - transform.position).normalized;
        transform.position += dir * speed * Time.deltaTime;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Grounded"))
        {
            Debug.Log("Bat returned to pool");
            GameManager.Instance.objectPool.ReturnBat(this.gameObject);
        }
        else if (collision.CompareTag("Player"))
        {
            Debug.Log("Bat returned to pool after hitting player");
        }
        if (collision.CompareTag("Player"))
        {
            UIManager.Instance.OpenUI<UIGameOver>();
            UIManager.Instance.PauseGame();
            Debug.Log("Game Over triggered by Trap");
        }
    }
}

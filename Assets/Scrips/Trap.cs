using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UIManager.Instance.OpenUI<UIGameOver>();
            UIManager.Instance.PauseGame();
            Debug.Log("Game Over triggered by Trap");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLevel : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UIManager.Instance.OpenUI<UINextLevel>();
            UIManager.Instance.PauseGame();
            Debug.Log("Level Completed!");
        }
    }
}

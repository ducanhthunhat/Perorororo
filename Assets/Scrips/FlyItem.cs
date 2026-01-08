using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FlyItem : MonoBehaviour
{
    public static Action Can_fly;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FlyItem.Can_fly?.Invoke();
            gameObject.SetActive(false);
        }
    }

}

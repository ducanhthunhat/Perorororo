using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameOver : UICanvas
{
    public void PlayAgain()
    {
        Bat[] allBats = FindObjectsOfType<Bat>();

        foreach (var bat in allBats)
        {
            if (bat != null && bat.gameObject.activeSelf)
            {
                GameManager.Instance.objectPool.ReturnBat(bat.gameObject);
            }
        }

        UIManager.Instance.CloseUIDirectly<UIGameOver>();
        UIManager.Instance.ResumeGame();
        GameManager.Instance.RestartLevel();
    }
}
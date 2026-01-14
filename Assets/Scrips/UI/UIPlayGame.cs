using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameplay : UICanvas
{
    // Start is called before the first frame update
    public void GamePlay()
    {
        UIManager.Instance.ResumeGame();
        UIManager.Instance.CloseUIDirectly<UIGameplay>();
        GameManager.Instance.LoadLevel(GameManager.Instance.currentLevelIndex);

    }
}

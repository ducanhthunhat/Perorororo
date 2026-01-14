using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Level System")]
    public LevelDatabase levelDatabase; //file LevelDatabase vào đây
    public Transform levelParent;       //Kéo object cha để chứa Level cho gọn

    [Header("References")]
    public ObjectPool objectPool;

    public GameObject currentLevelInstance;
    public int currentLevelIndex = 0;

    void Awake()
    {
        // Singleton chuẩn
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // 1. Mở UI Gameplay
        UIManager.Instance.OpenUI<UIGameplay>();

        // 2. Load Level đầu tiên (Index 0) ngay khi vào game

        UIManager.Instance.PauseGame();
    }

    // --- LOGIC LOAD LEVEL PREFAB ---

    public void LoadLevel(int index)
    {
        // Kiểm tra an toàn
        if (levelDatabase == null)
        {
            Debug.LogError("Chưa gán LevelDatabase vào GameManager!");
            return;
        }

        if (index < 0 || index >= levelDatabase.GetLevelCount())
        {
            Debug.Log("Không tìm thấy level hoặc đã hết level!");
            return;
        }

        // 1. Dọn dẹp level cũ (nếu có)
        if (currentLevelInstance != null)
        {
            Destroy(currentLevelInstance);
        }

        // 2. Sinh ra level mới
        GameObject prefab = levelDatabase.GetLevelPrefab(index);
        if (prefab != null)
        {
            currentLevelInstance = Instantiate(prefab, levelParent);
            currentLevelIndex = index;
        }
    }

    public void NextLevel()
    {
        LoadLevel(currentLevelIndex + 1);
    }

    public void RestartLevel()
    {
        LoadLevel(currentLevelIndex);
    }

    // Hàm này để LevelData gọi khi thắng
    public void OnLevelWin()
    {
        Debug.Log("Victory!");
        // UIManager.Instance.OpenUI<UIWin>();
        // NextLevel();
    }
}
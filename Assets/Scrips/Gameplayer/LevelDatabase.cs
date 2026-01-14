using UnityEngine;

[CreateAssetMenu(fileName = "LevelDatabase", menuName = "GameData/Level Database")]
public class LevelDatabase : ScriptableObject
{
    // Kéo thả các Prefab Level vào đây
    [SerializeField] private GameObject[] levelPrefabs;

    public int GetLevelCount()
    {
        return levelPrefabs != null ? levelPrefabs.Length : 0;
    }

    public GameObject GetLevelPrefab(int index)
    {
        // Kiểm tra an toàn để tránh lỗi Array Out of Range
        if (index >= 0 && index < levelPrefabs.Length)
        {
            return levelPrefabs[index];
        }

        Debug.LogError($"Level {index} không tồn tại trong Database!");
        return null;
    }
}
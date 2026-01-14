using UnityEngine;

public class LevelData : MonoBehaviour
{
    // Singleton cục bộ: Chỉ sống trong level này.
    // Giúp các object con (như Cửa về đích) dễ dàng tìm thấy nó.
    public static LevelData Current { get; private set; }

    private void Awake()
    {
        Current = this;
    }

    private void OnDestroy()
    {
        if (Current == this)
        {
            Current = null;
        }
    }

    // Hàm này để các object kích hoạt chiến thắng (VD: Chạm vào Cờ, Mở rương...) gọi vào
    public void Win()
    {
        Debug.Log("Level Complete!");

        // Gọi thẳng sang GameManager để chuyển màn
        // (Giả sử GameManager có hàm NextLevel như code trước Tèo đưa)
        GameManager.Instance.NextLevel();
    }
}
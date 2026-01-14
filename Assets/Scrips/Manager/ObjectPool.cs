using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ObjectPool", menuName = "Manager/ObjectPool", order = 1)]
public class ObjectPool : ScriptableObject
{
    public Bat batPrefab;
    public Bat GetBat(Vector3 position, Quaternion rotation, Transform parent)
    {
        return FastPoolManager
        .GetPool(batPrefab.gameObject)
        .FastInstantiate<Bat>(position, rotation, parent);
    }
    public void ReturnBat(GameObject bat)
    {
        FastPoolManager.GetPool(batPrefab.gameObject).FastDestroy(bat);
    }
}

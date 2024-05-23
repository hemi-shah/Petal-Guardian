using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class Item: MonoBehaviour
{
    [FormerlySerializedAs("name")] public string Name;
    [FormerlySerializedAs("description")] public string Description;
    [FormerlySerializedAs("price")] public float Price;
    [FormerlySerializedAs("icon")] public Sprite Icon;
}
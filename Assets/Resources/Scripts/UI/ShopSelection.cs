using UnityEngine;

public static class ShopSelection
{
    private static GameObject selectedPrefab = null;

    public static void SetSelectedItem(GameObject prefab)
    {
        selectedPrefab = prefab;
    }

    public static GameObject GetSelectedPrefab()
    {
        return selectedPrefab;
    }

    public static void ClearSelectedPrefab()
    {
        selectedPrefab = null;
    }

    public static bool PrefabHasPlaced()
    {
        return selectedPrefab == null;
    }
}
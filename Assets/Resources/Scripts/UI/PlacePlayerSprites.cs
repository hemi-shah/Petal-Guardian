using System;
using UnityEngine;

public class PlacePlayerSprites : MonoBehaviour
{
    private bool isOccupied = false;
    private Sounds sounds;

    private void Awake()
    {
        sounds = GameObject.FindGameObjectWithTag("Sounds").GetComponent<Sounds>();
    }

    // Handle mouse click event
    public void OnMouseDown()
    {
        // Check if the slot is already occupied
        if (!isOccupied)
        {
            // Get the selected prefab from ShopSelection
            var selectedPrefab = ShopSelection.GetSelectedPrefab();

            // Place the prefab if a prefab is selected
            if (selectedPrefab != null)
            {
                // Instantiate the selected prefab at the position of this object
                var newObject = Instantiate(selectedPrefab, transform.position, Quaternion.identity);

                // Parent the new object to this slot (optional)
                newObject.transform.SetParent(transform);

                // Mark the slot as occupied
                isOccupied = true;

                // Reset the selected prefab in ShopSelection to null
                ShopSelection.ClearSelectedPrefab();

                //play the placing sound
                sounds.PlayPlacingSound();
            }
        }
        else
        {
            if (gameObject.transform.childCount == 0)
            {
                isOccupied = false;
                OnMouseDown();
            }
        }
    }
}


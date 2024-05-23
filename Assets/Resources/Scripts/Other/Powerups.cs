using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    public void ApplyFertilizer()
    {
        var plantList = GameObject.FindGameObjectsWithTag("Plant").ToList();
        var flowerList = GameObject.FindGameObjectsWithTag("Flower").ToList();
        var mushroomList = GameObject.FindGameObjectsWithTag("Mushroom").ToList();
        foreach (var plant in plantList)
        {
            plant.GetComponent<Plant>().HealToMax();
        }
        foreach (var flower in flowerList)
        {
            flower.GetComponent<Flower>().HealToMax();
        }
        foreach (var mushroom in mushroomList)
        {
            mushroom.GetComponent<Mushroom>().HealToMax();
        }
    }
}

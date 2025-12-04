using System.Collections.Generic;
using UnityEngine;

public class CalculatingChanceSeparation : MonoBehaviour
{
    public int GetAmount()
    {
        int minRange = 2;
        int maxRange = 6;

        int percent = 100;
        int numberReduce = 2;
        int changedPercent = percent;

        int amountCubes = Random.Range(minRange, maxRange + 1);
        int currentCubes = 0; 

        for (int i = 0; i < amountCubes; i++)
        {
            int currentPercent = Random.Range(0, percent + 1);

            if (currentPercent <= changedPercent)
                currentCubes++;
            else              
                break;

            changedPercent /= numberReduce;
        }

        Debug.Log($"Count: {currentCubes}");

        return currentCubes;
    }
}

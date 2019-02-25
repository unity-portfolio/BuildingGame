using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "City Object", menuName = "Objects/City", order = 1)]
public class City_SO : ScriptableObject
{
#if UNITY_EDITOR
    [TextArea(3, 20)]
    [SerializeField] private string developerDescription = "This objects will help control the economy of the city";
#endif
    public int cash;
    public int day;
    public int jobsCurrent;
    public int jobsCeiling;
    public float populationCurrent;
    public float populationCeiling;
    public float food;

    public int[] buildingCounts = new int[3];

    public void AddDay()
    {
        day++;
        CalculateCash();
        CalculatePopulation();
        CalculateJobs();
        CalculateFood();
        UpdateCityData();
    }

    private void CalculateJobs()
    {
        jobsCeiling = buildingCounts[2] * 10;
        jobsCurrent = Mathf.Min((int)populationCurrent, jobsCeiling);
    }

    private void CalculateCash()
    {
        cash += jobsCurrent * 2;
    }

    private void CalculateFood()
    {
        food += buildingCounts[1] * 4f;
    }

    private void CalculatePopulation()
    {
        populationCeiling = buildingCounts[0] * 5;
        if(food >= populationCurrent && populationCurrent < populationCeiling)
        {
            food -= populationCurrent * .25f;
            populationCurrent = Mathf.Min(populationCurrent += food * .25f, populationCeiling);
        }
        else if(food < populationCurrent)
        {
            populationCurrent -= (populationCurrent - food) * .5f;
        }
    }

    public string UpdateCityData()
    {
         return string.Format("Jobs: {0}/{1}\n$Cash: {2}(+{6})\nPopulation: {3}/{4}\nFood: {5}", jobsCurrent, jobsCeiling, cash, (int)populationCurrent, (int)populationCeiling, (int)food, jobsCurrent*2);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class City : MonoBehaviour
{
    [SerializeField] private City_SO _cityData;
    [SerializeField] private TextMeshProUGUI _cityText;
    [SerializeField] private TextMeshProUGUI _dayText;



    public void EndTurn()
    {
        _cityData.AddDay();
        UpdateCityData();
        UpdateDayText();
    }

    private void UpdateCityData()
    {
        _cityText.text = _cityData.UpdateCityData();
    }

    private void UpdateDayText()
    {
        _dayText.text = string.Format("Day: {0}", _cityData.day);
    }
}

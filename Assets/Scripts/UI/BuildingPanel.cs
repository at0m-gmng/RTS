using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine;

public class BuildingPanel : MonoBehaviour
{
    [SerializeField] private BuildingData _buildingDatas;   
    [SerializeField] private BuildContentFactory _buildContentFactory;
    

    private void Awake()
    {
        // _buildingDatas = Resources.LoadAll<BuildingData.Building>("Setup/").ToList();
        // Debug.Log(_buildingDatas.BuildingDatas.Count);
        foreach (var buildingData in _buildingDatas.BuildingDatas)
        {
            Button button = Instantiate(buildingData.BuildPrefab, transform);
            button.GetComponent<Image>().sprite = buildingData.Icon;
            button.GetComponentInChildren<TextMeshProUGUI>().text = buildingData.Name + " " + buildingData.Price;
            button.AddEventListener(buildingData.Type, OnClick);
        
            // button.GetComponent<BuildContent>().Type = buildingData.Type;
            // OnClick.Invoke(buildingData.Type);
            // button.AddComponent<BuildContentType>().Tavern;
        } 
        
    }

    public void OnClick(BuildContentType type)
    {
        if (FindObjectOfType<PlaceLogic>())
        {
            if (!FindObjectOfType<PlaceLogic>().IsBuilding)
            {
                _buildContentFactory.Get(type);
            }
        }
        else
        {
            _buildContentFactory.Get(type);
        }
    }
}

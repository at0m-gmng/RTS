using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class BuildingData : ScriptableObject
{
    [System.Serializable]
    public class Building
    {
        [SerializeField] private Button _buildPrefab;
        [SerializeField] private string _name;
        [SerializeField] private Sprite _icon;
        [SerializeField] private float _price;
        [SerializeField] private BuildContentType _type;

        public Button BuildPrefab => this._buildPrefab;
        public string Name => this._name;
        public Sprite Icon => this._icon;
        public float Price => this._price; 
        public BuildContentType Type => this._type; 
    }

    public List<Building> BuildingDatas = new List<Building>();
}

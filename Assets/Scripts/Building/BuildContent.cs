using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum BuildContentType
{
    Tavern,
    UnitSpawn
}
public class BuildContent : MonoBehaviour
{
    [SerializeField] private BuildContentType _type;
    
    public BuildContentType Type => _type;
    public BuildContentFactory OriginFactory { get; set; } //ссылка на фабрику

    public void Recycle() // возвращает себя за ненадобностью
    {
        OriginFactory.Reclaim(this);
    }
}

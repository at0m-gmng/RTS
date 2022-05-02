using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BuildContentFactory : GameObjectFactory
{
    [SerializeField] private BuildContent _buildTavernPref; // объекты типо контента
    [SerializeField] private BuildContent _buildUnitSpawnPref; // объекты типо контента
    
    public void Reclaim(BuildContent content) // передаётся контент, который уже не нужен
    {
        Destroy(content.gameObject);
    }

    public BuildContent Get(BuildContentType type) // вызываем Get с нужным префабом по типу
    {
        switch (type)
        {   
            case BuildContentType.Tavern :
                return Get(_buildTavernPref);
            case BuildContentType.UnitSpawn :
                return Get(_buildUnitSpawnPref);
        }

        return null;
    }

    private BuildContent Get(BuildContent prefab) // принимает префаб и создаёт объект контента
    {
        BuildContent instance = CreateGameObjectInstance(prefab);
        instance.OriginFactory = this;
        return instance; // возвращаем объект контента
    }

}

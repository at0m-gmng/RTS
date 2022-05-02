using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private BuildContentFactory _buildContentFactory;

    public void CreadeBuild(BuildContentType type)
    {
        _buildContentFactory.Get(type);
    }
}

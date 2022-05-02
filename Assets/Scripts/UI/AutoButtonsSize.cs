using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoButtonsSize : MonoBehaviour
{
    private GridLayoutGroup _gridLayoutGroup;
    private void Awake()
    {
        _gridLayoutGroup = GetComponent<GridLayoutGroup>();
        
        // ButtonsSize();
    }

    private void Update()
    {
        // ButtonsSize();
    }

    private void ButtonsSize()
    {
        _gridLayoutGroup.cellSize =
            new Vector2(gameObject.GetComponent<RectTransform>().rect.width/10, gameObject.GetComponent<RectTransform>().rect.height);
    }
}

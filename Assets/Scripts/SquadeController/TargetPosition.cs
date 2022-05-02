using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TargetPosition : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    public Ray TouchRay => _mainCamera.ScreenPointToRay(Input.mousePosition); // конвертируем позицию мыши в луч


    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            TargetPos(TouchRay);
    }

    public void TargetPos(Ray ray) // проверяем, что пользователь нажал на клетку
    {
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) // проверяем, попал ли луч во что-то
        {
            // Debug.Log(hit.transform.gameObject.name);
            if (FindObjectOfType<PlaceLogic>())
            {
                if (!FindObjectOfType<PlaceLogic>().IsBuilding)
                {
                    transform.position = hit.point;
                }
            }
            else
            {
                transform.position = hit.point;
            }
            // Debug.Log(hit.point);
        }
    }
}

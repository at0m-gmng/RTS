using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlaceLogic : MonoBehaviour
{
    [SerializeField] private GameObject _placementPos;
    private RaycastHit _hit;
    private PlacementMaterial _placement ;
    
    public bool IsBuilding { get; private set; }
    public Ray TouchRay => Camera.main.ScreenPointToRay(Input.mousePosition); // конвертируем позицию мыши в луч

    private void Start()
    {
        IsBuilding = true;
        _placement = _placementPos.GetComponent<PlacementMaterial>();
        MoveToMousePosition();
    }

    private void Update()
    {
        MoveToMousePosition();
        
        // if (Input.GetMouseButtonDown(0)) // строительство множеств объектов
        // {
        //     if (!EventSystem.current.IsPointerOverGameObject())
        //     {
        //         Instantiate(this, transform.position, transform.rotation);
        //         Destroy(this);
        //     }
        // }
        // Debug.Log(!_placement.IsCollided);
        if (Input.GetMouseButtonDown(0) && !_placement.IsCollided && !EventSystem.current.IsPointerOverGameObject())
        {

            IsBuilding = false;
            _placementPos.GetComponent<MeshRenderer>().material.color = Color.clear;
            Destroy(_placementPos.GetComponent<PlacementMaterial>());
            Destroy(this);
        }
    }


    private void MoveToMousePosition()
    {
        if (Physics.Raycast(TouchRay, out _hit))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                transform.position = new Vector3(_hit.point.x, this.transform.position.y, _hit.point.z);
            }
        }
    }

}

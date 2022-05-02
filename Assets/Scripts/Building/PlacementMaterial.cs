using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementMaterial : MonoBehaviour
{
    public Material[] _placementMaterial;
    public bool IsCollided { get; private set ; }

    private void Start()
    {
        IsCollided = false;
    }

    public void OnCollisionStay(Collision collision)
    {
        // Debug.Log(collision.gameObject.name);
        if (collision.gameObject.layer == 10 )
        {
            GetComponent<MeshRenderer>().material = _placementMaterial[1];
            IsCollided = false;
        }
        else
        {
            GetComponent<MeshRenderer>().material = _placementMaterial[0];
            IsCollided = true;
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        // Debug.Log(collision.gameObject.name);
        GetComponent<MeshRenderer>().material = _placementMaterial[1];
        IsCollided = false;
    }
}

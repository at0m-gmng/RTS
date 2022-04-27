using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISquadePositionGenerator
{
    Vector3[] GetPosition(int count);
}

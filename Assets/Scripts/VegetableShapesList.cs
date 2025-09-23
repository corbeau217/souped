using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VegetableShapesList", menuName = "Vegetables/VegetableShapesList", order = 1)]
public class VegetableShapesList : ScriptableObject
{
    public List<GameObject> vegetableShapes;
}

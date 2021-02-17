using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Meal Order", menuName ="mealOrder")]
public class MealOrder : ScriptableObject
{
    public string[] types;
    public Vector2[] numDenom;
}

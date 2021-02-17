using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MovingPizzaTasks", menuName = "movingPizzaTasks")]
public class MovingPizzaTasks : ScriptableObject
{
    public Vector2[] tasks;
    public Vector2[] solutions;
}

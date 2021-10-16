using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Stage", menuName = "ScriptableObjects/Stage", order = 1)]
public class Stage : ScriptableObject
{
    public string name;
    public int sceneBuildIndex;
    public int numberOfRequirements;
}
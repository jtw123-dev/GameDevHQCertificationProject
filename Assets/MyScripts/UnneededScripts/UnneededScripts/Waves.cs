using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "spawn.asset", menuName = "SpawnWaves", order = 1)]
public class Waves :ScriptableObject
{
    public List<GameObject> sequence;
   
}

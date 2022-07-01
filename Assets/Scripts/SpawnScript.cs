using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn
{
    GameObject attackType { get; set; }
    float time { get; set; }
}


public class SpawnScript : MonoBehaviour
{
    EnemySpawn ene = new EnemySpawn();
}

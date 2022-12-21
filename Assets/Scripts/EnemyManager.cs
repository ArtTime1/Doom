using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Enemy> EnemiesInTrigger = new List<Enemy>();
    void Start()
    {
        
    }

  
    void Update()
    {
        
    }

    public void AddEnemy(Enemy enemy)
    {
        EnemiesInTrigger.Add(enemy);
    }

    public void RemoveEnemy(Enemy enemy)
    {
        EnemiesInTrigger.Remove(enemy);
    }
}

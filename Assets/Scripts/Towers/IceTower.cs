using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameConstants;

public class IceTower : BaseTower
{
  private BaseEnemy target;

  public IceTower()
    : base(TowerDamageType.Piercing, TowerType.IceTower, TowerHitSpeed.Medium, TowerHitRange.Medium)
  {

  }

  public override void Attack()
  {
    if (CanAttack())
    {
      // One Attack Performed on Target
    }
  }

  public override bool CanAttack()
  {
    bool isInRange = false;

    // Check if a target is already locked and also check if it's still in range to continue attacking it
    if (target != null && InRange(target))
    {
      isInRange = true;
      // Perform Attack
      target.TakeDamage(TowerType);
    }
    else
    {
      List<BaseEnemy> enemyList = Utils.GetAllEnemies();
      foreach (BaseEnemy enemy in enemyList)
      {
        if (enemy.gameObject.activeInHierarchy && InRange(enemy))
        {
          target = enemy;
          isInRange = true;
          // Perform Attack
          target.TakeDamage(TowerType);
          break;
        }
      }
    }

    return isInRange;
  }

  public override bool InRange(BaseEnemy enemy)
  {
    bool isInRange = false;
    float distanceBetweenEnemyAndTower = Vector3.Distance(enemy.transform.position, transform.position);
    if (distanceBetweenEnemyAndTower <= (float)TowerHitRange)
    {
      isInRange = true;
    }

    return isInRange;
  }
}

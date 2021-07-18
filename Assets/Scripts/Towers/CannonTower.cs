using Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameConstants;

public class CannonTower : BaseTower
{
  private BaseEnemy primaryTarget;

  public CannonTower()
    : base(TowerDamageType.Splash, TowerType.Cannon, TowerHitSpeed.Medium, TowerHitRange.Low)
  {
  }

  public override void Attack()
  {
    if (CanAttack())
    {
      // Splash attack Performed on Targets
    }
  }

  public override bool CanAttack()
  {
    bool isInRange = false;

    // Check if a target is already locked and also check if it's still in range to continue attacking it
    if (primaryTarget != null && InRange(primaryTarget))
    {
      isInRange = true;
      // Perform splash Attack
      SplashDamage();
    }
    else
    {
      List<BaseEnemy> enemyList = Utils.GetAllEnemies();
      foreach (BaseEnemy enemy in enemyList)
      {
        if (enemy.gameObject.activeInHierarchy && InRange(enemy))
        {
          primaryTarget = enemy;
          isInRange = true;
          // Perform splash Attack
          SplashDamage();
          break;
        }
      }
    }

    return isInRange;
  }

  private void SplashDamage()
  {
    primaryTarget.TakeDamage(TowerType);
    List<BaseEnemy> enemyList = Utils.GetAllEnemies();
    foreach (BaseEnemy enemy in enemyList)
    {
      if (enemy.gameObject.activeInHierarchy && (Vector3.Distance(primaryTarget.transform.position, enemy.transform.position) < 0.5f))
      {
        enemy.TakeDamage(TowerType);
      }
    }
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

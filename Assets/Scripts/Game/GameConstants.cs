using UnityEngine;

[CreateAssetMenu(fileName = "GameConstants", menuName = "ScriptableObjects/Game Constants", order = 1)]
public class GameConstants : ScriptableObject
{
  public float distanceBetweenObstacles = 5f;
  public float distanceOfForwardJump = 7f;

  public enum TowerType
  {
    Cannon = 1,
    ArcherTower = 2,
    IceTower = 3
  }
  
  public enum TowerDamageType
  {
    Piercing = 1,
    Splash = 2
  }
  
  public enum TowerHitSpeed
  {
    Slow = 1,
    Medium = 2,
    Fast = 3
  }
  
  public enum TowerHitRange
  {
    Low = 1,
    Medium = 2,
    High = 3
  }
}

using UnityEngine;
using static GameConstants;

public class BaseEnemy : MonoBehaviour
{
  [SerializeField] private int m_health;
  [SerializeField] private int m_speed;

  public BaseEnemy(int health, int speed)
  {
    m_health = health;
    m_speed = speed;
  }

  public int Health { get => m_health;}
  
  public int Speed { get => m_speed;}

  public void TakeDamage(TowerType towerType)
  {
    //TODO: Add Damage indication
    m_health -= (int)(towerType);
  }
}

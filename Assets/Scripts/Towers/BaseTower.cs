using UnityEngine;
using static GameConstants;

public abstract class BaseTower : MonoBehaviour
{
  [SerializeField] private TowerDamageType m_towerDamageType;
  [SerializeField] private TowerType m_towerType;
  [SerializeField] private TowerHitSpeed m_towerHitSpeed;
  [SerializeField] private TowerHitRange m_towerHitRange;

  public BaseTower(TowerDamageType towerDamageType, TowerType towerType, TowerHitSpeed towerHitSpeed, TowerHitRange towerHitRange)
  {
    m_towerDamageType = towerDamageType;
    m_towerType = towerType;
    m_towerHitSpeed = towerHitSpeed;
    m_towerHitRange = towerHitRange;
  }

  public TowerDamageType TowerDamageType { get => m_towerDamageType;}
  public TowerType TowerType { get => m_towerType;}
  public TowerHitSpeed TowerHitSpeed { get => m_towerHitSpeed;}
  public TowerHitRange TowerHitRange { get => m_towerHitRange;}

  public abstract void Attack();
  public abstract bool CanAttack();
  public abstract bool InRange(BaseEnemy gameObject);

  private void Update()
  {
    Attack();    
  }
}

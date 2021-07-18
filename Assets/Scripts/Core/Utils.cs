using UnityEngine;
using DevGameRoshan;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
  public static class Utils
  {
    public static void EventAsync(GameEvent gameEvent)
    {
      EventManager.Instance.TriggerEvent(gameEvent);
    }
    public static void EventSync(GameEvent gameEvent)
    {
      EventManager.Instance.QueueEvent(gameEvent);
    }


    public static List<BaseEnemy> GetAllEnemies()
    {
      return GameObject.FindGameObjectsWithTag("Enemy").Select(obj => obj.GetComponent<BaseEnemy>()).ToList();
    }
  }
}

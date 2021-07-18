using DevGameRoshan;
using UnityEngine;

namespace Events
{
  public class ObjectToPlaceSelectedEvent : GameEvent
  {
    private GameObject objectToPlace;

    public ObjectToPlaceSelectedEvent(GameObject objectToPlace)
    {
      this.objectToPlace = objectToPlace;
    }

    internal GameObject getCurrentObjectToPlace()
    {
      return objectToPlace;
    }
  }
}
using DevGameRoshan;

namespace Events
{
  public class TogglePlaneDetectionEvent : GameEvent
  {
    private bool toogleState;

    public TogglePlaneDetectionEvent(bool toogleState)
    {
      this.toogleState = toogleState;
    }

    internal bool getCurrentBool()
    {
      return toogleState;
    }
  }
}
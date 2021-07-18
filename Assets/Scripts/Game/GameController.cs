using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
  #region Variables
  private GameManager gameManager;

  [Header("Main References")]
  //The Main Obstacle
  public Transform Enemies_Root;
  public List<GameObject> waves;
  public int currentWave;
  public int poolCount;

  //Visible obstacles in View
  public int visibleObstacles;

  //Game Constants
  public GameConstants gameConstants;

  //Generation Point
  public Transform generationPoint;

  #endregion

  private void Awake()
  {
    gameManager = new GameManager();
  }

  // Start is called before the first frame update
  void Start()
  {
    gameManager.InitGame(
      waves,
      Enemies_Root,
      poolCount,
      visibleObstacles,
      gameConstants.distanceBetweenObstacles,
      this.transform,
      generationPoint);
  }

  // Update is called once per frame
  void Update()
  {

  }
}

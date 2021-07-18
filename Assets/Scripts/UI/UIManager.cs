using Core;
using Events;
using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
  [Header("Buttons")]
  [SerializeField] private Button m_ArcherTowerButton;
  [SerializeField] private Button m_CannonTowerButton;
  [SerializeField] private Button m_IceTowerButton;

  [SerializeField] private Button m_quitButton;
  [SerializeField] private Button m_clearButton;

  //TODO:
  [SerializeField] private Button m_startButton;
  [SerializeField] private Button m_setStartLocationButton;
  [SerializeField] private Button m_setDestinationLocationButton;

  [Header("Toggles")]
  [SerializeField] private Toggle m_planeDetectionToggle;

  [Header("Tower Objects")]  
  [SerializeField] private GameObject m_ArcherTower;
  [SerializeField] private GameObject m_CannonTower;
  [SerializeField] private GameObject m_IceTower;

  // Start is called before the first frame update
  void Start()
  {
    m_ArcherTowerButton.onClick.AddListener(PlaceArcherTower);
    m_CannonTowerButton.onClick.AddListener(PlaceCannonTower);
    m_CannonTowerButton.onClick.AddListener(PlaceIceTower);

    m_planeDetectionToggle.onValueChanged.AddListener(TooglePlaneDetection);

    m_quitButton.onClick.AddListener(QuitGame);
    m_clearButton.onClick.AddListener(ClearGame);

    m_startButton.onClick.AddListener(StartGame);
    m_setStartLocationButton.onClick.AddListener(SetStartLocation);
    m_setDestinationLocationButton.onClick.AddListener(SetDestinationLocation);
  }

  private void SetDestinationLocation()
  {
    // TODO: Add a listener wherever you've to set destination location (Check wave, enemy speed and  calc if desti is far enough)
    Utils.EventAsync(new SetDestinationLocationEvent());
  }

  private void SetStartLocation()
  {
    // TODO: Add a listener wherever you've to Set start Location
    Utils.EventAsync(new SetStartLocationEvent());
  }

  private void StartGame()
  {
    // TODO: Add a listener wherever you've to Start the game
    Utils.EventAsync(new StartGameEvent());
  }

  private void ClearGame()
  {
    // TODO: Add a listener wherever you've to clear all placements
    Utils.EventAsync(new ClearAllPlacementsEvent());
  }

  private void TooglePlaneDetection(bool toogleState)
  {
    // TODO: Add a listener wherever you've to toggle plane detection
    Utils.EventAsync(new TogglePlaneDetectionEvent(toogleState)); 
  }

  private void QuitGame()
  {
    Application.Quit();
  }

  private void PlaceArcherTower()
  {
    Utils.EventAsync(new ObjectToPlaceSelectedEvent(m_ArcherTower));
  }

  private void PlaceCannonTower()
  {
    Utils.EventAsync(new ObjectToPlaceSelectedEvent(m_CannonTower));
  }

  private void PlaceIceTower()
  {
    Utils.EventAsync(new ObjectToPlaceSelectedEvent(m_IceTower));
  }
}

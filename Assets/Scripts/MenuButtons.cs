using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuButtons : MonoBehaviour
{
    // menu stuff
    public GameObject MenuButton;
    public GameObject MainPanel;
    public GameObject MenuPanel;
    public GameObject LocationsPanel;

    bool menuActive = false;
    TMP_Text menuButtonText;

    // player stuff
    public GameObject player;
    UnityEngine.AI.NavMeshAgent agent;
    bool navOn = false;

    // location stuff
    public List<Transform> locations = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        MainPanel.SetActive(false);
        MenuPanel.SetActive(false);
        LocationsPanel.SetActive(false);
        menuButtonText = MenuButton.GetComponentInChildren<TMP_Text>();
        agent = player.GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // this opens and closes the menu based on actions taken
    public void ToggleMenu()
    {   
        menuActive = !menuActive;
        MainPanel.SetActive(menuActive);
        if (menuActive){
            OpenMainMenu();
            menuButtonText.text = "Close Menu";
        }
        else {
            menuButtonText .text = "Menu";
        }
        
    }

    // this opens the main menu
    public void OpenMainMenu(){
        MenuPanel.SetActive(true);
        LocationsPanel.SetActive(false);
    }

    // this opens the locations menu
    public void OpenLocationMenu() {
        MenuPanel.SetActive(false);
        LocationsPanel.SetActive(true);
    }

    // sets the navigation option to true and opens locations
    public void SetNavigationOption(){
        navOn = true;
        OpenLocationMenu();
    }

    // sets the navigation option to false (warp instead) and opens locations
    public void SetWarpOption(){
        navOn = false;
        OpenLocationMenu();
    }

    // teleports player
    public void MovePlayer(int locationIndex){
        Transform goal = locations[locationIndex]; // get location
        
        if (navOn){
            agent.destination = goal.position; // this paths the player to the location
        }
        else {
            agent.Warp(goal.position); // this teleports the player.
        }
        ToggleMenu(); // this closes the menu upon teleportation

    }
}

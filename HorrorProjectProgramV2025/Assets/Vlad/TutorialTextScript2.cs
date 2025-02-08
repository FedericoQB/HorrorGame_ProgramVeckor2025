using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialTextScript2 : MonoBehaviour
{
    public TextMeshProUGUI GuiText;
    public GameObject Player;
    private bool OneTimeTrigger = true;
    private bool OneTimeTrigger2 = true;
    public GameObject Battery;
    private float timer;

    public GameObject Monster1;
    public GameObject Monster2;
    public GameObject Monster3;
    public GameObject Monster4;

    void Start()
    {
        GuiText.text = "(Voice): - Kinda dark here\nPress F for turning on/off the flashlight";
    }

    void Update()
    {
        if (Player.GetComponent<FlashlightScript>().flashLight.activeSelf && OneTimeTrigger)
        {
            OneTimeTrigger = false;
            GuiText.text = "(Voice): - There are a battery on the floor\nPick up it with key E";
        }

        if (!OneTimeTrigger && !Battery && OneTimeTrigger2)
        {
            OneTimeTrigger2 = false;
            GuiText.text = "(Voice): - Nice, now you have extra battery that\nwill repace the old battery emptys";
            timer = Time.time + 5f;
        }

        if (timer <= Time.time && GuiText.text == "(Voice): - Nice, now you have extra battery that\nwill repace the old battery emptys")
        {
            GuiText.text = "(Voice): - Now...";
            timer = Time.time + 2f;
        }

        if (timer <= Time.time && GuiText.text == "(Voice): - Now...")
        {
            GuiText.text = "(Voice): - Use your flashlight to keep yourself safe";
            timer = Time.time + 3f;
        }

        if (timer <= Time.time && GuiText.text == "(Voice): - Use your flashlight to keep yourself safe")
        {
            GuiText.text = "(Voice): - Goodluck";
            Monster1.SetActive(true);
            Monster2.SetActive(true);
            Monster3.SetActive(true);
            Monster4.SetActive(true);
            timer = Time.time + 15f;
        }

        if (timer <= Time.time && GuiText.text == "(Voice): - Goodluck")
        {
            GuiText.text = "(Voice): - Good";
            Destroy(Monster1);
            Destroy(Monster2);
            Destroy(Monster3);
            Destroy(Monster4);
            timer = Time.time + 1.5f;
        }

        if (timer <= Time.time && GuiText.text == "(Voice): - Good")
        {
            GuiText.text = "(Voice): - In game, it will be journal, you will be \nable to open with Tab key. Now press space to go to main menu";
            timer = Time.time;
        }

        if (timer <= Time.time && GuiText.text == "(Voice): - In game, it will be journal, you will be \nable to open with Tab key. Now press space to go to main menu")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Player.GetComponent<PlayerStatsScript>().insanityLevel = 1;
                PlayerStatsScript.flashlightBatteryProcent = 100f;
                PlayerStatsScript.reserveBattery = 0;
                Player.GetComponent<PlayerHealth>().health = Player.GetComponent<PlayerHealth>().maxHealth;
                Player.GetComponent<PlayerHealth>().HealthBarDamageSprite.SetActive(false);
                SceneManager.LoadScene(0);
            }
        }
    }
}

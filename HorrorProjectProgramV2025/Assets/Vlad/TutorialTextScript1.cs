using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialTextScript1 : MonoBehaviour
{
    public TextMeshProUGUI Room1Text;
    public GameObject Door1GameObject;
    public GameObject Player;

    private void Update()
    {
        if (Door1GameObject.GetComponent<Collider2D>().IsTouching(Player.GetComponent<PlayerHealth>().playerBoxCollider2D))
        {
            Room1Text.text = "(Voice): - Press E for to open the door";
        }
        else
        {
            Room1Text.text = "(Voice): - Move around with WASD keys";
        }
    }
}

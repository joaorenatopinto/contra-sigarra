using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCounter : MonoBehaviour
{
    public Weapon weapon;
    public Text ammoText;

    // Update is called once per frame
    void Update()
    {
        ammoText.text = "Grenades: " + weapon.grenadeAmmo.ToString();
    }
}

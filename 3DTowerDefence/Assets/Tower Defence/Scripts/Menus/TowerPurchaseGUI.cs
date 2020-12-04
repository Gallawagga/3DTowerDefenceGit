using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TowerDefence.Towers;

namespace TowerDefence.Managers
{
    public class TowerPurchaseGUI : MonoBehaviour
    {

        TowerManager toma;

        [HideInInspector] public static bool menuUp = false;
       
        private void Start()
        {
            toma = TowerManager.instance; //referencing the ONE instance of TowerManager
          
        }

        public void UpButton() //moves the GUI up and down from out of view. 
        {
            if (menuUp == false)
            {//only moves up and down by a set amount on the Y axis. 
                transform.position = new Vector3(transform.position.x, transform.position.y + 110, transform.position.z);
                menuUp = true;
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 110, transform.position.z);
                menuUp = false;
            }
        }

        public void TowerButton(int _buttonNo)
        {
            //clicking changes TowerManager.towerToPurchase to correspond with the button and spawnable tower array reference (should be identical, between 0 and 2).
            toma.towerToPurchase = toma.spawnableTowers[_buttonNo];

            Debug.Log("" +toma.towerToPurchase.UiDisplayText);
        }


    }
}

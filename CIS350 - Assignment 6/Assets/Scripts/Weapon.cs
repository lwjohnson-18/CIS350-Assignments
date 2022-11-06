using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Weapon : MonoBehaviour
    {
        public int damageBonus;

        public void Recharge()
        {
            Debug.Log("Recharging Weapon");
        }
    }
}
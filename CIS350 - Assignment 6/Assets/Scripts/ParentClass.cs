using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class ParentClass : MonoBehaviour
    {
        [SerializeField] protected Weapon weapon;

        protected virtual void Start()
        {
            weapon = gameObject.AddComponent<Weapon>();
        }
    }
}
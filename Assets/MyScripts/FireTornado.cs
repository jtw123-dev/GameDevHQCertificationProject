using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTornado : MonoBehaviour
{

    [SerializeField] private float _speed;
    [SerializeField] private float _attackDamage;
    private GameObject _target;
    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, 4);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Tower" || other.tag == "UpgradedTower")
        {
            if (other.GetComponent<IDamagable>() != null)
            {
                other.GetComponent<IDamagable>().Damage(_attackDamage); //changing it to nearestEnemy made it work better rather than obj.       
            }
        }
    }
}

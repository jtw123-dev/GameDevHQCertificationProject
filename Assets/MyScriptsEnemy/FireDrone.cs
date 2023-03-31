using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDrone : Enemy,IDamagable
{
    public float health { get; set; }
    [SerializeField] private GameObject _fireTornado;

    public void Damage(float healthDamage)
    {
        if (_health <= 0 && _isDead == false)//best to check bool up here rather than down there.
        {
            _isDead = true;
            {
                _agent.enabled = false;
                UIManager.Instance.UpdateWarFunds(300);
                Invoke("Hide", 0.5f);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour,IDamagable
{
    //public List<GameObject> towers = new List<GameObject>();
     [SerializeField]private float _health;

    public float health { get; set; }
    private bool _canBeHurt=true;
   [SerializeField] private bool _hasBeenUpgraded;

    public void TowerHasBeenUpgraded()
    {
        _hasBeenUpgraded = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(float healthDamage)
    {
        //StartCoroutine(WaitForDamage()); May or may not implement

        _health -= healthDamage;
             

    }
    private IEnumerator WaitForDamage()
    {
        _canBeHurt = false;
        yield return new WaitForSeconds(0.3f);
        _canBeHurt = true;
    }
}

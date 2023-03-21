using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour,IDamagable
{
    //public List<GameObject> towers = new List<GameObject>();
     [SerializeField]private int _health;

    public int health { get; set; }
    private bool _canBeHurt=true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage()
    {
        //StartCoroutine(WaitForDamage()); May or may not implement
      
            _health--;      

    }
    private IEnumerator WaitForDamage()
    {
        _canBeHurt = false;
        yield return new WaitForSeconds(0.3f);
        _canBeHurt = true;
    }
}

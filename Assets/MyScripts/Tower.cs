using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour,IDamagable
{
    //public List<GameObject> towers = new List<GameObject>();
     [SerializeField]private float _health;
    [SerializeField] private GameObject _explosion;

    public float health { get; set; }

   

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
             if (_health<=0)
        {
           var clone = Instantiate(_explosion,transform.position,Quaternion.identity);
            Destroy(clone, 1.5f);
            Destroy(this.gameObject, 1.5f);
        }

    }
  
}

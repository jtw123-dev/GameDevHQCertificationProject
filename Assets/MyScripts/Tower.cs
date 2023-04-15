using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    [SerializeField]protected float _health;
    [SerializeField] protected GameObject _explosion;
    protected bool _isDead;
    [SerializeField] protected List<GameObject> _inColliderGameObjects = new List<GameObject>();
    [SerializeField] protected Transform _rotateTurret;
    protected bool _isAttacking;
    protected float _currentHealthOfEnemy;
    [SerializeField] LayerMask _layerMask;
 
    public void Damage(float healthDamage)
    {     
        _health -= healthDamage;
             if (_health<=0)
        {
            _isDead = true;
            Vector3 offset = new Vector3(0, 1, 0);
            Ray rayOrigin = new Ray(transform.position + offset, Vector3.down);
            RaycastHit hitInfo;
           
            if (Physics.Raycast(rayOrigin,out hitInfo,1000,~_layerMask))
            {
                if (hitInfo.collider.tag=="Zone")
                {                    
                    hitInfo.collider.GetComponent<PlacementZoneScript>().ChangeParticleStatusToTrue();
                }
            }

           var clone = Instantiate(_explosion,transform.position,Quaternion.identity);         
            Destroy(clone, 1.5f);
            Destroy(this.gameObject, 0.7f);
        }            
    }
}

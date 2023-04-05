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
    private bool _droneIsDead;
    protected bool _isAttacking;
    protected float _currentHealthOfEnemy;
 
    public void Damage(float healthDamage)
    {     
        _health -= healthDamage;
             if (_health<=0)
        {
            _isDead = true;
            Ray rayOrigin = new Ray(transform.position, Vector3.down);
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin,out hitInfo))
            {
                Debug.Log(hitInfo.collider.name);
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

    public bool CommunicateDeath()
    {
        StartCoroutine(WaitForSoundToRestart());
        return _droneIsDead;
        


    }
    private IEnumerator WaitForSoundToRestart()
    {  
        yield return new WaitForSeconds(0.5f);
    }
}

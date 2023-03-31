using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager :MonoSingleton<PoolManager>
{
    [SerializeField] private GameObject _mechContainer;
    [SerializeField] private List<GameObject> _mechs;
    [SerializeField] private GameObject _mechPrefab;
    // Start is called before the first frame update
    void Start()
    {
        _mechs = MechGenerator(5);
    }

    private List<GameObject> MechGenerator(int amountOfMechs)
    {
        for (int i = 0; i < amountOfMechs; i++)
        {
            GameObject mech = Instantiate(_mechPrefab);
            mech.transform.parent = _mechContainer.transform;
            _mechs.Add(mech);
            mech.SetActive(false);
        }
        return _mechs;
    }


    public GameObject RequestMech() //make gameobject method to keep reference to bullet
    {
        foreach (var mech in _mechs)
        {
            if (mech.activeInHierarchy == false)
            {
                mech.SetActive(true);
                return mech;
            }
        }
        GameObject newMech = Instantiate(_mechPrefab);
        newMech.transform.parent = _mechContainer.transform;
        _mechs.Add(newMech);
        return newMech;
    }
        // Update is called once per frame
        void Update()
    {
        
    }
}

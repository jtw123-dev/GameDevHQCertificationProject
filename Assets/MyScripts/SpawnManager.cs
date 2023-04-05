using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class SpawnManager : MonoSingleton<SpawnManager>
{
    [SerializeField] private int _currentWave;
    [SerializeField] private GameObject _mechContainer;
    [SerializeField] private List<GameObject> _mechs;
    [SerializeField] private GameObject _mechPrefab;
    [SerializeField] private bool _newWave;
    [SerializeField] private GameObject[] _variousMechPrefabs;
    [SerializeField] private GameObject _levelComplete;
    private bool _hasDied;
    [SerializeField] private int _currentMechs;
    
    // Start is called before the first frame update
    void Start()
    {
        _mechs = MechGenerator(10);
        StartCoroutine(TestWave());
    }

    private List<GameObject> MechGenerator(int amountOfMechs)
    {
        for (int i = 0; i < amountOfMechs; i++)
        {
            if (_currentWave<2)
            {
                GameObject mech = Instantiate(_variousMechPrefabs[0]);
                mech.transform.parent = _mechContainer.transform;
                _mechs.Add(mech);
                mech.SetActive(false);
            }
         else if (_currentWave==2)
            {
                _currentMechs=1;
                GameObject mech = Instantiate(_variousMechPrefabs[1]);
                mech.transform.parent = _mechContainer.transform;
                _mechs.Add(mech);
                mech.SetActive(false);
            }

            else if (_currentWave==4)
            {
                _currentMechs=2;
                GameObject mech = Instantiate(_variousMechPrefabs[2]);
                mech.transform.parent = _mechContainer.transform;
                _mechs.Add(mech);
                mech.SetActive(false);
            }

            else if (_currentWave==6)
            {
                _currentMechs=3;
                GameObject mech = Instantiate(_variousMechPrefabs[3]);
                mech.transform.parent = _mechContainer.transform;
                _mechs.Add(mech);
                mech.SetActive(false);
            }
            else if (_currentWave>8)
            {
                Debug.Log("at last enemy");
                _currentMechs=4;
                GameObject mech = Instantiate(_variousMechPrefabs[4]);
                mech.transform.parent = _mechContainer.transform;
                _mechs.Add(mech);
                mech.SetActive(false);
            }     
        }
        return _mechs;
    }

    public void Update()
    {
        if (_currentWave>=10)
        {
            if(_mechs.All(m => m.activeInHierarchy == false))
            {
                _levelComplete.SetActive(true);
            }           
        }
    }


    public GameObject RequestMech()
    {
        foreach (var mech in _mechs)
        {
            if (mech.activeInHierarchy == false)
            {
                mech.SetActive(true);
                return mech;
            }
        }
        GameObject newMech = Instantiate(_variousMechPrefabs[_currentMechs]);
        newMech.transform.parent = _mechContainer.transform;
        _mechs.Add(newMech);
        return newMech;
    }

    private IEnumerator TestWave()
    {
        while (true)
        {
            switch (_currentWave)
            {
                case 0:
                    yield return new WaitForSeconds(5);
                    RequestMech();
                    if (Time.time >= 20 )
                    {
                        Debug.Log("This is case 0");
                        _hasDied = false;
                        _currentWave++;
                        UIManager.Instance.UpdateWaves();
                    }
                    break;
                case 1:
                    yield return new WaitForSeconds(3);
                    RequestMech();
                    if (Time.time >= 30)
                    {
                        _currentWave++;
                        UIManager.Instance.UpdateWaves();
                    }
                    break;
                case 2:
                    yield return new WaitForSeconds(3);
                    _mechs.Clear();                
                    foreach(Transform child in _mechContainer.transform)
                    {
                       if (child.gameObject.activeSelf==false)
                        {
                            Destroy(child.gameObject);
                        }
                       
                    }
                    
                    MechGenerator(10);
                    RequestMech();
                    if (Time.time >= 40)
                    {                      
                        _currentWave++;
                        UIManager.Instance.UpdateWaves();
                    }
                    break;
                case 3:
                    yield return new WaitForSeconds(3);
                    RequestMech();
                    if (Time.time >= 50)
                    {
                        _currentWave++;
                        UIManager.Instance.UpdateWaves();
                    }
                    break;
                case 4:
                    yield return new WaitForSeconds(3);
                    _mechs.Clear();
                    foreach (Transform child in _mechContainer.transform)
                    {
                        if (child.gameObject.activeSelf == false)
                        {
                            Destroy(child.gameObject);
                        }
                    }
                    MechGenerator(10);
                    RequestMech();
                    if (Time.time >= 60)
                    {
                        _currentWave++;
                        UIManager.Instance.UpdateWaves();
                    }
                    break;
                case 5:
                    yield return new WaitForSeconds(3);
                    RequestMech();
                    if (Time.time >= 70)
                    {
                        _currentWave++;
                        UIManager.Instance.UpdateWaves();
                    }
                    break;
                case 6:
                    yield return new WaitForSeconds(3);
                    _mechs.Clear();
                    foreach (Transform child in _mechContainer.transform)
                    {
                        if (child.gameObject.activeSelf == false)
                        {
                            Destroy(child.gameObject);
                        }
                    }
                    MechGenerator(10);
                    RequestMech();
                    if (Time.time >= 80)
                    {                 
                        _currentWave++;
                        UIManager.Instance.UpdateWaves();
                    }
                    break;
                case 7:
                    yield return new WaitForSeconds(3);
                    RequestMech();
                    if (Time.time >= 90)
                    {
                        _currentWave++;
                        UIManager.Instance.UpdateWaves();
                    }
                    break;
                case 8:
                    yield return new WaitForSeconds(3);
                    Debug.Log("You are on case 8");
                    _mechs.Clear();
                    foreach (Transform child in _mechContainer.transform)
                    {
                        if (child.gameObject.activeSelf == false)
                        {
                            Destroy(child.gameObject);
                        }
                    }
                    MechGenerator(10);
                    RequestMech();
                    if (Time.time >= 100)
                    {
                        _currentWave++;
                        UIManager.Instance.UpdateWaves();
                        Debug.Log("You are still on 8");
                    }
                    break;
                case 9:
                    yield return new WaitForSeconds(3);
                    Debug.Log("You are on case 9");
                    _mechs.Clear();
                    foreach (Transform child in _mechContainer.transform)
                    {
                        if (child.gameObject.activeSelf == false)
                        {
                            Destroy(child.gameObject);
                        }
                    }
                    MechGenerator(4);
                    RequestMech();
                    if (Time.time >= 110)
                    {
                        _currentWave++;
                        UIManager.Instance.UpdateWaves();
                    }
                    break;               
            }
            if (_currentWave >= 10)
            {
                Debug.Log("Finished ");
                break;
            }
        }
    }
}
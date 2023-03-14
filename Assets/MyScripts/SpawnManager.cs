using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class SpawnManager : MonoSingleton<SpawnManager>
{
    [SerializeField] private List<Waves> _waves;
    [SerializeField ]private int _currentWave;
    [SerializeField] private GameObject _mechContainer;
    [SerializeField] private List<GameObject> _mechs;
    [SerializeField] private GameObject _mechPrefab;
    private bool _needAnotherMech;
    [SerializeField] private bool _newWave;
    private int _hasDied;
    public override void Init()
    {
        base.Init();
    }

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
            GameObject mech = Instantiate(_mechPrefab);
            mech.transform.parent = _mechContainer.transform;
            _mechs.Add(mech);
            mech.SetActive(false);
        }
        return _mechs;
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
      
        GameObject newMech = Instantiate(_mechPrefab);
        newMech.transform.parent = _mechContainer.transform;
        _mechs.Add(newMech);
        return newMech;
    }

    // Update is called once per frame
    void Update()
    {


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
                    if (Time.time >= 20)
                    {
                        _currentWave++;                     
                    }
                    break;
                case 1:
                    yield return new WaitForSeconds(3);
                    RequestMech();
                    if (Time.time>=30)
                    {
                        _currentWave++;
                    }
                    break;
                case 2:
                    yield return new WaitForSeconds(3);
                    RequestMech();
                    if (Time.time >= 40)
                    {
                        _currentWave++;
                    }
                    break;
                case 3:
                    yield return new WaitForSeconds(3);
                    RequestMech();
                    if (Time.time >= 50)
                    {
                        _currentWave++;
                    }
                    break;
                case 4:
                    yield return new WaitForSeconds(3);
                    RequestMech();
                    if (Time.time >= 60)
                    {
                        _currentWave++;
                    }
                    break;
                case 5:
                    yield return new WaitForSeconds(3);
                    RequestMech();
                    if (Time.time >= 70)
                    {
                        _currentWave++;
                    }
                    break;
                case 6:
                    yield return new WaitForSeconds(3);
                    RequestMech();
                    if (Time.time >= 80)
                    {
                        _currentWave++;
                    }
                    break;
                case 7:
                    yield return new WaitForSeconds(3);
                    RequestMech();
                    if (Time.time >= 90)
                    {
                        _currentWave++;
                    }
                    break;
                case 8:
                    yield return new WaitForSeconds(3);
                    RequestMech();
                    if (Time.time >= 100)
                    {
                        _currentWave++;
                    }
                    break;
                case 9:
                    yield return new WaitForSeconds(3);
                    RequestMech();
                    if (Time.time >= 110)
                    {
                        _currentWave++;
                    }
                    break;
                case 10:
                    yield return new WaitForSeconds(3);
                    RequestMech();
                    if (Time.time >= 120)
                    {
                        _currentWave++;
                    }
                    break;

            }
            if (_currentWave==10)
            {
                Debug.Log("Finished ");
                break;
            }          
        }      
    }

   /* private IEnumerator StartWave()
    {
        while (true)
        {
            switch (_currentWave)
            {
                case 0:
                    RequestMech();
            break;


            }

            var currentWave = _waves[_currentWave].sequence;
            var previousWave = new GameObject("PreviousWave");
          
            foreach (var obj in currentWave)
            {
                Instantiate(obj, previousWave.transform);
                yield return new WaitForSeconds(5);
            }
            yield return new WaitForSeconds(5);
            Destroy(previousWave);
           
            _currentWave++;
            if (_currentWave == _waves.Count)
            {
                Debug.Log("Finished waves");
                break;
            }
        }



        //RequestMech();

    

    }
    /* private IEnumerator StartWaveSequence()
     {
         while (true)
         {
             //if (_allActive==true)
             if()
             {
                 yield return new WaitForSeconds(10);
                 _allActive = false;
                 _currentWave++;
                 _mechs = MechGenerator(_waves[_currentWave].sequence.Count);
                 //break;
             }
             else if (_allActive==false)
             {
                 yield return new WaitForSeconds(5);
                 RequestMech();
             }


         }


         //need to call request mech probably here
         /* while (true)
         {
             var currentWave = _waves[_currentWave].sequence;
             var previousWave = new GameObject("PreviousWave");
             foreach(var obj in currentWave)
             {
                 Instantiate(obj,previousWave.transform);
                 yield return new WaitForSeconds(10);
             }
             yield return new WaitForSeconds(5);
             Destroy(previousWave);

             if (_currentWave==_waves.Count)
             {

             }
             break;
         }
         */

    // }
}
// if (_mechs.All(m => m.gameObject.activeInHierarchy == true))
//{
//  return null;
//}
//you could increment mechs by ++ and than break the loop that way.
    // if (_mechs.All(m => m.gameObject.activeInHierarchy == true))//by doing this we can only go to the next wave by destroying all mechs
                                                                        //just need to create a list to deactivate one by one and when they are all false we can go to next wave
                                                                        //just fufill requirements you don't have to use it.
                                                                        //if need be create another list 
                                                                        //more likely you will need to create a timer that will end all mechs
                                                                        //do the easier thing 
                                                                        //when a mech dies just recycle it
          //  {

          //      Destroy(previousWave);
         //   }
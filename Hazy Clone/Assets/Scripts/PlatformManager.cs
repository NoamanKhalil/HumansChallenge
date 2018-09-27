using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    //Handles refrences to platforms
    [SerializeField]
    private GameObject[] easyPlatforms;
    [SerializeField]
    private GameObject[] normalPlatforms;
    [SerializeField]
    private GameObject[] hardPlatforms;

    // initial postions for platforms to spawn at
    [Header("Refrence to the spawn start positon")]
    [SerializeField]
    private GameObject[] startPos;
    // final postions for platforms reach
    [SerializeField]
    private GameObject endPos;

    // distance between each spawned platform
    [Header("distance between each spawned platform , keep value more than 4")]
    [SerializeField]
    private float spawnWidth;

    [Header("Time Before next platform is instataited , defaults to 1 if value is 0")]
    [SerializeField]
    private float myTime;
    // used to calculate the next postion to instantiate at 
    [SerializeField]
    private Vector3 []tempPos;


    // qeue to keep track of platfroms
    public Queue<GameObject> platforms = new Queue<GameObject>();


    public static PlatformManager instance { get; private set; }

    // of instantiations 
    int tempCount;



    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }
    // Use this for initialization
    void Start()
    {
        if (myTime==0)
        {
            myTime = 1;
        }

        tempPos[0] = startPos[0].transform.position;
        tempPos[1] = startPos[1].transform.position;
        tempPos[2] = startPos[2].transform.position;
        StartCoroutine(Spawn());
    }
    // instatiates a random platform every 1 second , at tempPos & increases the y every time.
    //every time a object spawn it will be 4 units away 
    // after 5 objects are spawned it will stop spawning and only spawn once the first objects have been removed from the qeue  
    IEnumerator Spawn()
    {
        while (true)
        {
            if (platforms.Count <=5)
            {
                // to randomize spawn positons
                int randomNum = Random.Range(0, 2);
                // to keep add instantiated objects to the qeue
                GameObject go;
                go = Instantiate(easyPlatforms[Random.Range(0, easyPlatforms.Length)], tempPos[randomNum], Quaternion.identity);
                // adds instantiated objects to the qeue
                platforms.Enqueue(go);
                // every time it runs it needs to be pos.z + 1 five times then reset to the initial position 
                if (tempCount <= 5)
                {

                    tempPos[0].z = tempPos[0].z + 4;
                    tempPos[1].z = tempPos[1].z + 4;
                    tempPos[2].z = tempPos[2].z + 4;

                    tempCount++;
                }
                else
                {
                    tempPos[0] = startPos[0].transform.position;
                    tempPos[1] = startPos[1].transform.position;
                    tempPos[2] = startPos[2].transform.position;
                    tempCount = 0;
                }

            }


            yield return new WaitForSeconds(myTime);
        }
    }


    public void enqueeThis(GameObject go)
    {
        platforms.Enqueue(go);
    }
    /*public void denqueeThis(GameObject go)
    {
        platforms.Dequeue(go);
    }*/
}
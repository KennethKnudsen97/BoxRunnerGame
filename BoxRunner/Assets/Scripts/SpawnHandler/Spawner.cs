using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    public GameObject prefab; //Obstacle
    public Transform player; 

    //Variables for shuffling Spawnpoints
    private int numberOfChilds = 0;
    private ShuffleGameObjects shuffleGameObjects;
    GameObject[] childList;

    //Variables for keeping track of player position
    float posNow = 0;
    float posBefore = 0;

    private void Start()
    {
        //Variables for spawning distance 
        posBefore = player.transform.position.z;
        posNow = posBefore;

        //We want our list to be dynamic so if editor adds more child object to class then update this
        numberOfChilds = gameObject.transform.childCount;

        //Instantiate childlist with the number of childs for parent
        childList = new GameObject[numberOfChilds];

        //Get all child gameobject in array to be shuffled later
        for (int i = 0; i < numberOfChilds; i++)
        {
            childList[i] = gameObject.transform.GetChild(i).gameObject;
        }
        //Instantiating Shuffle Class with default constructor 
        shuffleGameObjects = new ShuffleGameObjects();
    }


    // Update is called once per frame
    void Update()
    {
        //Check how far player has moved 
        posNow = player.transform.position.z;
        //Move transform according to player and an offset 
        transform.position = new Vector3(transform.position.x, transform.position.y, player.position.z + 100);

        if (posNow > posBefore + 50)
        {

            //Shuffle list after use
            shuffleGameObjects.shuffle(childList);


            //Get the number of obstacles to spawn and then spawn them 
            int numberOfObstacles = Random.Range(1, 5);
            for (int i = 0; i < numberOfObstacles; i++)
            {
                //Unity's way of spawning objects (take in object, position and a rotation 
                Instantiate(prefab, transform.GetChild(i).position, Quaternion.identity);
            }


            //Update posBefore to keep track of player pos and when to spawn more objects 
            posBefore = posNow;
        }
    }
}


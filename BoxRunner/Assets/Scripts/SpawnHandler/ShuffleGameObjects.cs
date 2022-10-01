using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Implementing IShuffle for ShuffleGameObjects and specifing TArray as type GameObjects 
public class ShuffleGameObjects : IShuffle<GameObject>
{
    //Variable for how many items getting swapped.
    private int shuffleCount;

    //Default constructor sets shufflecount for 10 as default value
    public ShuffleGameObjects()
    {
        this.shuffleCount = 10;
    }

    //Constructor with some shuffleCount
    public ShuffleGameObjects(int shuffleCount)
    {
        this.shuffleCount = shuffleCount;
    }


    public void shuffle(GameObject[] listToShuffle)
    {

        int length = listToShuffle.Length;
        int count = 0;

        while (count < shuffleCount)
        {
            //Get the two objects to be swapped and a temp object as holder
            GameObject oldPosObject = listToShuffle[Random.Range(0, length)];
            GameObject newPosObject = listToShuffle[Random.Range(0, length)];
          

            Vector3 tempPos = oldPosObject.transform.position;

            //Swap position
            oldPosObject.transform.position = newPosObject.transform.position;
            newPosObject.transform.position = tempPos;
            count++;
        }

    }

    //Getter 
    public int getShuffleCount()
    {
        return shuffleCount;
    }

    //Setter 
    public void setShuffleCount(int shuffleCount)
    {
        this.shuffleCount = shuffleCount;
    }
}


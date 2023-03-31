using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField] GameObject platformPrefab;
    [SerializeField] Transform currentPlatform;
    [SerializeField] int startingPlatformCount;
    int nextPlatformDirection;
    public static PlatformGenerator instance;

    private void OnEnable()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        GenerateStartingPlatforms();
    }

    public void GenerateStartingPlatforms()
    {
        for (int i = 0; i < startingPlatformCount; i++)
        {
            nextPlatformDirection = Random.Range(0, 2);
            if (nextPlatformDirection == 0)
            {
                currentPlatform = Instantiate(platformPrefab, currentPlatform.position + Vector3.right, Quaternion.identity).transform;
            }
            else
            {
                currentPlatform = Instantiate(platformPrefab, currentPlatform.position + Vector3.forward, Quaternion.identity).transform;
            }
        }
    }

    public void NextPlatform()
    {
        nextPlatformDirection = Random.Range(0, 2);
        if (nextPlatformDirection == 0)
        {
            currentPlatform = Instantiate(platformPrefab, currentPlatform.position + Vector3.right, Quaternion.identity).transform;
        }
        else
        {
            currentPlatform = Instantiate(platformPrefab, currentPlatform.position + Vector3.forward, Quaternion.identity).transform;
        }
    }

}

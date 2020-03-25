using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Platforms;
using UnityEngine;

public class PlatformFactory: MonoBehaviour
{
    [Min(2)] public int PlatformCount = 2;
    public float DistanceToTrigger = 3f;

    [SerializeField] private Transform Target;
    [SerializeField] private Transform LevelStart;
    [SerializeField] private Transform[] ToPrint;
    [SerializeField] private Transform LevelEnd;

    //[SerializeField] private Transform _prototype;

    private Vector3 _endPoint = new Vector3(0, 0, 0);
    private static float _levelWidth = 15f; //I dont know how to get the width of a parent object


    void Start()
    {
        StartCoroutine(GeneratePlatforms());
    }

    IEnumerator GeneratePlatforms()
    {
        Instantiate(LevelStart);

        //Iterate (condition)
        for (int i = 0; i < PlatformCount - 2; i++)
        {
            yield return new WaitUntil(SpawnCondition);
            SpawnPlatform(ReturnRandom());
        }
        //Spawn last
        yield return new WaitUntil(SpawnCondition);
        SpawnPlatform(LevelEnd);
        }

        bool SpawnCondition()
    {
        return Vector3.Distance(Target.position, _endPoint) <= DistanceToTrigger;
    }

    void SpawnPlatform(Transform toSpawn)
    {
        Transform _toSpawn = toSpawn;
        _toSpawn.transform.position = new Vector3(_endPoint.x + _levelWidth, _endPoint.y, _endPoint.z);
        Instantiate(_toSpawn);
        _endPoint = _toSpawn.position;

        Debug.Log(_endPoint);
    }

    Transform ReturnRandom()
    {
        return ToPrint[Random.Range(0, ToPrint.Length)];
    }
}

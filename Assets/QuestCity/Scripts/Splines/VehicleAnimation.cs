using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleAnimation : MonoBehaviour
{
    public bool closedLoop = true;

    private GameObject rootPathsObj;
    [SerializeField] private List<PathCreator> paths = new List<PathCreator>();
    [SerializeField] private List<GameObject> vehicles = new List<GameObject>();



    void Start()
    {
        rootPathsObj = new GameObject("[PATHS]");
        rootPathsObj.transform.SetParent(gameObject.transform);
    }

    GameObject GetRandomVehicle() => vehicles[Random.Range(0, vehicles.Count)];

    public GameObject SpawnRandomVehicleInPath(PathCreator path) 
    {
        GameObject vehicle = Instantiate(GetRandomVehicle(), Vector3.zero, Quaternion.identity, rootPathsObj.transform);
        vehicle.transform.SetParent(path.gameObject.transform);
        PathCreation.Examples.PathFollower follower = vehicle.AddComponent<PathCreation.Examples.PathFollower>();
        follower.pathCreator = path;
        return vehicle;
    }
    public GameObject SpawnRandomVehicleInPath(int pathNumber) => SpawnRandomVehicleInPath(paths[pathNumber]);
    public void SpawnRandomVehicle(int pathNumber) => SpawnRandomVehicleInPath(paths[pathNumber]);


    public void CreateNewPath(List<Transform> points, bool closedLoop)
    {
        GameObject pathObj = new GameObject("Path");
        pathObj.transform.SetParent(rootPathsObj.transform);
        PathCreator path = pathObj.AddComponent<PathCreator>();
        paths.Add(path);


        if (points.Count > 0)
        {
            BezierPath bezierPath = new BezierPath(points, closedLoop, PathSpace.xyz);
            bezierPath.GlobalNormalsAngle = 90;
            path.bezierPath = bezierPath;
        }
    }

    public void CreateNewPath(GameObject rootObject)
    {
        List<Transform> points = new List<Transform>();
        foreach (Transform pointPath in rootObject.transform) points.Add(pointPath);
        CreateNewPath(points, true);
    }
}

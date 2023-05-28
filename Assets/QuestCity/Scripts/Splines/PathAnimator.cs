using PathCreation;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace QuestCity.Splines {
	public class PathAnimator : MonoBehaviour
	{
		public bool closedLoop = true;

		private GameObject rootPathsObj;
		[SerializeField] private List<PathCreator> paths = new List<PathCreator>();
		[SerializeField] private List<GameObject> _gameObjects = new List<GameObject>();

		[Header("Генерация пути на страте")]
		[SerializeField] private bool isStartPathGenerate = false;
		[SerializeField] private List<GameObject> OnStartPathGenerate = new List<GameObject>();

		[Header("Спавн объектов следующих на путях")]
		[SerializeField] private bool isStartObjectSpawn = false;
		[SerializeField] private float speedObjects;
		[SerializeField] private int countObjects = 2;

		void Start()
		{
			rootPathsObj = new GameObject("[PATHS]");
			rootPathsObj.transform.SetParent(gameObject.transform);

			if (isStartPathGenerate) {
				foreach (GameObject path in OnStartPathGenerate) CreateNewPath(path);
			}

			if (isStartObjectSpawn) {
				foreach (var item in paths) StartCoroutine(SpawnRandomObjects(countObjects));
			}
		}

		GameObject GetRandomGameObject() => _gameObjects[Random.Range(0, _gameObjects.Count)];


		public GameObject SpawnRandomVehicleInPath(PathCreator path, float speed)
		{
			GameObject _gameObject = Instantiate(GetRandomGameObject(), Vector3.zero, Quaternion.identity, rootPathsObj.transform);
			_gameObject.transform.SetParent(path.gameObject.transform);
			PathCreation.Examples.PathFollower follower = _gameObject.AddComponent<PathCreation.Examples.PathFollower>();
			follower.speed = speed;
			follower.pathCreator = path;
			return _gameObject;
		}

		public GameObject SpawnRandomVehicleInPath(PathCreator path) => SpawnRandomVehicleInPath(path, 1);
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






		IEnumerator SpawnRandomObjects(int countObjects)
		{
			for (int i = 0; i < countObjects; i++) {
				SpawnRandomVehicleInPath(paths[0], speedObjects);
				yield return new WaitForSeconds(Random.Range(5.0f, 20.0f));
			
			}
		}
	}

}


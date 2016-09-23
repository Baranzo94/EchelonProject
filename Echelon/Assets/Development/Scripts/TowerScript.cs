using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerScript : MonoBehaviour {


	public List<GameObject> enemiesSort;

	private float lastFireTime;

	public float fireRate;

	public float speed = 1.0f;
	// Use this for initialization
	void Start () {
		enemiesSort = new List<GameObject> ();
		lastFireTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

		GameObject target = null;
		//Transform target2 = null;


		//float minimalEnemyDistance = float.MaxValue;
		foreach (GameObject enemy in enemiesSort) {
			target = enemy;
			//Calculate distance to objective, attack one closest
		}

		if (target != null) {
			
			if (Time.time - lastFireTime > fireRate) {
				Fire (target.GetComponent<Collider2D> ());
				lastFireTime = Time.time;
			}

			Vector3 direction = gameObject.transform.position - target.transform.position;
			gameObject.transform.rotation = Quaternion.AngleAxis(
				Mathf.Atan2 (direction.y, direction.x) * 180 / Mathf.PI,
				new Vector3 (0, 0, 1));
		}




		
	
	}

	void onEnemyDestroy (GameObject enemy)
	{
		enemiesSort.Remove (enemy);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag.Equals ("Enemy")) {
			enemiesSort.Add (other.gameObject);
			//
		}

	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.gameObject.tag.Equals ("Enemy")) {
		
			enemiesSort.Remove (other.gameObject);
		}
	}

	void Fire(Collider2D target)
	{
		GameObject ProjectilePrefab = gameObject;

		Vector3 startPosition = gameObject.transform.position;
		Vector3 targetPosition = target.transform.position;
		startPosition.z = ProjectilePrefab.transform.position.z;
		targetPosition.z = ProjectilePrefab.transform.position.z;


		/*GameObject newProjectile = (GameObject)Instantiate (ProjectilePrefab);
		newProjectile.transform.position = startPosition;
		ProjectileBehavior ProjectileComp = newProjectile.GetComponent<ProjectileBehavior>();
		ProjectileComp.target = target.gameObject;
		ProjectileComp.startPosition = startPosition;
		ProjectileComp.targetPosition = targetPosition;*/
	}
}

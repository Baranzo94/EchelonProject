using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileMap : MonoBehaviour {

	public Transform tilePrefab;
	public Vector2 mapSize;

	[Range(0,1)]
	public float outlinePercent;
	public float tileSize;

	List<Coord>allTileCoords;
	Queue<Coord>shuffledTileCoords;


	// Use this for initialization
	void Start () {
		GenerateMap ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void GenerateMap()
	{
		allTileCoords = new List<Coord> ();

		for (int x = 0; x < mapSize.x; x++)
		{
			for (int y = 0; y < mapSize.y; y++)
			{
				allTileCoords.Add(new Coord(x,y));
			}
		}

		string holderName = "Map";

		if (transform.FindChild (holderName)) {
			DestroyImmediate (transform.FindChild (holderName).gameObject);
		}

		Transform mapHolder = new GameObject (holderName).transform;
		mapHolder.parent = transform;

		for (int x = 0; x < mapSize.x; x ++)
		{
			for (int y = 0; y < mapSize.y; y++) 
			{
				Vector3 tilePosition = CoordToPosition (x, y);
				Transform newTile = Instantiate (tilePrefab, tilePosition, Quaternion.Euler (Vector3.right * 90)) as Transform;
				newTile.localScale = Vector3.one * (1 - outlinePercent) * tileSize;
				newTile.parent = mapHolder;
			}
		}
	}

	Vector3 CoordToPosition (int x, int y)
	{
		return new Vector3 (-mapSize.x / 2 + 0.5f + x, 0, -mapSize.y / 2 + 0.5f + y) * tileSize;
	}

	/*public Coord GetRandomCoord()
	{
		Coord randomCoord = shuffledTileCoords.Dequeue ();

		shuffledTileCoords.Enqueue (randomCoord);

		return randomCoord;
	}*/

	public struct Coord
	{
		public int x;
		public int y;

		public Coord(int _x, int _y)
		{
			x = _x;
			y = _y;
		}

	}
}

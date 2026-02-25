using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] Transform start, end;
    [SerializeField] GameObject tilePrefab;

    [SerializeField] List<GameObject> tiles;

    float tileLength;

    private void Start()
    {
        tileLength = tilePrefab.GetComponent<Renderer>().bounds.size.x;
    }

    void SpawnTile()
    {
        var startPos = tiles[tiles.Count - 1].transform.position + Vector3.right * tileLength;
        tiles.Add(Instantiate(tilePrefab, startPos, Quaternion.identity));
    }

    private void Update()
    {
        MoveTile();

        if (tiles[0].transform.position.x < end.position.x)
        {
            Destroy(tiles[0]);
            tiles.RemoveAt(0);
            SpawnTile();
        }
    }

    void MoveTile()
    {
        foreach (var tile in tiles)
        {
            tile.transform.position -= new Vector3(speed * Time.deltaTime,0,0);
        }
    }
}

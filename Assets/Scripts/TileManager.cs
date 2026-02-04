using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField] Transform start, end;
    [SerializeField] GameObject tilePrefab;

    [SerializeField] List<GameObject> tiles;

    [SerializeField] float speed = 2f;
    [SerializeField] float time = 4f;

    private void Start()
    {
        InvokeRepeating("SpawnTile",0f,time);
    }

    void SpawnTile()
    {
        tiles.Add(Instantiate(tilePrefab, start.position, Quaternion.identity));
    }

    private void Update()
    {
        MoveTile();
    }

    void MoveTile()
    {
        foreach (var tile in tiles)
        {
            tile.transform.position -= new Vector3(speed * Time.deltaTime,0,0);
        }
    }
}

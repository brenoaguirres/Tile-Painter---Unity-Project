using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    private List<Tile> tiles = new List<Tile>();

    private int paintedTiles;
    private int totalTiles;
    private float timerToCount = 0f;
    [SerializeField] private DynamicText tilesUI;
    
    void Start()
    {
        tiles = GetComponentsInChildren<Tile>().ToList<Tile>();
        totalTiles = tiles.Count;
    }

    void Update()
    {
        timerToCount += Time.deltaTime;
        if (timerToCount >= 1f) {
            UpdatePaintedTiles();
            timerToCount = 0f;
        }
    }

    void UpdatePaintedTiles() {
        int count = 0;
        foreach (Tile t in tiles) {
            if (t.Painted()) count++;
        }
        paintedTiles = count;
        tilesUI.UpdateText(paintedTiles + " / " + totalTiles);

    }
}

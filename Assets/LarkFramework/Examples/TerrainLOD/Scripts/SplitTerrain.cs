using UnityEngine;
using System.Collections;

public class SplitTerrain : MonoBehaviour {

    public Terrain largeTerrain;

    private TerrainData largeTerrainData;
    private Vector3 scale;

	// Use this for initialization
	void Start () {
        largeTerrainData = largeTerrain.terrainData;
        scale = largeTerrainData.size;

        CreateTerrain();
    }
	
	// Update is called once per frame
	void Update () {

    }

    /// <summary>
    /// 创建地形
    /// </summary>
    private void CreateTerrain()
    {
        var terrainData = new TerrainData();
        var terrain = Terrain.CreateTerrainGameObject(terrainData).GetComponent<Terrain>();
        terrain.transform.SetParent(transform);
        terrainData.heightmapResolution = (int)largeTerrainData.heightmapResolution / 2;
        terrainData.size = new Vector3(scale.x/2, scale.y, scale.z / 2);
        terrain.transform.position = new Vector3(scale.x, 0, scale.z);
        terrain.transform.name = "xxxx";

        //分割高度图
        terrain.basemapDistance = 100;
        int x, y;
        x = largeTerrainData.heightmapWidth / 2;
        y = largeTerrainData.heightmapHeight / 2;
        float[,] height = largeTerrainData.GetHeights(x*0, y*0, x + 1, y + 1);
        terrainData.SetHeights(0, 0, height);

        //分割地形纹理
        int x1, y1;
        x1 = largeTerrainData.alphamapWidth/2;
        y1 = largeTerrainData.alphamapHeight/2;
        float[,,] alphaHeight=largeTerrainData.GetAlphamaps(x * 0, y * 0, x1, y1);
        terrainData.alphamapResolution = largeTerrainData.alphamapResolution / 2;
        terrainData.splatPrototypes = largeTerrainData.splatPrototypes;
        terrainData.SetAlphamaps(0, 0, alphaHeight);
    }
}

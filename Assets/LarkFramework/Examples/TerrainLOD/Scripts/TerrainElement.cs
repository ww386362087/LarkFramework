using UnityEngine;
using System.Collections;

public class TerrainElement : MonoBehaviour {

    [HideInInspector]
    public int cow;
    [HideInInspector]
    public int rol;

    private Terrain terrain;

	// Use this for initialization
	void Start () {
        terrain = GetComponent<Terrain>();

        Init(cow,rol);
    }

    /// <summary>
    /// 地形初始化
    /// </summary>
    public void Init(int cow,int rol)
    {
        name = cow + "|" + rol;
        transform.position = new Vector3(rol * terrain.terrainData.size.x, 0, cow * terrain.terrainData.size.z);
        gameObject.layer = LayerMask.NameToLayer("Terrain");
    }
}

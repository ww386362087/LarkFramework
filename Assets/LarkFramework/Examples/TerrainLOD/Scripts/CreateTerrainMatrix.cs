using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateTerrainMatrix : MonoBehaviour {

    /// <summary>
    /// 行
    /// </summary>
    public int row;
    /// <summary>
    /// 列
    /// </summary>
    public int col;

    public GameObject terrain;

    public Dictionary<string, TerrainElement> terrainDict=new Dictionary<string, TerrainElement>();

	// Use this for initialization
	void Start () {
        CreateMatrix();
    }

    private void CreateMatrix()
    {
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                var temp = (GameObject)Instantiate(terrain, transform.position, transform.rotation);
                temp.transform.SetParent(transform);
                var temp1=temp.GetComponent<TerrainElement>();

                terrainDict.Add(temp1.name,temp1);
            }
        }
    }

    /// <summary>
    /// 根据传入的地形名刷新地形
    /// </summary>
    /// <param name="name"></param>
    public void UpdateTerrain(string name)
    {
        print("要刷新的地形是：" + name);
    }
}

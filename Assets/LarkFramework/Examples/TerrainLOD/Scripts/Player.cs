using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float lodUpdateTime;

    public CreateTerrainMatrix ctm;
    public TerrainGameMode tgm;

    private string lastName;

	// Use this for initialization
	void Start () {
        StartCoroutine(UpdateLod());
	
	}

    IEnumerator UpdateLod()
    {
        yield return new WaitForSeconds(lodUpdateTime);

        CheckLod();

        StartCoroutine(UpdateLod());
    }

    private void CheckLod()
    {
        //创建一条向下的射线
        Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.up), Color.red,0.2f);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.up), out hit, tgm.scaleHeight))
        {
            if (hit.collider.gameObject.layer != LayerMask.NameToLayer("Terrain"))
            {
                return;
            }

            var temp = hit.collider.GetComponent<TerrainElement>();
            //检测是否和上一次地形相同
            if (lastName != null && lastName.Equals(temp.name))
            {
                //是则不更新
                return;
            }
            else
            {
                //通知TerrainMgr根据Id刷新地形
                ctm.UpdateTerrain(temp.name);

                lastName = temp.name;
            }
        }
    }
}

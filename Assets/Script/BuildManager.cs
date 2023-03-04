using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null) //타워가 있으면
        {
            Debug.LogError("More than one BuildManager in scene!"); //에러메시지 더 지을수 없습니다
            return;
        }
        instance = this;
    }

    // 건설버튼 프리펩 이름 선언
    public GameObject CotaPrefab;
    public GameObject FirecatPrefab;
    public GameObject IroncatPrefab;
    public GameObject strangePrefab;

    private TurretBlueprint turretToBuild;
   

    public bool CanBuild
    {
        get { return turretToBuild != null; }
    }
    public bool HasMoney
    {
        get { return PlayerStats.Money >= turretToBuild.cost; }
    }

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost) //사용자 돈이 건설비용보다 적을때
        {
            Debug.Log("Not euough money to build that"); //지을 돈이 충분하지 않다 메시지호출
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
        Debug.Log("Turret build! Money left: " + PlayerStats.Money);
    }

    public void SetTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
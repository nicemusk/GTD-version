using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null) //Ÿ���� ������
        {
            Debug.LogError("More than one BuildManager in scene!"); //�����޽��� �� ������ �����ϴ�
            return;
        }
        instance = this;
    }

    // �Ǽ���ư ������ �̸� ����
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
        if (PlayerStats.Money < turretToBuild.cost) //����� ���� �Ǽ���뺸�� ������
        {
            Debug.Log("Not euough money to build that"); //���� ���� ������� �ʴ� �޽���ȣ��
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
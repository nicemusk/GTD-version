using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint CotaPrefab; //�ν�����â Ÿ�������� �ִ�ĭ ����
    public TurretBlueprint FirecatPrefab;
    public TurretBlueprint IroncatPrefab;
    public TurretBlueprint strangePrefab;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;

    }

    // �Ǽ���ư ������ ����

    // �Ǽ�1~4(Shoptw1~4)��ư buildManager���� ��������
    public void PurchaseCotaPrefabTurret()
    {
        Debug.Log("CotaPrefab");
        buildManager.SetTurretToBuild(CotaPrefab);
    }

    public void PurchaseFirecatPrefabTurret()
    {
        Debug.Log("FirecatPrefab");
        buildManager.SetTurretToBuild(FirecatPrefab);
    }

    public void PurchaseIroncatPrefabTurret()
    {
        Debug.Log("IroncatPrefab");
        buildManager.SetTurretToBuild(IroncatPrefab);
    }

    public void PurchasestrangePrefabTurret()
    {
        Debug.Log("strangePrefab");
        buildManager.SetTurretToBuild(strangePrefab);
    }

}

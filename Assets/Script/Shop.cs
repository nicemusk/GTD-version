using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint CotaPrefab; //인스펙터창 타워프리펩 넣는칸 생성
    public TurretBlueprint FirecatPrefab;
    public TurretBlueprint IroncatPrefab;
    public TurretBlueprint strangePrefab;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;

    }

    // 건설버튼 프리펩 설정

    // 건설1~4(Shoptw1~4)버튼 buildManager에서 가져오기
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

using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;        //?????? ???????? ?????? ??????
    public Color notEnoughMoneyColor; //???? 0 ???? ??
    public Vector3 positionOffset;  //???? ???? ???????? ????

    // ??????????
    [Header("optional")]
    public GameObject turret;
    // private GameObject turret;

    private Renderer rend;
    private Color startColor; //??????

    BuildManager buildManager;
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    // ?????? ??????
    void OnMouseDown()
    {
        if (!buildManager.CanBuild)
            // if (buildManager.GetTurretToBuild() == null) //buildManager ?? GetTurretToBuild ?? ??????(null??????)
            return;

        if (turret != null) //?????? null???? ??????(?????? ??????)
        {
            Debug.Log("Can't build"); //?????? ?????? ?????? ????
            return;
        }
        buildManager.BuildTurretOn(this);
        // ???? ????
        // GameObject turretToBuild = buildManager.GetTurretToBuild();
        // turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
        // ???????? ???? ????
    }

    //?????? ???????? ?????? hoverColor?? ????
    void OnMouseEnter()
    {
        if (!buildManager.CanBuild)
            return;

        if (buildManager.HasMoney) //???? ???????????? ?????? ????????
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor; //???????????? ?????? ??????
        }
    }

    //?????? ?????? ???? ??????????
    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
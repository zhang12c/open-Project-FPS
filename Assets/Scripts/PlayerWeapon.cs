using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class PlayerWeapon
{
     /*记录武器的基础属性*/
    /// <summary>
    /// 武器的名字
    /// </summary>
    public string name = "SM_Wep_Shotgun_01";
    /// <summary>
    /// 武器的伤害
    /// </summary>
    public float damamg = 50f;
    /// <summary>
    /// 武器的范围
    /// </summary>
    public float range = 200f;
}

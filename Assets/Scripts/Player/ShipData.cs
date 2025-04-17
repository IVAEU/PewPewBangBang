using UnityEngine;

[CreateAssetMenu(fileName = "ShipData", menuName = "Data/ShipData")]
public class ShipData : ScriptableObject
{
    [field:SerializeField] public string ShipName { get; private set; }
    [field:SerializeField] public int HealthPoint { get; private set; }
    [field:SerializeField] public int Speed { get; private set; }
    [field:SerializeField] public int AttackPower { get; private set; }
    [field:SerializeField] public int AttackSpeed { get; private set; }
    [field:SerializeField] public Sprite ShipSprite { get; private set; }
}

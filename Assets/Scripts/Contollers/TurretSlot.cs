using UnityEngine;

[System.Serializable]
public class TurretSlot
{
    public Vector2 position;
    public bool isOccupied;
    public GameObject occupyingTurretPrefab;
    public GameObject placedTurret; // Reference to the instantiated turret GameObject
}

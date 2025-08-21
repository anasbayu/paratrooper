using UnityEngine;

public class Enemy : MonoBehaviour
{
    [field: SerializeField] public int health { get; private set; }
    [field: SerializeField] public float speed { get; private set; }
    [field: SerializeField] public int scoreValue { get; private set; }

}

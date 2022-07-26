using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    [HideInInspector] public int HP;
    public int Speed;
    public int Coins;
    public float JumpForce;

    private void Start()
    {
        Coins = 0;
    }
}

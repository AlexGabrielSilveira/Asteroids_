using UnityEngine;

public class Pistol : Weapon
{
    public Pistol() : base(0.45f)
    {
    }

    void  Update()
    {
        Shoot();
    }
}
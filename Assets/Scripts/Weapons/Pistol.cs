using UnityEngine;

public class Pistol : Weapon
{
    public Pistol() : base(0.25f)
    {
    }

    void  Update()
    {
        Shoot();
    }
}
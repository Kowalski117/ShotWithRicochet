namespace Source.Scripts.Weapons
{
    public class Pistol : Weapon
    {
        public override void Shot()
        {
            Instantiate(Bullet, _shotPoint.position, _shotPoint.rotation);
        }
    }
}
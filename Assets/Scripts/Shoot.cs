using System.Linq;
using Assets.HeroEditor4D.Common.Scripts.CharacterScripts;
using Assets.HeroEditor4D.Common.Scripts.Enums;
using UnityEngine;

namespace Assets.HeroEditor4D.Common.Scripts.ExampleScripts
{
	/// <summary>
	/// An example of how to handle user input, play animations and move a character.
	/// </summary>
	public class Shoot : MonoBehaviour
	{
        public Character4D Character;
        public FirearmFxExample FirearmFx;
        private float bulletSpeed = 15f;
        public GameObject bulletPrefab;

        public void Start()
        {
            Debug.Log("Here2");
          
        }

        public void Update()
        {
            if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonDown(0)){
                ShootProjectile();
                ShowShootFx();
            }
        }

      
        public void ShootProjectile(){
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 direction = (Vector2)((mousePosition - transform.position));
            direction.Normalize ();

            // Creates the bullet locally
            GameObject bullet = (GameObject)Instantiate (
                                    bulletPrefab,
                                    GameObject.Find("WeaponFire").transform.position + (Vector3)( direction * 0.5f),
                                    Quaternion.identity);

            // Adds velocity to the bullet
            bullet.GetComponent<Rigidbody2D> ().velocity = direction * bulletSpeed;
        }
       

        private void ShowShootFx()
        {
            var firearm = Character.SpriteCollection.Firearm1H.SingleOrDefault(i => i.Sprites.Contains(Character.Parts[0].PrimaryWeapon))
                ?? Character.SpriteCollection.Firearm2H.SingleOrDefault(i => i.Sprites.Contains(Character.Parts[0].PrimaryWeapon));

            if (firearm != null)
            {
                FirearmFx.CreateFireMuzzle(firearm.Name, firearm.Collection);
            }
        }


	}
}
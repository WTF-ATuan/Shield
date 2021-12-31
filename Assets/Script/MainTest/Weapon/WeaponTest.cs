using NUnit.Framework;
using Script.Main.Weapon.Event;

namespace Script.MainTest.Weapon{
	public class WeaponTest{
		[Test]
		public void Create_Weapon_With_Default_Setting(){
			const int defaultMaxAmmoCount = 30;
			var weapon = new Main.Weapon.Entity.Weapon(defaultMaxAmmoCount);
			Assert.NotNull(weapon);
			var currentAmmoCount = weapon.CurrentAmmoCount;
			Assert.AreEqual(defaultMaxAmmoCount, currentAmmoCount);
		}

		[Test]
		public void Weapon_Fire_Enough_Bullet(){
			const int defaultMaxAmmoCount = 30;
			var weapon = new Main.Weapon.Entity.Weapon(defaultMaxAmmoCount);
			weapon.Fire();
			var currentAmmoCount = weapon.CurrentAmmoCount;
			Assert.AreEqual(defaultMaxAmmoCount - 1, currentAmmoCount);
			var weaponFiredEvents = weapon.GetEvent<WeaponFired>();
			var eventCount = weaponFiredEvents.Count;
			Assert.GreaterOrEqual(eventCount, 1);
		}

		[Test]
		public void Weapon_Fire_Not_Enough_Bullet(){
			const int defaultAmmoCount = 0;
			var weapon = new Main.Weapon.Entity.Weapon(defaultAmmoCount);
			weapon.Fire();
			Assert.AreEqual(defaultAmmoCount, weapon.CurrentAmmoCount);
			var weaponUnFiredEvents = weapon.GetEvent<WeaponUnFired>();
			var eventCount = weaponUnFiredEvents.Count;
			Assert.GreaterOrEqual(eventCount, 1);
		}
	}
}
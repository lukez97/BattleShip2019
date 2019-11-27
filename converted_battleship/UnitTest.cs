using System;
using System.Collections.Generic;
using NUnit.Framework;
namespace BattleShips
{
	[TestFixture ()]
	public class UnitTest
	{
		//done by Bong Siaw Zhen
		[Test ()]
		public void EasyMode ()
		{
			GameController.SetDifficulty (AIOption.Easy);
			GameController.StartGame ();
			Assert.IsInstanceOf<AIEasyPlayer> (GameController.ComputerPlayer);
		}
		[Test ()]
		public void MediumMode ()
		{
			GameController.SetDifficulty (AIOption.Medium);
			GameController.StartGame ();
			Assert.IsInstanceOf<AIMediumPlayer> (GameController.ComputerPlayer);
		}
		[Test ()]
		public void HardMode ()
		{
			GameController.SetDifficulty (AIOption.Hard);
			GameController.StartGame ();
			Assert.IsInstanceOf<AIHardPlayer> (GameController.ComputerPlayer);
		}

		//done by Hii Lu Teck
		[Test ()]
		public void TestDiscoveryController ()
		{
			//initalization
			Ship s1 = new Ship (ShipName.AircraftCarrier);
			Ship s2 = new Ship (ShipName.Battleship);
			Ship s3 = new Ship (ShipName.Destroyer);
			Ship s4 = new Ship (ShipName.Submarine);
			Ship s5 = new Ship (ShipName.Tug);

			Dictionary<ShipName, Ship> _Ships = new Dictionary<ShipName, Ship> ();
			SeaGrid s = new SeaGrid (_Ships);
			//add all type of ship to the _Ships
			foreach (ShipName name in Enum.GetValues (typeof (ShipName))) {
				if (name != ShipName.None) {
					_Ships.Add (name, new Ship (name));
				}
			}
			//deploy all ship 
			s.MoveShip (1, 1, ShipName.AircraftCarrier, Direction.LeftRight);
			s.MoveShip (2, 1, ShipName.Battleship, Direction.LeftRight);
			s.MoveShip (3, 1, ShipName.Destroyer, Direction.LeftRight);
			s.MoveShip (4, 1, ShipName.Submarine, Direction.LeftRight);
			s.MoveShip (5, 1, ShipName.Tug, Direction.LeftRight);
			//check all ship deployed
			Assert.IsTrue (s.AllDeployed);
		}

	}
}

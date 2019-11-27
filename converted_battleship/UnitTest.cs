using System;
using NUnit.Framework;
namespace BattleShips
{
	[TestFixture ()]
	public class UnitTest
	{
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
	}
}

﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using SwinGameSDK;

static class InstructionController
{
	private const int INSTRUCTION_LEFT = 0;

	private struct Instruction
	{
		public string name;
	}

	private static List<Instruction> _Instruction = new List<Instruction> ();

	private static void LoadInstruction ()
	{
		string filename = null;
		filename = SwinGame.PathToResource ("instruction.txt");

		StreamReader input = default (StreamReader);
		input = new StreamReader (filename);

		// Read in the # of instructions
		int numInstructions = 0;
		numInstructions = Convert.ToInt32 (input.ReadLine ());

		_Instruction.Clear ();

		int i;

		for (i = 1; i <= numInstructions; i++) {
			Instruction s = default (Instruction);
			string line = null;

			line = input.ReadLine ();

			s.name = line.Substring (0);
			_Instruction.Add (s);
		}
		input.Close ();
	}

	public static void DrawInstruction ()
	{
		const int INSTRUCTION_HEADING = 40;
		const int INSTRUCTION_TOP = 80;
		const int INSTRUCTION_GAP = 40;
		SwinGame.ClearScreen ();
		LoadInstruction ();
		SwinGame.DrawText ("Instruction", Color.Azure, GameResources.GameFont ("Instruction"), 325, INSTRUCTION_HEADING);

		// For all of the instruction
		int i;
		for (i = 0; i <= _Instruction.Count - 1; i++) {
			Instruction s = default (Instruction);

			s = _Instruction [i];

			if (i < 6)
				SwinGame.DrawText (s.name, Color.White, GameResources.GameFont ("Instruction"), INSTRUCTION_LEFT, INSTRUCTION_TOP + i * INSTRUCTION_GAP);
			else
				SwinGame.DrawText (s.name, Color.White, GameResources.GameFont ("Instruction"), INSTRUCTION_LEFT, INSTRUCTION_TOP + i * INSTRUCTION_GAP);
		}
	
	}


	public static void HandleInstructInput ()
	{
		if (SwinGame.MouseClicked (MouseButton.LeftButton) || SwinGame.KeyTyped (KeyCode.vk_ESCAPE) || SwinGame.KeyTyped (KeyCode.vk_RETURN)) {
			GameController.SwitchState (GameState.ViewingMainMenu);
		} 
	}
}
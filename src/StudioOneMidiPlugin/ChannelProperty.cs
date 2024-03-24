﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loupedeck.StudioOneMidiPlugin
{
	public class ChannelProperty
	{

		public enum BoolType
		{
			Select,
            Mute,
			Solo,
			Arm,
            Monitor
		}

		public static BitmapColor selectionColor = new BitmapColor(52, 155, 235);

		public static BitmapColor[] boolPropertyColor =
		{
             new BitmapColor(60, 60, 60), // Select
			 new BitmapColor(200, 0, 0), // Mute
			 new BitmapColor(122, 88, 23), // Solo
			 new BitmapColor(103, 52, 200), // Arm
			 new BitmapColor(25, 52, 235), // Monitor
		};

		public static int[] boolPropertyMackieNote = { 24, 16, 8, 0, 120};

		public static string[] boolPropertyName = { "Select", "Mute", "Solo", "Rec", "Mon" };
		public static string[] boolPropertyLetter = { "-", "M", "S", "R", "M" };

	}
}

﻿using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Core;

namespace Loupedeck.StudioOneMidiPlugin
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    public class MackieChannelData
	{

		public int ChannelID;
		public float Value = 0;
		public string TrackName = "";
        public string TrackValue = "";

		public bool[] BoolProperty = new bool[(int)Enum.GetNames(typeof(ChannelProperty.BoolType)).Length];

		public bool IsMasterChannel = false;

		private StudioOneMidiPlugin plugin;


        public bool Selected
        {
            get => BoolProperty[(int)ChannelProperty.BoolType.Select];
            set
            {
                BoolProperty[(int)ChannelProperty.BoolType.Select] = value;
            }
        }

        public bool Muted
        {
            get => BoolProperty[(int)ChannelProperty.BoolType.Mute];
            set
            {
                BoolProperty[(int)ChannelProperty.BoolType.Mute] = value;
            }
        }

        public bool Armed
		{
			get => BoolProperty[(int)ChannelProperty.BoolType.Arm];
			set
			{
				BoolProperty[(int)ChannelProperty.BoolType.Arm] = value;
			}
		}

		public bool Solo
		{
			get => BoolProperty[(int)ChannelProperty.BoolType.Solo];
			set
			{
				BoolProperty[(int)ChannelProperty.BoolType.Solo] = value;
			}
		}

        public bool Monitor
        {
            get => BoolProperty[(int)ChannelProperty.BoolType.Monitor];
            set
            {
                BoolProperty[(int)ChannelProperty.BoolType.Monitor] = value;
            }
        }
        
        public MackieChannelData(StudioOneMidiPlugin plugin, int channelID)
		{
			this.plugin = plugin;

			ChannelID = channelID;
//			IsMasterChannel = channelID == StudioOneMidiPlugin.MackieChannelCount;
//
//			if (IsMasterChannel)
//				TrackName = "Master";
//			else
				TrackName = $"Channel {channelID + 1}";
		}

		public void EmitVolumeUpdate()
		{
			var e = new PitchBendEvent();
			e.PitchValue = (ushort)(Value * 16383);
			e.Channel = (FourBitNumber)ChannelID;
			plugin.mackieMidiOut.SendEvent(e);

			plugin.EmitMackieChannelDataChanged(this);
		}

		public void EmitBoolPropertyPress(ChannelProperty.BoolType type)
		{
			var e = new NoteOnEvent();
			e.NoteNumber = (SevenBitNumber)(ChannelProperty.boolPropertyMackieNote[(int)type] + ChannelID);
			e.Velocity = (SevenBitNumber)(127);
			plugin.mackieMidiOut.SendEvent(e);

			var e2 = new NoteOffEvent();
			e2.NoteNumber = e.NoteNumber;
			e2.Velocity = e.Velocity;
			plugin.mackieMidiOut.SendEvent(e2);
		}

	}
}

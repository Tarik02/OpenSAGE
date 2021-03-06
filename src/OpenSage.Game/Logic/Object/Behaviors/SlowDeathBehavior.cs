﻿using System.Collections.Generic;
using OpenSage.Data.Ini;
using OpenSage.Data.Ini.Parser;

namespace OpenSage.Logic.Object
{
    public class SlowDeathBehaviorModuleData : UpdateModuleData
    {
        internal static SlowDeathBehaviorModuleData Parse(IniParser parser) => parser.ParseBlock(FieldParseTable);

        internal static readonly IniParseTable<SlowDeathBehaviorModuleData> FieldParseTable = new IniParseTable<SlowDeathBehaviorModuleData>
        {
            { "DeathTypes", (parser, x) => x.DeathTypes = parser.ParseEnumBitArray<DeathType>() },
            { "RequiredStatus", (parser, x) => x.RequiredStatus = parser.ParseEnumBitArray<ObjectStatus>() },
            { "ExemptStatus", (parser, x) => x.ExemptStatus = parser.ParseEnumBitArray<ObjectStatus>() },
            { "ProbabilityModifier", (parser, x) => x.ProbabilityModifier = parser.ParseInteger() },
            { "ModifierBonusPerOverkillPercent", (parser, x) => x.ModifierBonusPerOverkillPercent = parser.ParsePercentage() },
            { "SinkRate", (parser, x) => x.SinkRate = parser.ParseFloat() },
            { "SinkDelay", (parser, x) => x.SinkDelay = parser.ParseInteger() },
            { "SinkDelayVariance", (parser, x) => x.SinkDelayVariance = parser.ParseInteger() },
            { "DestructionDelay", (parser, x) => x.DestructionDelay = parser.ParseInteger() },
            { "DestructionDelayVariance", (parser, x) => x.DestructionDelayVariance = parser.ParseInteger() },
            { "FlingForce", (parser, x) => x.FlingForce = parser.ParseInteger() },
            { "FlingForceVariance", (parser, x) => x.FlingForceVariance = parser.ParseInteger() },
            { "FlingPitch", (parser, x) => x.FlingPitch = parser.ParseInteger() },
            { "FlingPitchVariance", (parser, x) => x.FlingPitchVariance = parser.ParseInteger() },

            { "OCL", (parser, x) => x.OCLs[parser.ParseEnum<SlowDeathPhase>()] = parser.ParseAssetReference() },
            { "FX", (parser, x) => x.FXs[parser.ParseEnum<SlowDeathPhase>()] = parser.ParseAssetReference() },
            { "Weapon", (parser, x) => x.Weapons[parser.ParseEnum<SlowDeathPhase>()] = parser.ParseAssetReference() },
        };

        public BitArray<DeathType> DeathTypes { get; private set; }
        public BitArray<ObjectStatus> RequiredStatus { get; private set; }
        public BitArray<ObjectStatus> ExemptStatus { get; private set; }
        public int ProbabilityModifier { get; private set; }
        public float ModifierBonusPerOverkillPercent { get; private set; }
        public float SinkRate { get; private set; }
        public int SinkDelay { get; private set; }
        public int SinkDelayVariance { get; private set; }
        public int DestructionDelay { get; private set; }
        public int DestructionDelayVariance { get; private set; }
        public int FlingForce { get; private set; }
        public int FlingForceVariance { get; private set; }
        public int FlingPitch { get; private set; }
        public int FlingPitchVariance { get; private set; }

        public Dictionary<SlowDeathPhase, string> OCLs { get; } = new Dictionary<SlowDeathPhase, string>();
        public Dictionary<SlowDeathPhase, string> FXs { get; } = new Dictionary<SlowDeathPhase, string>();
        public Dictionary<SlowDeathPhase, string> Weapons { get; } = new Dictionary<SlowDeathPhase, string>();
    }

    public enum SlowDeathPhase
    {
        [IniEnum("INITIAL")]
        Initial,

        [IniEnum("MIDPOINT")]
        Midpoint,

        [IniEnum("FINAL")]
        Final
    }
}

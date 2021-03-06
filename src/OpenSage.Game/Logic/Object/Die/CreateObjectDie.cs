﻿using OpenSage.Data.Ini;
using OpenSage.Data.Ini.Parser;

namespace OpenSage.Logic.Object
{
    public sealed class CreateObjectDieModuleData : DieModuleData
    {
        internal static CreateObjectDieModuleData Parse(IniParser parser) => parser.ParseBlock(FieldParseTable);

        private static new readonly IniParseTable<CreateObjectDieModuleData> FieldParseTable = DieModuleData.FieldParseTable
            .Concat(new IniParseTable<CreateObjectDieModuleData>
            {
                { "CreationList", (parser, x) => x.CreationList = parser.ParseAssetReference() },
                { "TransferPreviousHealth", (parser, x) => x.TransferPreviousHealth = parser.ParseBoolean() }
            });

        public string CreationList { get; private set; }

        [AddedIn(SageGame.CncGeneralsZeroHour)]
        public bool TransferPreviousHealth { get; private set; }
    }
}

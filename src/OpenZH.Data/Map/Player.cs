﻿using System.IO;
using OpenZH.Data.Utilities.Extensions;

namespace OpenZH.Data.Map
{
    public sealed class Player
    {
        public string Name { get; private set; }
        public bool IsHuman { get; private set; }
        public string DisplayName { get; private set; }
        public string Faction { get; private set; }
        public string Allies { get; private set; }
        public string Enemies { get; private set; }
        public MapColorArgb? Color { get; private set; }

        public BuildListItem[] BuildList { get; private set; }

        public static Player Parse(BinaryReader reader, MapParseContext context)
        {
            var result = new Player();

            Asset.ParseProperties(reader, context, propertyName =>
            {
                switch (propertyName)
                {
                    case "playerName":
                        result.Name = reader.ReadUInt16PrefixedAsciiString();
                        break;

                    case "playerIsHuman":
                        result.IsHuman = reader.ReadBoolean();
                        break;

                    case "playerDisplayName":
                        result.DisplayName = reader.ReadUInt16PrefixedUnicodeString();
                        break;

                    case "playerFaction":
                        result.Faction = reader.ReadUInt16PrefixedAsciiString();
                        break;

                    case "playerAllies":
                        result.Allies = reader.ReadUInt16PrefixedAsciiString();
                        break;

                    case "playerEnemies":
                        result.Enemies = reader.ReadUInt16PrefixedAsciiString();
                        break;

                    case "playerColor":
                        result.Color = MapColorArgb.Parse(reader);
                        break;

                    default:
                        throw new InvalidDataException($"Unexpected property name: {propertyName}");
                }
            });

            var numBuildListItems = reader.ReadUInt32();
            var buildListItems = new BuildListItem[numBuildListItems];

            for (var i = 0; i < numBuildListItems; i++)
            {
                buildListItems[i] = BuildListItem.Parse(reader);
            }

            return result;
        }
    }
}
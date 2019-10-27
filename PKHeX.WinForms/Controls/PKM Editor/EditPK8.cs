﻿using System;
using PKHeX.Core;

namespace PKHeX.WinForms.Controls
{
    public partial class PKMEditor
    {
        private void PopulateFieldsPK8()
        {
            if (!(Entity is PK8 pk8))
                throw new FormatException(nameof(Entity));

            LoadMisc1(pk8);
            LoadMisc2(pk8);
            LoadMisc3(pk8);
            LoadMisc4(pk8);
            LoadMisc6(pk8);
            SizeCP.LoadPKM(pk8);

            LoadPartyStats(pk8);
            UpdateStats();
        }

        private PK8 PreparePK8()
        {
            if (!(Entity is PK8 pk8))
                throw new FormatException(nameof(Entity));

            CheckTransferPIDValid();
            SaveMisc1(pk8);
            SaveMisc2(pk8);
            SaveMisc3(pk8);
            SaveMisc4(pk8);
            SaveMisc6(pk8);

            // Toss in Party Stats
            SavePartyStats(pk8);

            pk8.FixMoves();
            pk8.FixRelearn();
            if (ModifyPKM)
                pk8.FixMemories();
            pk8.RefreshChecksum();
            return pk8;
        }
    }
}

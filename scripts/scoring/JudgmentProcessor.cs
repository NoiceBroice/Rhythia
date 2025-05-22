using System;
using System.Collections;
using System.Collections.Generic;
using Rhythia.Maps;
using Rhythia.Maps.Objects;
using Rhythia.Rulesets.Mods;

namespace Rhythia.Scoring;

public class JudgementProcessor
{
    private List<IApplicableMod> Mods;
    private IMap Map;

    public JudgementProcessor(IMap map, List<IApplicableMod>? mods = null)
    {
        Mods = mods ?? [];
        Map = map;
    }
}
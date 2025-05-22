using System.Collections;
using System.Collections.Generic;
using Rhythia.Maps;

namespace Rhythia.Scoring;

public class ScoreProcessor
{
    private IMap Map;
    private IList<IApplicableMod> Mods;

    public ScoreProcessor(IMap map, IList<IApplicableMod> mods)
    {
        Map = map;
        Mods = mods;
    }
}
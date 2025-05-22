using System;
using Rhythia.Scoring;

namespace Rhythia.Rulesets;

public class Ruleset : IRulesetInfo
{
    public string Name => throw new System.NotImplementedException();

    public string ShortName => throw new System.NotImplementedException();

    public JudgementProcessor CreateJudgementProcessor()
    {
        throw new NotImplementedException();
    }

    public ScoreProcessor CreateScoreProcessor()
    {
        throw new NotImplementedException();
    }

    public HealthProcessor CreateHealthProcessor()
    {
        throw new NotImplementedException();
    }
}
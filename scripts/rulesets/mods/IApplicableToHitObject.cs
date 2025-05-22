using Rhythia.Maps.Objects;

namespace Rhythia.Rulesets.Mods;

public interface IApplicableToHitObject : IApplicableMod
{
    void ApplyToHitObject(HitObject hitObject);
}
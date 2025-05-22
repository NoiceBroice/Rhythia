using Godot;
using Rhythia.Maps.Objects;
using Rhythia.Rulesets.Mods;

public class ExtendedMod : IApplicableMod, IApplicableToHitObject, IApplicableToGrid
{
    public override string Acronym => "EX";

    public override string Name => "Extended";

    public override string Description => "Extends notes and grid";

    public void ApplyToGrid(MeshInstance3D grid)
    {
        grid.Scale = grid.Scale * 1.5f;
    }

    public void ApplyToHitObject(HitObject hitObject)
    {
        var note = (Note)hitObject;

        note.Position = note.Position * 1.5f;
    }
}
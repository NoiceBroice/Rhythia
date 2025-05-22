using Godot;
using Rhythia.Rulesets.Mods;

public interface IApplicableToGrid : IApplicableMod
{
    void ApplyToGrid(MeshInstance3D grid);
}
extends Node3D

## Attempt to make all UI be handled through gdscript
## only UI logic should be used here ( Following MVVM pattern )

@export var camera: Camera3D
@export var grid: MeshInstance3D
@export var hud: Node3D

@export var player : Node

var cursorImage: Image


func _ready() -> void:
    var skin: Node = RhythiaGame.SelectedSkin

    cursorImage = skin.Cursor

    player.CursorEventHandler += _move_cursor

func _move_cursor(_position: Vector2):
    pass
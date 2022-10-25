extends Collectable

class_name CollectableGemcoin

func is_type(type): return type == C_ClassType.COLLECTABLE_GEMCOIN or .is_type(type)
func    get_type(): return C_ClassType.COLLECTABLE_GEMCOIN

export(int) var value = 1

func _init():
	config = load("res://HappyFall/Objects/Collectable/Gemstone/CollectableConfigGemcoin.gd").new()
	print(config)
	
func _on_Area_area_entered(area:Area):
	if area.get_parent().is_type("Player"):
		queue_free()

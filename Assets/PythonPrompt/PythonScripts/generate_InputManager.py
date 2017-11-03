import clr
clr.AddReferenceByPartialName('UnityEngine')

import UnityEngine

import sys
sys.path.append(UnityEngine.Application.dataPath + '/../Lib')


# Get InputManager Axes
class Axis:
    class AxisSerializedProperty:
        def __init__(self, property_type, serialized_property):
            self._property_type = property_type
            self._property = serialized_property

        def set_value(self, value):
            if self._property_type == 'stringValue':
                self._property.stringValue = value
            elif self._property_type == 'intValue':
                self._property.intValue = value
            elif self._property_type == 'floatValue':
                self._property.floatValue = value
            elif self._property_type == 'boolValue':
                self._property.boolValue = value

        def value(self):
            if self._property_type == 'stringValue':
                return self._property.stringValue
            elif self._property_type == 'intValue':
                return self._property.intValue
            elif self._property_type == 'floatValue':
                return self._property.floatValue
            elif self._property_type == 'boolValue':
                return self._property.boolValue


    def __init__(self, axis):
        self._name = Axis.AxisSerializedProperty('stringValue', axis.FindPropertyRelative('m_Name'))
        self._descriptive_name = Axis.AxisSerializedProperty('stringValue', axis.FindPropertyRelative('descriptiveName'))
        self._descriptive_negative_name = Axis.AxisSerializedProperty('stringValue', axis.FindPropertyRelative('descriptiveNegativeName'))
        self._negative_button = Axis.AxisSerializedProperty('stringValue', axis.FindPropertyRelative('negativeButton'))
        self._positive_button = Axis.AxisSerializedProperty('stringValue', axis.FindPropertyRelative('positiveButton'))
        self._alt_negative_button = Axis.AxisSerializedProperty('stringValue', axis.FindPropertyRelative('altNegativeButton'))
        self._alt_positive_button = Axis.AxisSerializedProperty('stringValue', axis.FindPropertyRelative('altPositiveButton'))

        self._gravity = Axis.AxisSerializedProperty('floatValue', axis.FindPropertyRelative('gravity'))
        self._dead = Axis.AxisSerializedProperty('floatValue', axis.FindPropertyRelative('dead'))
        self._sensitivity = Axis.AxisSerializedProperty('floatValue', axis.FindPropertyRelative('sensitivity'))
        self._snap = Axis.AxisSerializedProperty('boolValue', axis.FindPropertyRelative('snap'))
        self._invert = Axis.AxisSerializedProperty('boolValue', axis.FindPropertyRelative('invert'))
        self._type = Axis.AxisSerializedProperty('intValue', axis.FindPropertyRelative('type'))
        self._axis = Axis.AxisSerializedProperty('intValue', axis.FindPropertyRelative('axis'))
        self._joy_num = Axis.AxisSerializedProperty('intValue', axis.FindPropertyRelative('joyNum'))


inputManager = SerializedObject(AssetDatabase.LoadAllAssetsAtPath('ProjectSettings/InputManager.asset')[0])
inputAxes = inputManager.FindProperty('m_Axes')


def change_name(name):
    axis = Axis(inputAxes.GetArrayElementAtIndex(29))
    axis._name.set_value(name)


def clear_all_axes():
    inputAxes.ClearArray()
    apply()


def apply():
    # write to InputManager.asset
    inputManager.ApplyModifiedProperties()

def add_axis(axis):
    inputAxes.arraySize += 1
    apply()
    
    tail = Axis(inputAxes.GetArrayElementAtIndex(inputAxes.arraySize - 1))
    tail._name.set_value(axis._name.value().replace('Player1', 'Player2'))
    tail._negative_button.set_value(axis._negative_button.value())
    tail._positive_button.set_value(axis._positive_button.value())
    tail._alt_negative_button.set_value(axis._alt_negative_button.value())
    tail._alt_positive_button.set_value(axis._alt_positive_button.value())
    tail._gravity.set_value(axis._gravity.value())
    tail._dead.set_value(axis._dead.value())
    tail._snap.set_value(axis._snap.value())
    tail._invert.set_value(axis._invert.value())
    tail._type.set_value(axis._type.value())
    tail._axis.set_value(axis._axis.value())
    tail._joy_num.set_value(axis._joy_num.value())

    apply()    
    

def copy_to_tail(axes):
    for axis in axes:
        add_axis(Axis(axis))

axes = [inputAxes.GetArrayElementAtIndex(i) for i in range(0, 4)]
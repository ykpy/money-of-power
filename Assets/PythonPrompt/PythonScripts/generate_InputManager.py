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

    def __init__(self, axis):
        self._name = Axis.AxisSerializedProperty('stringValue', axis.FindPropertyRelative('m_Name'))
        # self._name = axis.FindPropertyRelative('m_Name').stringValue
        # self.description_name = axis.FindPropertyRelative('m_DescriptionName').stringValue
        # self.axis = axis.FindPropertyRelative('m_Axis').intValue

inputManager = SerializedObject(AssetDatabase.LoadAllAssetsAtPath('ProjectSettings/InputManager.asset')[0])
inputAxes = inputManager.FindProperty('m_Axes')
# for i in range(inputAxes.arraySize):
    # axis = Axis(inputAxes.GetArrayElementAtIndex(i))

axis = Axis(inputAxes.GetArrayElementAtIndex(29))
axis._name.set_value('hey')

inputManager.ApplyModifiedProperties()
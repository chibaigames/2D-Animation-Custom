using System;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace UnityEditor.U2D.Animation
{
    internal class BoneInspectorPanel : VisualElement
    {
        public class BoneInspectorPanelFactory : UxmlFactory<BoneInspectorPanel, BoneInspectorPanelUxmlTraits> {}
        public class BoneInspectorPanelUxmlTraits : UxmlTraits {}
        public event Action<BoneCache, int> onBoneDepthChanged = (bone, depth) => {};
        public event Action<BoneCache, string> onBoneNameChanged = (bone, name) => {};

        // CUSTOM
        #region Chibai
        public event Action<BoneCache, Vector3> onBonePositionChanged = (bone, position) => { };
        public event Action<BoneCache, Quaternion> onBoneRotationChanged = (bone, rotation) => { };
        public event Action<BoneCache, float> onBoneLengthChanged = (bone, length) => { };
        #endregion

        private TextField m_BoneNameField;
        private IntegerField m_BoneDepthField;

        // CUSTOM
        #region Chibai
        private Vector3Field m_BonePositionField;
        private Vector3Field m_BoneRotationField;
        private FloatField m_BoneLengthField;
        #endregion

        public string boneName
        {
            get { return m_BoneNameField.value; }
            set { m_BoneNameField.value = value; }
        }

        public BoneCache target { get; set; }
        
        public int boneDepth
        {
            get { return m_BoneDepthField.value; }
            set { m_BoneDepthField.value = value; }
        }

        // CUSTOM
        #region Chibai
        public Vector3 bonePosition
        {
            get { return m_BonePositionField.value; }
            set { m_BonePositionField.value = value; }
        }

        public Quaternion boneRotation
        {
            get
            {
                // TODO: Check if euler and euler angles convert the same way back and forth.
                Vector3 toQuat = m_BoneRotationField.value;
                return Quaternion.Euler(toQuat.x, toQuat.y, toQuat.z);
            }
            set { m_BoneRotationField.value = value.eulerAngles; }
        }

        public float boneLength
        {
            get { return m_BoneLengthField.value; }
            set { m_BoneLengthField.value = value; }
        }
        #endregion

        public BoneInspectorPanel()
        {
            styleSheets.Add(ResourceLoader.Load<StyleSheet>("SkinningModule/BoneInspectorPanelStyle.uss"));

            RegisterCallback<MouseDownEvent>((e) => { e.StopPropagation(); });
            RegisterCallback<MouseUpEvent>((e) => { e.StopPropagation(); });
        }

        public void BindElements()
        {
            m_BoneNameField = this.Q<TextField>("BoneNameField");
            m_BoneDepthField = this.Q<IntegerField>("BoneDepthField");
            m_BoneNameField.RegisterCallback<FocusOutEvent>(BoneNameFocusChanged);
            m_BoneDepthField.RegisterCallback<FocusOutEvent>(BoneDepthFocusChanged);

            // CUSTOM
            #region Chibai
            m_BonePositionField = this.Q<Vector3Field>("BonePositionField");
            m_BoneRotationField = this.Q<Vector3Field>("BoneRotationField");
            m_BoneLengthField = this.Q<FloatField>("BoneLengthField");
            m_BonePositionField.RegisterCallback<FocusOutEvent>(BonePositionFocusChanged);
            m_BoneRotationField.RegisterCallback<FocusOutEvent>(BoneRotationFocusChanged);
            m_BoneLengthField.RegisterCallback<FocusOutEvent>(BoneLengthFocusChanged);
            #endregion
        }

        private void BoneNameFocusChanged(FocusOutEvent evt)
        {
            onBoneNameChanged(target, boneName);
        }

        private void BoneDepthFocusChanged(FocusOutEvent evt)
        {
            onBoneDepthChanged(target, boneDepth);
        }
        // CUSTOM
        #region Chibai
        private void BonePositionFocusChanged(FocusOutEvent evt)
        {
            onBonePositionChanged(target, bonePosition);
        }

        private void BoneRotationFocusChanged(FocusOutEvent evt)
        {
            onBoneRotationChanged(target, boneRotation);
        }

        private void BoneLengthFocusChanged(FocusOutEvent evt)
        {
            onBoneLengthChanged(target, boneLength);
        }
        #endregion

        public void HidePanel()
        {
            // We are hidding the panel, sent any unchanged value
            this.SetHiddenFromLayout(true);
            onBoneNameChanged(target, boneName);
            onBoneDepthChanged(target, boneDepth);
            // CUSTOM
            #region Chibai
            onBonePositionChanged(target, bonePosition);
            onBoneRotationChanged(target, boneRotation);
            onBoneLengthChanged(target, boneLength);
            #endregion
        }
        public static BoneInspectorPanel GenerateFromUXML()
        {
            var visualTree = ResourceLoader.Load<VisualTreeAsset>("SkinningModule/BoneInspectorPanel.uxml");
            var clone = visualTree.CloneTree().Q<BoneInspectorPanel>("BoneInspectorPanel");
            clone.BindElements();
            return clone;
        }
    }
}

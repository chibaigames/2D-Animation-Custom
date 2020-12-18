using System;
using UnityEditor.U2D.Layout;
// CUSTOM
using UnityEngine;

namespace UnityEditor.U2D.Animation
{
    internal class SkeletonToolView
    {
        private BoneInspectorPanel m_BoneInspectorPanel;

        public event Action<BoneCache, string> onBoneNameChanged = (b, s) => {};
        public event Action<BoneCache, int> onBoneDepthChanged = (b, i) => {};

        // CUSTOM
        #region Chibai
        public event Action<BoneCache, Vector3> onBonePositionChanged = (b, p) => { };
        public event Action<BoneCache, Quaternion> onBoneRotationChanged = (b, r) => { };
        public event Action<BoneCache, float> onBoneLengthChanged = (b, l) => { };
        #endregion

        public SkeletonToolView()
        {
            m_BoneInspectorPanel = BoneInspectorPanel.GenerateFromUXML();
            m_BoneInspectorPanel.onBoneNameChanged += (b, n) =>  onBoneNameChanged(b, n);
            m_BoneInspectorPanel.onBoneDepthChanged += (b, d) => onBoneDepthChanged(b, d);

            // CUSTOM
            #region Chibai
            m_BoneInspectorPanel.onBonePositionChanged += (b, p) => onBonePositionChanged(b, p);
            m_BoneInspectorPanel.onBoneRotationChanged += (b, r) => onBoneRotationChanged(b, r);
            m_BoneInspectorPanel.onBoneLengthChanged += (b, l) => onBoneLengthChanged(b, l);
            #endregion

            Hide();
        }
        
        public void Initialize(LayoutOverlay layout)
        {
            layout.rightOverlay.Add(m_BoneInspectorPanel);
        }

        public void Show(BoneCache target)
        {
            m_BoneInspectorPanel.target = target;
            m_BoneInspectorPanel.SetHiddenFromLayout(false);
        }

        public BoneCache target => m_BoneInspectorPanel.target;

        public void Hide()
        {
            m_BoneInspectorPanel.HidePanel();
            m_BoneInspectorPanel.target = null;
        }

        // CUSTOM
        public void Update(string name, int depth, Vector3 position, Quaternion rotation, float length)
        {
            m_BoneInspectorPanel.boneName = name;
            m_BoneInspectorPanel.boneDepth = depth;
            // CUSTOM
            #region Chibai
            m_BoneInspectorPanel.bonePosition = position;
            m_BoneInspectorPanel.boneRotation = rotation;
            m_BoneInspectorPanel.boneLength = length;
            #endregion
        }
    }
}

This version is a custom version of Unity's 2D Animation Package. It supports precise position rotation and length of bones in the Skinning Editor. I added this feature because it is a hassle to click to place bones and click again to determine the length. It is useless for anyone trying to create characters that are symmetrical as it is nearly impossible to click precisely at two different locations. This fixes that problem by allowing bones to be edited using Vector3 and Quaternions to determine the exact placement of individual bones. See the image: "EXAMPLE_USAGE.png" to see what it looks like.

Note that this version of 2D Animation is for 5.0.3, but you can replicate the code for older versions by looking at the files written below. There will be markings with my name or the word CUSTOM in a comment which dictates that you only need to add these lines. In the .uss files, I only change the values of some of the window sizes, namely the one in BoneInspectorPanelStyle.uss as it displays the input fields for position, rotation and length and needed to be larger.

- Files Changed:
  - SkinningModule.cs
  - BoneInspectorPanel.cs
  - SkinningEvents.cs
  - SkeletonToolView.cs
  - SkeletonTool.cs
  - SkinningCache.cs
  - TextContent.cs
  - LayoutOverlay.cs
  - VisibilityTool.cs
  - BoneInspectorPanelSyle.uss
  - LayoutOverlayStyle.uss
  - BoneInspectorPanel.uxml

- How to Install: 
  1. Go to Unity's Package Manager under the Window tab.
  2. Click the plus symbol in the top left.
  3. Click add package from git URL
  4. Paste this: https://github.com/chibaigames/2D-Animation-Custom.git#upm
  5. Click Add.
Voila, you now have precise bone placement in the skinning editor.

Original README below.

2D Character Animation

Editor tools and runtime scripts to support the authoring of 2D Animated Characters.  

Editor Tooling
- Skinning Editor
  - Available through Sprite Editor Window module
  - Bone tools allow creation of bind poses easily. Supports flexible setup of complex hierarchy.
  - Mesh tools allow auto mesh tesselation or manual tesselation
  - Weight tools allow auto weight calculation and weight painting


Runtime Support
- SpriteSkin deformation
- 2D IK

using System;
using UnityEngine;

namespace VoodooPackages.Tool.VST
{
    public static class EditorGUIHelper
    {
        public static Rect AlignRect(Rect rect, GUIStyle style, SpriteAlignment spriteAlignment)
        {
            float width = style.normal.scaledBackgrounds[0].width/(float)2;
            float height = style.normal.scaledBackgrounds[0].height/(float)2;

            switch (spriteAlignment)
            {
                case SpriteAlignment.Center:
                    rect.position = new Vector2(rect.position.x + (rect.width - width)/2, rect.position.y + (rect.height - height)/2);
                    break;
                case SpriteAlignment.TopLeft:
                    rect.position = new Vector2(rect.position.x, rect.position.y);
                    break;
                case SpriteAlignment.TopCenter:
                    rect.position = new Vector2(rect.position.x + (rect.width - width)/2,rect.position.y);
                    break;
                case SpriteAlignment.TopRight:
                    rect.position = new Vector2(rect.position.x + rect.width - width, rect.position.y);
                    break;
                case SpriteAlignment.LeftCenter:
                    rect.position = new Vector2(rect.position.x, rect.position.y + (rect.height - height)/2);
                    break;
                case SpriteAlignment.RightCenter:
                    rect.position = new Vector2(rect.position.x + rect.width - width, rect.position.y + (rect.height - height)/2);
                    break;
                case SpriteAlignment.BottomLeft:
                    rect.position = new Vector2(rect.position.x, rect.position.y + rect.height - height);
                    break;
                case SpriteAlignment.BottomCenter:
                    rect.position = new Vector2(rect.position.x + (rect.width - width)/2, rect.position.y + rect.height - height);
                    break;
                case SpriteAlignment.BottomRight:
                    rect.position = new Vector2(rect.position.x + rect.width - width, rect.position.y + rect.height - height);
                    break;
                case SpriteAlignment.Custom:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(spriteAlignment), spriteAlignment, null);
            }
            
            rect.height = height;
            rect.width = width;
            
            return rect;
        }
        
        public static void ShowPackagesButtons(Rect rect, IDownloadable item)
        {
            if (item.VersionStatus == VersionState.Invalid)
            {
                return;
            }
            
            rect.position = new Vector2(rect.x,rect.y+2);
            rect.height -= 2;

            if (item.VersionStatus != VersionState.NotPresent)
            {
	            if (item.Name != "VoodooStore")
                {
                    DisplayButton(rect, ContentHelper.VSTRed, GUI.skin.button, SpriteAlignment.LeftCenter, ContentHelper.UIcross, () => RemovePackage(item));
                }

	            if (item.VersionStatus == VersionState.Manually)
                {
                    DisplayButton(rect, ContentHelper.VSTOrange, GUI.skin.button, SpriteAlignment.RightCenter, ContentHelper.UIManual, () => DownloadPackage(item));
                }
                else if (item.VersionStatus == VersionState.OutDated)
                {
                    DisplayButton(rect, ContentHelper.VSTOrange, GUI.skin.button, SpriteAlignment.RightCenter, ContentHelper.UIrefresh, () => DownloadPackage(item));
                }
                else
                {
                    DisplayButton(rect, ContentHelper.VSTGreen, GUI.skin.button, SpriteAlignment.RightCenter, ContentHelper.UIvalidate, null);
                }
            }
            else
            {
                DisplayButton(rect, Color.white, GUI.skin.button, SpriteAlignment.RightCenter, ContentHelper.UIdownload, () => DownloadPackage(item));
            }
        }
        
        public static void ShowPackagesButtons(IDownloadable item)
        {
            if (item.VersionStatus == VersionState.Invalid)
            {
                return;
            }

            if (item.VersionStatus != VersionState.NotPresent)
            {
                if (item.Name != "VoodooStore")
                {
                    DisplayButton(ContentHelper.VSTRed, GUI.skin.box, ContentHelper.UIcross, () => RemovePackage(item), GUILayout.Height(50), GUILayout.Width(50));
                }
                else
                {
                    GUILayout.Space(16);
                }

                if (item.VersionStatus == VersionState.Manually)
                {
                    DisplayButton(ContentHelper.VSTOrange, GUI.skin.box, ContentHelper.UIManual, () => DownloadPackage(item), GUILayout.Height(50), GUILayout.Width(50));

                }
                else if (item.VersionStatus == VersionState.OutDated)
                {
                    DisplayButton(ContentHelper.VSTOrange, GUI.skin.box, ContentHelper.UIrefresh, () => DownloadPackage(item), GUILayout.Height(50), GUILayout.Width(50));

                }
                else
                {
                    GUIStyle style = new GUIStyle(GUI.skin.box) {normal = {background = Texture2D.blackTexture}};
                    DisplayButton(ContentHelper.VSTGreen, style, ContentHelper.UIvalidate, null, GUILayout.Height(50), GUILayout.Width(50));
                }
            }
            else
            {
                DisplayButton(Color.white, GUI.skin.box, ContentHelper.UIdownload, () => DownloadPackage(item), GUILayout.Height(50), GUILayout.Width(50));
            }
        }

        private static void DisplayButton(Rect rect, Color contentColor, GUIStyle style, SpriteAlignment alignment, Texture2D icon, Action action)
        {
            GUI.contentColor = contentColor;
            Rect buttonRect = AlignRect(rect, style, alignment);
            if (action == null)
            {
                GUI.Label(buttonRect, icon, GUIStyle.none);
            }
            else
            {
                if (GUI.Button(buttonRect, icon, GUIStyle.none))
                {
                    action.Invoke();
                }
            }
            GUI.contentColor = Color.white;
        }

        private static void DisplayButton(Color contentColor, GUIStyle style, Texture2D icon, Action action, params GUILayoutOption[] options )
        {
            GUI.contentColor = contentColor;
            if (action == null)
            {
                GUILayout.Label(icon, style, options);
            }
            else
            {
                if (GUILayout.Button(icon, style, options))
                {
                   action.Invoke();
                }
            }
            GUI.contentColor = Color.white;
        }

        private static void RemovePackage(IDownloadable item)
        {
            PackageComposition preset = new PackagePreset();
            item.FillUses(ref preset);
            DownloadProcessor.UninstallProcess(preset.Content, true);
        }

        private static void DownloadPackage(IDownloadable item)
        {
            PackageComposition preset = new PackagePreset();
            item.FillDependencies(ref preset);
            DownloadProcessor.DownloadPackages(preset.Content);
        }
    }
}
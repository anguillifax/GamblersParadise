using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace GameJam
{
	internal class AssetPreprocessor : AssetPostprocessor
	{
		private TextureImporter importer;
		private TextureImporterSettings settings;

		private void ProcessPortrait()
		{
			settings.spriteAlignment = (int)SpriteAlignment.BottomCenter;
		}

		private void OnPreprocessTexture()
		{
			if (!assetPath.Contains("Assets")) return;

			importer = (TextureImporter)assetImporter;
			settings = new TextureImporterSettings();
			importer.ReadTextureSettings(settings);

			if (assetPath.Contains("Resources/Portraits")) ProcessPortrait();

			importer.SetTextureSettings(settings);
		}
	}
}
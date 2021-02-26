using System;
using System.Linq;
using System.Reflection;
using Amorous.Engine.NPC;
using Microsoft.Xna.Framework.Content;

namespace Amorous.Mod.NPC
{
    /// <summary>
    /// Use this for all your NPC needs
    /// </summary>
    /// <typeparam name="THead">Head types</typeparam>
    /// <typeparam name="TPose">Body pose types</typeparam>
    /// <typeparam name="TClothes">Clothes types</typeparam>
    public class ModLayerNPC<THead, TPose, TClothes> : _tQA7Y5sF0zuHU50dj3uiVPrd6rj where THead : struct, IConvertible where TPose : struct, IConvertible where TClothes : struct, IConvertible
    {
        /// <summary>
        /// Called when the NPC is clicked
        /// </summary>
        public Action Click
        {
            get => _WoDwaTbdNFoPXi9rb8DLYg9BojM;
            set => _WoDwaTbdNFoPXi9rb8DLYg9BojM = value;
        }

        /// <summary>
        /// X position
        /// </summary>
        public float X
        {
            get => _56RrxEycX6y2PIjtHZEAp7SruGi;
            set => _56RrxEycX6y2PIjtHZEAp7SruGi = value;
        }

        /// <summary>
        /// Y position
        /// </summary>
        public float Y
        {
            get => _cyMnLMRA91tXwJ9bRfGHgRGuhjc;
            set => _cyMnLMRA91tXwJ9bRfGHgRGuhjc = value;
        }

        /// <summary>
        /// Whether or not should the NPC be flipped
        /// </summary>
        public bool Flip
        {
            get => _7TLunCN43az0Ziah5LwQmOdtmWA;
            set => _7TLunCN43az0Ziah5LwQmOdtmWA = value;
        }

        /// <summary>
        /// Scale
        /// </summary>
        public float Size
        {
            get => _uhxWyFiALVSwPgZW757OrPVuCzP;
            set => _uhxWyFiALVSwPgZW757OrPVuCzP = value;
        }

        /// <summary>
        /// Hitbox width, needed for clicking to work. Usually should be the same as the texture width.
        /// </summary>
        public int HitboxWidth
        {
            get => _j4EFoUdbyifDTL0FylpVGTsyBfo;
            set => _j4EFoUdbyifDTL0FylpVGTsyBfo = value;
        }

        /// <summary>
        /// Hitbox height, needed for clicking to work. Usually should be the same as the texture height.
        /// </summary>
        public int HitboxHeight
        {
            get => _XcUnwGkscdzGem5bYSSURdiPvUL;
            set => _XcUnwGkscdzGem5bYSSURdiPvUL = value;
        }

        /// <summary>
        /// True when cursor is hovering over the NPC
        /// </summary>
        public bool Selected
        {
            get => _J3yjieYtPGSPKYzpP1JJA1ri0YI;
            set => _J3yjieYtPGSPKYzpP1JJA1ri0YI = value;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="gameInstance">Amorous game instance</param>
        /// <param name="modLoader">Mod loader instance</param>
        /// <param name="assetPath">Base path to NPC textures</param>
        /// <param name="scale">Size</param>
        protected ModLayerNPC(_ReSMQinwfLqHErTI2lafWxQJw9B gameInstance, ModLoader modLoader, string assetPath, float scale = 1f) : base(gameInstance, assetPath, scale)
		{
			_modLoader = modLoader;
        }

        private ModLoader _modLoader;

        /// <summary>
        /// Adds a head texture corresponding to head type enum
        /// </summary>
        /// <param name="headType">Head type</param>
        /// <param name="assetNames">Asset names for all textures for the corresponding head type</param>
        /// <returns>Asset</returns>
        public _vsPwoGRzdV3UghDIcwK7iTvgdnB AddHead(THead headType, params string[] assetNames)
        {
            return base._0Wiw7xIYY22fKv0YpUfaDEiCdLR(Enum.GetName(typeof(THead), headType), assetNames);
        }

        /// <summary>
        /// Adds a body texture corresponding to body pose type enum
        /// </summary>
        /// <param name="poseType">Body pose type</param>
        /// <param name="assetNames">Asset names for all textures for the corresponding body pose type</param>
        /// <returns>Asset</returns>
        public _RyacNUPTn4X3H8v8ol92joGxMwI AddBody(TPose poseType, params string[] assetNames)
        {
            return base._y0Xxf8eVY5hsAoYuAfHsWTOHvHH(Enum.GetName(typeof(TPose), poseType), assetNames);
        }


        /// <summary>
        /// Adds clothes texture corresponding to body pose type and clothes type enum
        /// </summary>
        /// <param name="poseType">Body pose type</param>
        /// <param name="clothesType">Clothes type</param>
        /// <param name="assetNames">Asset names for all textures for the corresponding body pose + clothes type</param>
        /// <returns>Asset</returns>
        public _BbHKO1RnDl3KwddA2IsycsbGMok AddClothes(TPose poseType, TClothes clothesType, params string[] assetNames)
        {
            return base._c0wAnyBYNqJuwjaMa7DCy40jUxW(Enum.GetName(typeof(TPose), poseType), Enum.GetName(typeof(TClothes), clothesType), assetNames);
        }

        /// <summary>
        /// Sets a head type to use
        /// </summary>
        /// <param name="headType">Head type to use</param>
        public void SetHead(THead headType)
        {
            base._hdHfYTSexLTpKkYjWhnM9HHBj7h(Enum.GetName(typeof(THead), headType));
        }

        /// <summary>
        /// Sets a body pose type to use
        /// </summary>
        /// <param name="poseType">Body pose type to use</param>
        public void SetBody(TPose poseType)
        {
            base._bMvC1lcLolsE3K48f8Q107t2kGi(Enum.GetName(typeof(TPose), poseType));
        }

        /// <summary>
        /// Sets clothes type to use
        /// </summary>
        /// <param name="clothesTypes">Clothes types to use</param>
        public void SetClothes(params TClothes[] clothesTypes)
        {
            base._eU99r1wUbv5IkuhBZsT1SGUwnfU(clothesTypes.Select(clothesType => Enum.GetName(typeof(TClothes), clothesType)).ToArray());
        }

        /// <summary>
        /// Adds an attachment to the NPC
        /// </summary>
        /// <param name="contentManager_0">Content manager used for loading the textures</param>
        /// <param name="path">Path to the texture</param>
        public void AddAttachment(ContentManager contentManager_0, string path)
        {
            typeof(_tQA7Y5sF0zuHU50dj3uiVPrd6rj).GetMethod("_hbAEB5gABtEbAHSANBliKbD4Ti2", BindingFlags.NonPublic | BindingFlags.Instance)?.Invoke(this, new object[] { contentManager_0, path });
        }

        /// <summary>
        /// Method that gets called when NPC location on screen is changed during a cutscene (left, middle, right)
        /// </summary>
        /// <example>
        /// Use a switch statement to change values for specific locations:
        /// <code>
        /// public override void _obvu1L6KrxGqH1z2XacOoFxfneg(NPCLocation location)
        /// {
        ///     base._obvu1L6KrxGqH1z2XacOoFxfneg(location);
        ///     switch (location)
        ///     {
        ///         case NPCLocation.Middle:
        ///             Size = 1f;
        ///             Flip = true;
        ///             X = 240f;
        ///             Y = 50f;
        ///             return;
        ///         case NPCLocation.Left:
        ///             Size = 0.85f;
        ///             Flip = true;
        ///             X = -300f;
        ///             Y = 50f;
        ///             return;
        ///         case NPCLocation.Right:
        ///             Size = 0.85f;
        ///             Flip = false;
        ///             X = 990f;
        ///             Y = 50f;
        ///             return;
        ///         default:
        ///             return;
        ///     }
        /// }
        /// </code>
        /// </example>
        /// <param name="location">NPC location</param>
        public override void _obvu1L6KrxGqH1z2XacOoFxfneg(NPCLocation location)
        {
            base._obvu1L6KrxGqH1z2XacOoFxfneg(location);
        }

        /// <summary>
        /// Initialization method
        /// </summary>
        public override void _pedFGoqAIjRhB9Jo0miZgSOTbKs()
		{
			foreach (_RyacNUPTn4X3H8v8ol92joGxMwI clothes in _XJAEGegoTJJBS8C1S6rogYcNoxm)
			{
				clothes._Q6qiZHXAI4nihNS7aci1Zxp8YVh.ForEach(delegate (string string_0)
				{
                    AddAttachment(_modLoader.ModContentManager, string_0);
                });
				clothes._8dlJkKgavGoWjrtFaxS4knsHQD5.ForEach(delegate (string string_0)
				{
                    AddAttachment(_modLoader.ModContentManager, string_0);
				});
				foreach (_BbHKO1RnDl3KwddA2IsycsbGMok body in clothes._xlVQdwn1aHObUlMBoUzn8KRMFjk)
				{
					body._Q6qiZHXAI4nihNS7aci1Zxp8YVh.ForEach(delegate (string string_0)
					{
                        AddAttachment(_modLoader.ModContentManager, string_0);
					});
				}
			}
			foreach (_vsPwoGRzdV3UghDIcwK7iTvgdnB head in _ixej7ojdvVBBcTDRJc07noSZ1C5)
			{
				head._Q6qiZHXAI4nihNS7aci1Zxp8YVh.ForEach(delegate (string string_0)
				{
                    AddAttachment(_modLoader.ModContentManager, string_0);
				});
				if (!string.IsNullOrEmpty(head._V4jqDsvg7WrDeJGs2taf9GbevJ5))
				{
                    AddAttachment(_modLoader.ModContentManager, head._V4jqDsvg7WrDeJGs2taf9GbevJ5);
				}
            }
        }

	}
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Amorous.Mod.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Newtonsoft.Json;

namespace Amorous.Mod
{
    /// <summary>
    /// Yup, it's real
    /// </summary>
    public class ModLoader
    {
        /// <summary>
        /// Amorous game instance, lots of obfuscated stuff, might release deobfuscated version if anyone finds this text
        /// </summary>
        public _ReSMQinwfLqHErTI2lafWxQJw9B GameInstance { get; private set; }

        /// <summary>
        /// Vanilla content manager, points to Content-Release
        /// </summary>
        public ContentManager ContentManager => GameInstance._w4xueVvDf993cAGLPVqUDMn078B;

        /// <summary>
        /// Mod content manager, points to Content-Mods
        /// </summary>
        public ModContentManager ModContentManager { get; private set; }

        /// <summary>
        /// Gets the current scene
        /// </summary>
        /// <example>
        /// In order to add an NPC to the current scene you would do something like
        /// <code>
        /// if (ModLoader.Instance.CurrentScene is ClubUpstairsScene clubUpstairsScene)
        /// {
        ///     var npcLayer = GetNPCLayer(clubUpstairsScene, nameof(NPC));
        ///     if (npcLayer == null)
        ///     {
        ///         var npc = ModLoader.Instance.AddNPC&lt;NPC&gt;(_bRA4WJRW7AfFyNcbS8anXPvTZZc.Background);
        ///         if (npc != null)
        ///         {
        ///             npc.Click = NPCClickAction;
        ///             npc.X = 1000f;
        ///             npc.Y = 125f;
        ///         }
        ///     }
        /// }
        /// </code>
        /// </example>
        public _FBIT8ioambRx7Q6ZCZCjclhjFpU CurrentScene => GameInstance._UYglTfDrqAD33oAMLNkhpfrF1Bf;

        /// <summary>
        /// Gets an NPC layer from specified scene 
        /// </summary>
        /// <param name="scene">Scene</param>
        /// <param name="npcName">NPC name</param>
        /// <returns>NPC layer</returns>
        public static _NEbeB8680apM0Nf6CoDoIKMjFTr GetNPCLayer(_FBIT8ioambRx7Q6ZCZCjclhjFpU scene, string npcName)
        {
            return scene._AcNwvxk0ZsSIGKXnqd8NBvk1fbA(npcName);
        }

        /// <summary>
        /// Game
        /// </summary>
        public Microsoft.Xna.Framework.Game Game;

        private readonly FakeGameInstance _fakeInstance;

        private readonly List<IModBase> _modList;

        private List<Type> _npcList;

        /// <summary>
        /// Instance of this class, there can only be one
        /// </summary>
        public static ModLoader Instance;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="game">FNA Game</param>
        /// <param name="gameInstance">Amorous game instance</param>
        public ModLoader(Microsoft.Xna.Framework.Game game, _ReSMQinwfLqHErTI2lafWxQJw9B gameInstance)
        {
            GameInstance = gameInstance;
            Game = game;
            _fakeInstance = new FakeGameInstance(this);

            Instance = this;

            _modList = new List<IModBase>();

            _npcList = new List<Type>();

            var dllPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Content-Mods");
            LogHelper.LogInfo(dllPath);
            foreach (string dll in Directory.GetFiles(dllPath, "*.dll", SearchOption.TopDirectoryOnly))
            {
                LogHelper.LogInfo(dll);
                try
                {
                    var loadedAssembly = Assembly.LoadFile(dll);
                    var found = false;
                    foreach (Type type in loadedAssembly.GetTypes().Where(test => test.GetInterfaces().Contains(typeof(IModBase))))
                    {
                        var mod = Activator.CreateInstance(type);
                        _modList.Add(mod as IModBase);
                        found = true;
                    }

                    if (!found)
                    {
                        LogHelper.LogError($"Could not find an implementation of IModBase in assembly {loadedAssembly.FullName}!");
                    }
                    else
                    {
                        foreach (Type type in loadedAssembly.GetTypes())
                        {
                            if (typeof(_UP4orz9jE5L118EdoBiV8uL9I5b).IsAssignableFrom(type))
                            {
                                _npcList.Add(type);
                            }
                        }
                        LogHelper.LogInfo($"Successfully loaded assembly {loadedAssembly.FullName}");
                    }
                }
                catch (FileLoadException loadEx)
                {
                    LogHelper.LogError($"{loadEx.FileName} is already loaded!");
                } 
                catch (BadImageFormatException imgEx)
                {
                    LogHelper.LogError($"{imgEx.FileName} is not a valid assembly!");
                }

            }
        }

        /// <summary>
        /// Initialize
        /// </summary>
        public void Initialize()
        {
            ModContentManager = new ModContentManager(Game.Content.ServiceProvider, Game.Content.RootDirectory);

            foreach (var mod in _modList)
            {
                mod?.Initialize();
            }
        }

        /// <summary>
        /// Load
        /// </summary>
        public void LoadContent()
        {
            foreach (var mod in _modList)
            {
                mod?.LoadContent();
            }
        }

        /// <summary>
        /// Unload
        /// </summary>
        public void UnloadContent()
        {
            foreach (var mod in _modList)
            {
                mod?.UnloadContent();
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="gameTime">Time</param>
        public void Update(GameTime gameTime)
        {
            foreach (var mod in _modList)
            {
                mod?.Update(gameTime);
            }
        }

        /// <summary>
        /// Draw
        /// </summary>
        /// <param name="gameTime">Time</param>
        public void Draw(GameTime gameTime)
        {
            foreach (var mod in _modList)
            {
                mod?.Draw(gameTime);
            }
        }

        /// <summary>
        /// Loads a cutscene (Data/Quests) use filename without extension
        /// </summary>
        /// <param name="name">Name of the cutscene (quest) to load</param>
        public void LoadScene(string name)
        {
            _al1N3vKB7trddft4CIv5BsUe86l sceneManager = LoadCutscene(name);
            GameInstance._oD7pc3GYEkI5aI0pU6dlJh49LQc(sceneManager);
        }

        private _al1N3vKB7trddft4CIv5BsUe86l LoadCutscene(string string_2)
        {
            string moddedPath = string.Format("Content-Mods/Data/Quests/{0}.json", string_2);
            string path = string.Format("{0}/Data/Quests/{1}.json", Game.Content.RootDirectory, string_2);
            string value;
            if (!File.Exists(moddedPath))
            {
                if (!File.Exists(path))
                {
                    LogHelper.LogError($"Failed to load cutscene '{string_2}'");
                    return null;
                }
                value = _9vGZbHaN5UnBL9kYvNraZVUx9fF._VPea7J6U2BpZd6LtG4ZbxjOZIEz(path);
            }
            else
            {
                LogHelper.LogWarn($"Loaded modded cutscene '{string_2}'");
                value = _9vGZbHaN5UnBL9kYvNraZVUx9fF._zyx20wgjxNUdBk5tmkZBB7rwIF1(moddedPath);
            }
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Converters =
                {
                    new _HppLBzeicD2TlVOHygiXRj5GHnj()
                }
            };
            _lyAjhQ6qiZFcM84VaYogm9W10lC cutscene = JsonConvert.DeserializeObject<_lyAjhQ6qiZFcM84VaYogm9W10lC>(value, settings);
            if (cutscene == null)
            {
                return null;
            }
            return new _al1N3vKB7trddft4CIv5BsUe86l(_fakeInstance, cutscene, Assembly.Load("Amorous.Game"), Assembly.Load("Amorous.Mod"));
        }
        
        /// <summary>
        /// Adds an NPC to current scene
        /// </summary>
        /// <typeparam name="T">NPC Type</typeparam>
        /// <param name="layerType">Which layer to put the NPC on</param>
        /// <returns>NPC instance</returns>
        public T AddNPC<T>(_bRA4WJRW7AfFyNcbS8anXPvTZZc layerType) where T : _UP4orz9jE5L118EdoBiV8uL9I5b
        {
            return AddNPC(typeof(T).Name, layerType, typeof(T)) as T;
        }

        /// <summary>
        /// Adds an NPC to current scene
        /// </summary>
        /// <param name="name">NPC Name</param>
        /// <param name="layerType">Which layer to put the NPC on</param>
        /// <param name="npcType">Used when creating a modded NPC</param>
        /// <returns>NPC Instance</returns>
        public _UP4orz9jE5L118EdoBiV8uL9I5b AddNPC(string name, _bRA4WJRW7AfFyNcbS8anXPvTZZc layerType, Type npcType = null)
        {
            if (GameInstance._UYglTfDrqAD33oAMLNkhpfrF1Bf == null)
            {
                return null;
            }
            var npcLayer = GameInstance._UYglTfDrqAD33oAMLNkhpfrF1Bf._AcNwvxk0ZsSIGKXnqd8NBvk1fbA(name);
            if (npcLayer != null)
            {
                _UP4orz9jE5L118EdoBiV8uL9I5b npc = npcLayer._o3ipX9xd6EWoCvx6j5lfMrGd5RG;
                if (npc != null)
                {
                    if (npc._Tjk8c6jA1XW1y3veACkFqhW69Ev)
                    {
                        return null;
                    }
                }
                npcLayer._pS1ZehS0nSuHyQrZas0qKqDe6Cd = ((layerType == _bRA4WJRW7AfFyNcbS8anXPvTZZc.None) ? npcLayer._pS1ZehS0nSuHyQrZas0qKqDe6Cd : layerType);
                npcLayer._dY1ve0GcmvRIvgTtGffHLq10RFe = ((npcLayer._pS1ZehS0nSuHyQrZas0qKqDe6Cd == _bRA4WJRW7AfFyNcbS8anXPvTZZc.Background) ? 1 : 3);
                GameInstance._UYglTfDrqAD33oAMLNkhpfrF1Bf._vdpqao60UtR8pygrlujMBRDMDuj();
                return npcLayer._o3ipX9xd6EWoCvx6j5lfMrGd5RG;
            }

            Type type = npcType;
            if (type == null)
            {
                type = _npcList.FirstOrDefault(new Func<Type, bool>(type0 => type0.Name == name));
            }
            if (type == null)
            {
                var vanilla = GameInstance._QOadRz2h6UGR7YNJ2lzbAd4dyDf(name, layerType);
                if (vanilla == null)
                {
                    LogHelper.LogError($"Failed to load modded npc '{name}'");
                    return null;
                }
                return vanilla;
            }
            var npcBase = Activator.CreateInstance(type, new object[]
            {
                GameInstance,
                this
            }) as _UP4orz9jE5L118EdoBiV8uL9I5b;
            if (npcBase == null)
            {
                LogHelper.LogError($"Failed to instance modded npc '{name}'");
                return null;
            }
            npcBase._LbrIuNSJRdvBzAjHEZiN0sr8ROG = GameInstance;
            npcBase._pedFGoqAIjRhB9Jo0miZgSOTbKs();
            GameInstance._UYglTfDrqAD33oAMLNkhpfrF1Bf._pm44qDuDYHsHwiTgexENATm5RuN(npcBase, (layerType == _bRA4WJRW7AfFyNcbS8anXPvTZZc.None) ? _bRA4WJRW7AfFyNcbS8anXPvTZZc.Background : layerType);
            return npcBase;
        }
    }
}

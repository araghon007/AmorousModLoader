using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Amorous.Game.NPC;
using Amorous.Game.Scenes;
using Amorous.Mod;
using Amorous.Mod.Helpers;
using araghon007.AmorousTestMod.NPC;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SDL2;
using Squid;
using Keys = Microsoft.Xna.Framework.Input.Keys;
using Point = Microsoft.Xna.Framework.Point;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace araghon007.AmorousTestMod
{
    public class Main : IModBase
    {
        private bool devmode;

        private FieldInfo spriteBatch;
        private FieldInfo spriteFont;
        private FieldInfo textPos;

        public void Initialize()
        {
            spriteBatch = typeof(_drFW6OzyMF8ZDlRgOIZiVzGGOBb).GetField("_J74YIg3eHi5WWPnc5nA2CxnRS3o", BindingFlags.NonPublic | BindingFlags.Instance);
            spriteFont = typeof(_drFW6OzyMF8ZDlRgOIZiVzGGOBb).GetField("_2ikcIzvFeavp6sYT4hH5GNiMEFJ", BindingFlags.NonPublic | BindingFlags.Instance);
            textPos = typeof(_drFW6OzyMF8ZDlRgOIZiVzGGOBb).GetField("_IAPFNCvMhkv3QK153qm1VRFbMCj", BindingFlags.NonPublic | BindingFlags.Instance);
        }

        public void LoadContent()
        {

        }

        public void UnloadContent()
        {

        }

        public void Draw(GameTime gameTime)
        {
            if (devmode)
            {
                var sprites = (SpriteBatch)spriteBatch.GetValue(ModLoader.Instance.GameInstance);
                var font = (SpriteFont)spriteFont.GetValue(ModLoader.Instance.GameInstance);

                var pos = (Vector2)textPos.GetValue(ModLoader.Instance.GameInstance);

                sprites.Begin();
                sprites._MuvXtZXp3n02KyftUrb2C1LCc4G(font, "Devmode enabled", pos, Color.Red);
                foreach (var asset in _assets)
                {
                    pos.Y += 40;
                    sprites._MuvXtZXp3n02KyftUrb2C1LCc4G(font, $"{asset._XLVRTZn9MROFz2zOlKMyKZeK0tA}, X:{asset._56RrxEycX6y2PIjtHZEAp7SruGi}, Y:{asset._cyMnLMRA91tXwJ9bRfGHgRGuhjc}, Size:{asset._uhxWyFiALVSwPgZW757OrPVuCzP}", pos, Color.Red);
                }

                foreach (var npc in npcs)
                {
                    pos.Y += 40;
                    sprites._MuvXtZXp3n02KyftUrb2C1LCc4G(font, $"{npc.GetType().Name}, X:{npc._56RrxEycX6y2PIjtHZEAp7SruGi}, Y:{npc._cyMnLMRA91tXwJ9bRfGHgRGuhjc}, Size:{npc._uhxWyFiALVSwPgZW757OrPVuCzP}", pos, Color.Red);
                }
                sprites.End();

            }
        }

        private MouseState previousMouseState;

        private MouseState mouseState;

        public void Update(GameTime gameTime)
        {
            previousMouseState = mouseState;
            mouseState = Mouse.GetState();
            
            if (ModLoader.Instance.CurrentScene is ClubInsideScene clubInsideScene)
            {
                var npcLayer = ModLoader.GetNPCLayer(clubInsideScene, nameof(ClubInsideANPC));
                if (npcLayer != null && npcLayer._o3ipX9xd6EWoCvx6j5lfMrGd5RG._WoDwaTbdNFoPXi9rb8DLYg9BojM == null)
                {
                    LogHelper.LogInfo("He exist2");
                    npcLayer._o3ipX9xd6EWoCvx6j5lfMrGd5RG._WoDwaTbdNFoPXi9rb8DLYg9BojM = ClickAction;
                    typeof(ClubInsideANPC).GetProperty("_j4EFoUdbyifDTL0FylpVGTsyBfo")?.SetValue(npcLayer._o3ipX9xd6EWoCvx6j5lfMrGd5RG, 375);
                    typeof(ClubInsideANPC).GetProperty("_XcUnwGkscdzGem5bYSSURdiPvUL")?.SetValue(npcLayer._o3ipX9xd6EWoCvx6j5lfMrGd5RG, 967);
                }
            }
            
            else if (ModLoader.Instance.CurrentScene is ClubUpstairsScene clubUpstairsScene && !PlayerHelper.GetPlayerFlag("araghon007.AmorousTestMod.StickmanHidden"))
            {
                var stickmanLayer = ModLoader.GetNPCLayer(clubUpstairsScene, nameof(Stickman));
                if (stickmanLayer == null)
                {
                    LogHelper.LogInfo("He appear");
                    var stickman = ModLoader.Instance.AddNPC<Stickman>(_bRA4WJRW7AfFyNcbS8anXPvTZZc.Background);
                    if (stickman != null)
                    {
                        stickman.Click = StickmanClickAction;
                        stickman.X = 1600f;
                        stickman.Y = 125f;
                    }
                }
            }

            if (InputHelper.WasPressed(_BX5waHFovNaRqrCMROUmndxdY7j.LeftButton))
            {
                LogHelper.LogInfo(ModLoader.Instance.GameInstance._iYEzxWPnNpwFeDGgdEnxBgaCEgH._uhuGvNkAEaXifw5w0nsJFN6ep3D(ModLoader.Instance.GameInstance._UKtgpIEk7EGdnuHgaPCNqYjXWc6._WtvJdQOf1lCQPyMpLbiPPVHkbFN).ToString());
            }

            if (InputHelper.IsDown(Keys.LeftControl) && InputHelper.WasPressed(Keys.Tab))
            {
                devmode = !devmode;
                PlayerHelper.SetPlayerFlag("araghon007.AmorousTestMod.Devmode", devmode);
            }

            if (devmode)
            {
                Point point = ModLoader.Instance.GameInstance._iYEzxWPnNpwFeDGgdEnxBgaCEgH._uhuGvNkAEaXifw5w0nsJFN6ep3D(ModLoader.Instance.GameInstance._UKtgpIEk7EGdnuHgaPCNqYjXWc6._WtvJdQOf1lCQPyMpLbiPPVHkbFN);
                TestHit(point, ModLoader.Instance.GameInstance._UYglTfDrqAD33oAMLNkhpfrF1Bf._i1M9qzxeSmKzCijA2dkRxpsXFjL);

                if (!test2 && InputHelper.IsDown(Keys.LeftControl) &&
                    InputHelper.WasPressed(_BX5waHFovNaRqrCMROUmndxdY7j.RightButton))
                {
                    test2 = true;
                    var npc = npcs.LastOrDefault();
                    if (npc != null)
                    {
                        obj.Item1 = npc;
                        obj.Item2.X = npc._56RrxEycX6y2PIjtHZEAp7SruGi - point.X;
                        obj.Item2.Y = npc._cyMnLMRA91tXwJ9bRfGHgRGuhjc - point.Y;
                    }
                    else
                    {
                        var asset = _assets.LastOrDefault();
                        if (asset != null)
                        {
                            obj.Item1 = asset;
                            obj.Item2.X = asset._56RrxEycX6y2PIjtHZEAp7SruGi - point.X;
                            obj.Item2.Y = asset._cyMnLMRA91tXwJ9bRfGHgRGuhjc - point.Y;
                        }
                    }
                }

                else if (!test2 && InputHelper.WasPressed(_BX5waHFovNaRqrCMROUmndxdY7j.RightButton))
                {
                    LogHelper.LogInfo("ShowThing");
                    var c = Mouse.GetState();
                    Window test = new Window
                    {
                        Modal = true,
                        Dock = DockStyle.None,
                        Position = new Squid.Point(c.X, c.Y),
                        Size = new Squid.Point(120, 0),
                        AutoSize = AutoSize.Vertical
                    };
                    var b = new Button
                    {
                        Dock = DockStyle.Top,
                        TextAlign = Alignment.MiddleCenter,
                        Text = "Test",
                        AutoSize = AutoSize.Vertical
                    };
                    b.MouseClick += delegate
                    {
                        test.Close();
                    };
                    test.Controls.Add(b);
                    test.Show(ModLoader.Instance.GameInstance._UYglTfDrqAD33oAMLNkhpfrF1Bf._7v5XAOmlUn9RcqyvuuhmBIz45Re);
                }

                if (InputHelper.IsDown(Keys.LeftControl) && previousMouseState.ScrollWheelValue != mouseState.ScrollWheelValue)
                {
                    LogHelper.LogInfo((mouseState.ScrollWheelValue - previousMouseState.ScrollWheelValue).ToString());
                    var scrollRate = 1200f;
                    if (InputHelper.IsDown(Keys.LeftShift))
                        scrollRate = 600f;
                    else if(InputHelper.IsDown(Keys.LeftAlt))
                        scrollRate = 2400f;
                    var npc = npcs.LastOrDefault();
                    if (npc != null)
                    {
                        npc._uhxWyFiALVSwPgZW757OrPVuCzP += (mouseState.ScrollWheelValue - previousMouseState.ScrollWheelValue) / scrollRate;
                    }
                    else
                    {
                        var asset = _assets.LastOrDefault();
                        if (asset != null)
                        {
                            asset._uhxWyFiALVSwPgZW757OrPVuCzP += (mouseState.ScrollWheelValue - previousMouseState.ScrollWheelValue) / scrollRate;
                        }
                    }
                }
            }

            if (test2)
            {
                if (InputHelper.IsReleased(_BX5waHFovNaRqrCMROUmndxdY7j.RightButton))
                {
                    test2 = false;
                    obj.Item1 = null;
                }
                else if (obj.Item1 != null)
                {
                    Point point = ModLoader.Instance.GameInstance._iYEzxWPnNpwFeDGgdEnxBgaCEgH._uhuGvNkAEaXifw5w0nsJFN6ep3D(ModLoader.Instance.GameInstance._UKtgpIEk7EGdnuHgaPCNqYjXWc6._WtvJdQOf1lCQPyMpLbiPPVHkbFN);
                    if (obj.Item1 is _UP4orz9jE5L118EdoBiV8uL9I5b npc)
                    {
                        npc._56RrxEycX6y2PIjtHZEAp7SruGi = point.X + obj.Item2.X;
                        npc._cyMnLMRA91tXwJ9bRfGHgRGuhjc = point.Y + obj.Item2.Y;
                    }
                    else
                    {
                        if (obj.Item1 is _hClNIa2MAAqcV9tfVNkRq6Q9UNy asset)
                        {
                            asset._56RrxEycX6y2PIjtHZEAp7SruGi = point.X + obj.Item2.X;
                            asset._cyMnLMRA91tXwJ9bRfGHgRGuhjc = point.Y + obj.Item2.Y;
                        }
                    }
                }
            }
        }

        private bool test2;

        private (object, Vector2) obj;

        private List<_hClNIa2MAAqcV9tfVNkRq6Q9UNy> _assets;

        private List<_UP4orz9jE5L118EdoBiV8uL9I5b> npcs;

        private List<Texture2D> GetTexture(_tQA7Y5sF0zuHU50dj3uiVPrd6rj npc)
        {
            var a = (typeof(_tQA7Y5sF0zuHU50dj3uiVPrd6rj).GetField("_pxyMxDDkPjWspWXyu1eZMSnagBN", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(npc) as IList);
            var b = new List<Texture2D>();
            foreach (var c in a)
            {
                b.Add(c.GetType().GetField("_DTyaOiCurejh2W3LgbKLDKJ2ljG", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(c) as Texture2D);
            }
            return b;
        }

        private void TestHit(Point point, List<_hClNIa2MAAqcV9tfVNkRq6Q9UNy> assets)
        {
            _assets = new List<_hClNIa2MAAqcV9tfVNkRq6Q9UNy>();

            npcs = new List<_UP4orz9jE5L118EdoBiV8uL9I5b>();

            foreach (var asset in assets)
            {
                Rectangle rectangle;
                if (asset is _NEbeB8680apM0Nf6CoDoIKMjFTr npclayer)
                {
                    _UP4orz9jE5L118EdoBiV8uL9I5b npc = npclayer._o3ipX9xd6EWoCvx6j5lfMrGd5RG;
                    rectangle.X = (int)npc._56RrxEycX6y2PIjtHZEAp7SruGi;
                    rectangle.Y = (int)npc._cyMnLMRA91tXwJ9bRfGHgRGuhjc;
                    rectangle.Width = (int)(npc._j4EFoUdbyifDTL0FylpVGTsyBfo * npc._uhxWyFiALVSwPgZW757OrPVuCzP);
                    rectangle.Height = (int)(npc._XcUnwGkscdzGem5bYSSURdiPvUL * npc._uhxWyFiALVSwPgZW757OrPVuCzP);

                    if (rectangle.Width == 0)
                    {
                        rectangle.Width = 300;
                        rectangle.Height = 600;
                    }

                    if (npc is _aMrDBJu0Ggc2ohnPmRDub4uJ3dh)
                    {
                        rectangle.X -= rectangle.Width / 2;
                        rectangle.Y -= rectangle.Height;
                    }

                    if (rectangle.Contains(point))
                    {
                        npcs.Add(npc);
                    }
                }
                else
                {
                    rectangle.X = (int)asset._56RrxEycX6y2PIjtHZEAp7SruGi;
                    rectangle.Y = (int)asset._cyMnLMRA91tXwJ9bRfGHgRGuhjc;
                    rectangle.Width = asset._j4EFoUdbyifDTL0FylpVGTsyBfo;
                    rectangle.Height = asset._XcUnwGkscdzGem5bYSSURdiPvUL;
                    if (rectangle.Contains(point))
                    {
                        _assets.Add(asset);
                    }
                }
            }
        }

        private void ClickAction()
        {
            _X6x9OC0TR5nhrrlKOc4hs3rbcWG._q7sB0qiKf99xCTHUXkcw1xQgLZi("Haha, it works");
            SDL.SDL_MessageBoxData messageBox;
            messageBox = new SDL.SDL_MessageBoxData
            {
                flags = SDL.SDL_MessageBoxFlags.SDL_MESSAGEBOX_ERROR,
                title = "ModLoader",
                message = "Fuck you, this mod works perfectly",
                numbuttons = 1,
                buttons = new[]
                {
                    new SDL.SDL_MessageBoxButtonData
                    {
                        flags = SDL.SDL_MessageBoxButtonFlags.SDL_MESSAGEBOX_BUTTON_RETURNKEY_DEFAULT,
                        buttonid = 0,
                        text = "OK"
                    }
                }
            };
            SDL.SDL_ShowMessageBox(ref messageBox, out _);
        }

        private void StickmanClickAction()
        {
            if (!PlayerHelper.GetPlayerFlag("araghon007.AmorousTestMod.StickmanTalked"))
            {
                ModLoader.Instance.LoadScene("StickmanPreDate");
            }
            else
            {
                ModLoader.Instance.LoadScene("StickmanQuotes");
            }
        }
    }
}

using Microsoft.Xna.Framework.Input;

namespace Amorous.Mod.Helpers
{
    /// <summary>
    /// Input stuff
    /// </summary>
    public static class InputHelper
    {
        /// <summary>
        /// Checks if key that was previously pressed is now released
        /// </summary>
        /// <param name="key">Key to check</param>
        /// <returns>Value</returns>
        public static bool IsReleased(Keys key)
        {
            return ModLoader.Instance.GameInstance._UKtgpIEk7EGdnuHgaPCNqYjXWc6._Lrw9KE8BwknErGxY7Awq364zony(key);
        }

        /// <summary>
        /// Checks if mouse button that was previously pressed is now released
        /// </summary>
        /// <param name="button">Mouse button to check</param>
        /// <returns>Value</returns>
        public static bool IsReleased(_BX5waHFovNaRqrCMROUmndxdY7j button)
        {
            return ModLoader.Instance.GameInstance._UKtgpIEk7EGdnuHgaPCNqYjXWc6._Lrw9KE8BwknErGxY7Awq364zony(button);
        }

        /// <summary>
        /// Checks if mouse button is down
        /// </summary>
        /// <param name="button">Mouse button to check</param>
        /// <returns>Value</returns>
        public static bool IsDown(_BX5waHFovNaRqrCMROUmndxdY7j button)
        {
            return ModLoader.Instance.GameInstance._UKtgpIEk7EGdnuHgaPCNqYjXWc6._Q179G9OEeClugar1e8PUwQzv2HB(button);
        }

        /// <summary>
        /// Checks if key is pressed down
        /// </summary>
        /// <param name="key">Key to check</param>
        /// <returns>Value</returns>
        public static bool IsDown(Keys key)
        {
            return ModLoader.Instance.GameInstance._UKtgpIEk7EGdnuHgaPCNqYjXWc6._Q179G9OEeClugar1e8PUwQzv2HB(key);
        }


        /// <summary>
        /// Checks if mouse button that was previously up is now pressed
        /// </summary>
        /// <param name="button">Mouse button to check</param>
        /// <returns>Value</returns>
        public static bool WasPressed(_BX5waHFovNaRqrCMROUmndxdY7j button)
        {
            return ModLoader.Instance.GameInstance._UKtgpIEk7EGdnuHgaPCNqYjXWc6._o5fUbEwpYd1DssZRWCRpwCq6kNq(button);
        }

        /// <summary>
        /// Checks if key that was previously up is now pressed
        /// </summary>
        /// <param name="key">Key to check</param>
        /// <returns>Value</returns>
        public static bool WasPressed(Keys key)
        {
            return ModLoader.Instance.GameInstance._UKtgpIEk7EGdnuHgaPCNqYjXWc6._o5fUbEwpYd1DssZRWCRpwCq6kNq(key);
        }

        /// <summary>
        /// Gets an array of all pressed keys
        /// </summary>
        /// <returns>Value</returns>
        public static Keys[] GetPressedKeys()
        {
            return ModLoader.Instance.GameInstance._UKtgpIEk7EGdnuHgaPCNqYjXWc6._o5fUbEwpYd1DssZRWCRpwCq6kNq();
        }

    }
}

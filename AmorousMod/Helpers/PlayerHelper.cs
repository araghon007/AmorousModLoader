using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amorous.Mod.Helpers
{
    /// <summary>
    /// Player helper
    /// </summary>
    public static class PlayerHelper
    {

        /// <summary>
        /// Gets a player flag, which can be set manually or through cutscenes (quests)
        /// </summary>
        /// <param name="flag">Flag to get</param>
        /// <returns>Value</returns>
        public static bool GetPlayerFlag(string flag)
        {
            if (_KX2cQHZzfLs4CUMZ2epeXsLbeRH._08pv40xdjTvqkWoAGymNaEB6Hee._UTNKKKhqUUteQ8lBi3l40nYDYKH._CzKE9YHRa0D35CsFzfMG7xrFtoc.ContainsKey(flag))
                return _KX2cQHZzfLs4CUMZ2epeXsLbeRH._08pv40xdjTvqkWoAGymNaEB6Hee._UTNKKKhqUUteQ8lBi3l40nYDYKH._CzKE9YHRa0D35CsFzfMG7xrFtoc[flag];
            return false;
        }

        /// <summary>
        /// Sets a player flag which is useful for tracking progression
        /// </summary>
        /// <param name="flag">Flag to set</param>
        /// <param name="value">Value to set the flag to</param>
        public static void SetPlayerFlag(string flag, bool value)
        {
            if (_KX2cQHZzfLs4CUMZ2epeXsLbeRH._08pv40xdjTvqkWoAGymNaEB6Hee._UTNKKKhqUUteQ8lBi3l40nYDYKH._CzKE9YHRa0D35CsFzfMG7xrFtoc.ContainsKey(flag))
                _KX2cQHZzfLs4CUMZ2epeXsLbeRH._08pv40xdjTvqkWoAGymNaEB6Hee._UTNKKKhqUUteQ8lBi3l40nYDYKH._CzKE9YHRa0D35CsFzfMG7xrFtoc[flag] = value;
            else
                _KX2cQHZzfLs4CUMZ2epeXsLbeRH._08pv40xdjTvqkWoAGymNaEB6Hee._UTNKKKhqUUteQ8lBi3l40nYDYKH._CzKE9YHRa0D35CsFzfMG7xrFtoc.Add(flag, value);
        }
    }
}
